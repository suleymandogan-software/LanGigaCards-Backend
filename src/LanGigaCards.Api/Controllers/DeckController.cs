using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LanGigaCards.Api.DTOs;
using LanGigaCards.Api.Services;

namespace LanGigaCards.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class DeckController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public DeckController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<DeckSummaryDto>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<DeckSummaryDto>>> GetMyDecks()
    {
        var userId = TryGetUserId();
        if (userId is null)
        {
            return Unauthorized();
        }

        var user = await _unitOfWork.Repository<User>().GetByIdAsync(userId.Value);
        if (user is null)
        {
            return Unauthorized();
        }

        var currentLanguage = await LanguageCodeResolver.ResolveAsync(_unitOfWork, user.TargetLanguageCode);

        // Liste öğrenenin şu an çalıştığı dille sınırlı. Sonradan başka bir dile
        // geçtiğinde eski dildeki desteleri silinmiyor (CategoryDeckSynchronizer
        // kendi kuralıyla yalnızca dokunulmamış olanları kaldırıyor); yalnızca
        // o dile geri dönene kadar listede görünmüyorlar, ilerlemeleri yerinde.
        //
        // LanguageCode boş olan desteler bu sütun eklenmeden önce kurulmuş ve
        // migration ile doldurulamamış olanlar; öğrenenin gözünden kaybolmasınlar
        // diye her dilde gösteriliyorlar.
        var decks = (await _unitOfWork.Repository<Deck>()
                .FindAsync(deck => deck.UserId == userId.Value
                    && (deck.LanguageCode == null || deck.LanguageCode == currentLanguage)))
            .OrderByDescending(deck => deck.UpdatedAt ?? deck.CreatedAt)
            .ToList();

        var nativeTitles = await NativeTitlesAsync(user);
        var visuals = await VisualsAsync();

        var cards = (await _unitOfWork.Repository<Vocabulary>()
                .FindAsync(card => card.DeckId != null && decks.Select(d => d.Id).Contains(card.DeckId.Value)))
            .ToList();

        var wordIds = cards.Select(card => card.WordID).ToList();
        var progress = wordIds.Count == 0
            ? new List<UserWordProgress>()
            : (await _unitOfWork.Repository<UserWordProgress>()
                    .FindAsync(p => p.UserID == userId.Value && p.WordID != null && wordIds.Contains(p.WordID.Value)))
                .ToList();

        var now = DateTime.UtcNow;
        return Ok(decks.Select(deck =>
        {
            var deckCards = cards.Where(card => card.DeckId == deck.Id).ToList();
            var stats = ComputeDeckStats(deckCards, progress, now);
            var visual = VisualFor(deck, visuals);
            return new DeckSummaryDto
            {
                Id = deck.Id,
                Title = deck.Title,
                Description = deck.Description,
                CoverImageUrl = deck.CoverImageUrl,
                StarterKey = deck.StarterKey,
                LanguageCode = deck.LanguageCode,
                NativeTitle = NativeTitleFor(deck, nativeTitles),
                Emoji = visual?.Emoji,
                ColorHex = visual?.ColorHex,
                CreatedAt = deck.CreatedAt,
                UpdatedAt = deck.UpdatedAt,
                CardCount = stats.CardCount,
                DueCount = stats.DueCount,
                StudyCount = stats.StudyCount,
                MasteryPercentage = stats.MasteryPercentage,
                ReviewsCount = stats.ReviewsCount
            };
        }));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetDeck(int id)
    {
        var userId = TryGetUserId();
        if (userId is null)
        {
            return Unauthorized();
        }

        var deck = await _unitOfWork.Repository<Deck>().GetByIdAsync(id);
        if (deck is null || deck.UserId != userId.Value)
        {
            return NotFound("Deck not found.");
        }

        var cards = (await _unitOfWork.Repository<Vocabulary>()
                .FindAsync(card => card.DeckId == id))
            .OrderBy(card => card.WordID)
            .ToList();

        var wordIds = cards.Select(card => card.WordID).ToList();
        var progress = wordIds.Count == 0
            ? new List<UserWordProgress>()
            : (await _unitOfWork.Repository<UserWordProgress>()
                    .FindAsync(p => p.UserID == userId.Value && p.WordID != null && wordIds.Contains(p.WordID.Value)))
                .ToList();

        var owner = await _unitOfWork.Repository<User>().GetByIdAsync(userId.Value);
        var stats = ComputeDeckStats(cards, progress, DateTime.UtcNow);
        var visual = VisualFor(deck, await VisualsAsync());
        return Ok(new
        {
            deck.Id,
            deck.Title,
            deck.Description,
            deck.CoverImageUrl,
            deck.StarterKey,
            deck.LanguageCode,
            NativeTitle = NativeTitleFor(deck, await NativeTitlesAsync(owner)),
            Emoji = visual?.Emoji,
            ColorHex = visual?.ColorHex,
            deck.CreatedAt,
            deck.UpdatedAt,
            stats.CardCount,
            stats.DueCount,
            stats.StudyCount,
            stats.MasteryPercentage,
            stats.ReviewsCount,
            Cards = cards.Select(MapCard)
        });
    }

    [HttpPost]
    public async Task<IActionResult> CreateDeck([FromBody] CreateDeckDto dto)
    {
        var userId = TryGetUserId();
        if (userId is null)
        {
            return Unauthorized();
        }

        if (!ModelState.IsValid)
        {
            return ValidationProblem(ModelState);
        }

        var user = await _unitOfWork.Repository<User>().GetByIdAsync(userId.Value);
        if (user is null)
        {
            return Unauthorized();
        }

        var deck = new Deck
        {
            UserId = userId.Value,
            Title = dto.Title.Trim(),
            Description = dto.Description?.Trim() ?? string.Empty,
            CoverImageUrl = string.IsNullOrWhiteSpace(dto.CoverImageUrl) ? null : dto.CoverImageUrl.Trim(),
            StarterKey = string.IsNullOrWhiteSpace(dto.StarterKey) ? null : dto.StarterKey.Trim(),
            // Öğrenenin o an çalıştığı dilden damgalanıyor, istemciden
            // gelmiyor: her deste kurulduğu dile ait ve yalnızca o dil hedefken
            // listede görünüyor.
            LanguageCode = await LanguageCodeResolver.ResolveAsync(_unitOfWork, user.TargetLanguageCode),
            CreatedAt = DateTime.UtcNow
        };

        await _unitOfWork.Repository<Deck>().AddAsync(deck);
        await _unitOfWork.CompleteAsync();

        return CreatedAtAction(nameof(GetDeck), new { id = deck.Id }, new
        {
            deck.Id,
            deck.Title,
            deck.Description,
            deck.CoverImageUrl,
            deck.StarterKey,
            deck.LanguageCode,
            deck.CreatedAt,
            deck.UpdatedAt,
            CardCount = 0,
            DueCount = 0,
            StudyCount = 0,
            MasteryPercentage = 0,
            ReviewsCount = 0
        });
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateDeck(int id, [FromBody] UpdateDeckDto dto)
    {
        var userId = TryGetUserId();
        if (userId is null)
        {
            return Unauthorized();
        }

        if (!ModelState.IsValid)
        {
            return ValidationProblem(ModelState);
        }

        var deck = await _unitOfWork.Repository<Deck>().GetByIdAsync(id);
        if (deck is null || deck.UserId != userId.Value)
        {
            return NotFound("Deck not found.");
        }

        deck.Title = dto.Title.Trim();
        deck.Description = dto.Description?.Trim() ?? string.Empty;
        deck.CoverImageUrl = string.IsNullOrWhiteSpace(dto.CoverImageUrl) ? null : dto.CoverImageUrl.Trim();
        deck.UpdatedAt = DateTime.UtcNow;

        _unitOfWork.Repository<Deck>().Update(deck);
        await _unitOfWork.CompleteAsync();

        return Ok(new
        {
            deck.Id,
            deck.Title,
            deck.Description,
            deck.CoverImageUrl,
            deck.StarterKey,
            deck.LanguageCode,
            deck.CreatedAt,
            deck.UpdatedAt
});
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteDeck(int id)
    {
        var userId = TryGetUserId();
        if (userId is null)
        {
            return Unauthorized();
        }

        var deck = await _unitOfWork.Repository<Deck>().GetByIdAsync(id);
        if (deck is null || deck.UserId != userId.Value)
        {
            return NotFound("Deck not found.");
        }

        var cards = await _unitOfWork.Repository<Vocabulary>()
            .FindAsync(card => card.DeckId == id);
        var cardIds = cards.Select(card => card.WordID).ToHashSet();

        // UserLanguageProfile.LastStudiedDeckId/LastStudiedWordId point here
        // with DeleteBehavior.NoAction on purpose (see AppDbContext's own
        // comment on that mapping) -- the streak/XP/level a deck deletion
        // must never take down live in that same row, so EF can't cascade
        // the delete for us. Left unhandled, deleting whichever deck (or
        // word in it) happens to be the account's "last studied" throws a
        // real FK violation instead of the deck actually deleting.
        var affectedProfiles = await _unitOfWork.Repository<UserLanguageProfile>()
            .FindAsync(profile => profile.UserId == userId.Value &&
                (profile.LastStudiedDeckId == id ||
                 (profile.LastStudiedWordId != null && cardIds.Contains(profile.LastStudiedWordId.Value))));
        foreach (var profile in affectedProfiles)
        {
            profile.LastStudiedDeckId = null;
            profile.LastStudiedWordId = null;
            _unitOfWork.Repository<UserLanguageProfile>().Update(profile);
        }

        foreach (var card in cards)
        {
            _unitOfWork.Repository<Vocabulary>().Delete(card);
        }

        _unitOfWork.Repository<Deck>().Delete(deck);
        await _unitOfWork.CompleteAsync();

        return NoContent();
    }

    /// <summary>
    /// Şablon adlarının öğrenenin ana dilindeki karşılıkları, slug ile
    /// anahtarlı. Deste başına ayrı sorgu atmamak için tek seferde okunuyor.
    /// </summary>
    private async Task<Dictionary<string, string>> NativeTitlesAsync(User? user)
    {
        var nativeCode = await LanguageCodeResolver.ResolveAsync(_unitOfWork, user?.NativeLanguageCode);
        if (nativeCode.Length == 0)
        {
            return new Dictionary<string, string>();
        }

        return await _unitOfWork.Repository<DeckTemplateLabel>().Query()
            .Where(label => label.LanguageCode == nativeCode)
            .Select(label => new { label.DeckTemplate!.Slug, label.Title })
            .ToDictionaryAsync(row => row.Slug, row => row.Title);
    }

    /// <summary>
    /// Destenin ana dildeki adı, yoksa null.
    ///
    /// Hedef dil ana dille aynı adı veriyorsa da null: "Müzik (Müzik)" bilgi
    /// taşımaz. Kullanıcının kendi kurduğu destede StarterKey olmadığı için
    /// zaten null döner — kendi yazdığı ada çeviri uydurulmuyor.
    /// </summary>
    private static string? NativeTitleFor(Deck deck, IReadOnlyDictionary<string, string> nativeTitles)
    {
        var slug = CategoryDeckSynchronizer.SlugFrom(deck.StarterKey);
        if (slug.Length == 0 || !nativeTitles.TryGetValue(slug, out var nativeTitle))
        {
            return null;
        }

        return string.Equals(nativeTitle, deck.Title, StringComparison.OrdinalIgnoreCase) ? null : nativeTitle;
    }

    /// <summary>
    /// Şablon başına emoji/renk, slug ile anahtarlı. Emoji ve renk dilden
    /// bağımsız olduğu için -- <see cref="NativeTitlesAsync"/>'in aksine --
    /// öğrenenin diline göre süzülmez, tüm şablonlar tek sorguda okunur.
    /// </summary>
    private async Task<Dictionary<string, (string Emoji, string ColorHex)>> VisualsAsync()
    {
        return await _unitOfWork.Repository<DeckTemplate>().Query()
            .ToDictionaryAsync(t => t.Slug, t => (t.Emoji, t.ColorHex));
    }

    /// <summary>
    /// Destenin emoji/rengi, yoksa null -- kullanıcının kendi kurduğu deste
    /// ve istemcinin "starter_" destelerinde şablon karşılığı olmadığı için
    /// zaten null döner; istemci o durumda kendi varsayılanını kullanır.
    /// </summary>
    private static (string Emoji, string ColorHex)? VisualFor(Deck deck, IReadOnlyDictionary<string, (string Emoji, string ColorHex)> visuals)
    {
        var slug = CategoryDeckSynchronizer.SlugFrom(deck.StarterKey);
        return slug.Length == 0 || !visuals.TryGetValue(slug, out var visual) ? null : visual;
    }

    private static (int CardCount, int DueCount, int StudyCount, double MasteryPercentage, int ReviewsCount) ComputeDeckStats(
        IReadOnlyCollection<Vocabulary> cards,
        IReadOnlyCollection<UserWordProgress> allProgress,
        DateTime now)
    {
        var wordIds = cards.Select(card => card.WordID).ToHashSet();
        // WordID null olan satırlar müfredat kavramlarına ait; deste
        // istatistikleri yalnızca kullanıcının kendi kartlarını sayar.
        var progress = allProgress.Where(p => p.WordID != null && wordIds.Contains(p.WordID.Value)).ToList();
        var progressByWord = progress.ToDictionary(p => p.WordID!.Value);

        // İlerleme kaydı olmayan kart hiç çalışılmamış demektir; "tekrar zamanı
        // geldi" değildir. İkisi ayrı durumlar: "due", süresi dolmuş bir önceki
        // tekrarı ima ediyor, oysa bu kart henüz hiç görülmedi. Eskiden böyle
        // kartlar da sayıldığı için hiç açılmamış her deste kart sayısının
        // tamamını "tekrar bekliyor" diye gösteriyordu — yani başlanmamış deste
        // ile biriktirmiş deste ekranda aynı görünüyordu. Yalnızca tekrar
        // geçmişi olan ve süresi dolmuş kartlar sayılır.
        var dueCount = cards.Count(card =>
            progressByWord.TryGetValue(card.WordID, out var p)
            && (p.NextReviewDate is null || p.NextReviewDate <= now));

        // Aynı kriter GetDueReviews'daki ile birebir aynı olmalı: bu alan
        // "Study" düğmesine basılırsa gerçekte kaç kart geleceğinin sözü,
        // dueCount'un aksine hiç çalışılmamış kartları da (progress kaydı
        // yok demek) sayar. İkisi kasıtlı olarak ayrışıyor -- bkz.
        // DeckSummaryDto.StudyCount'un kendi belgesi.
        var studyCount = cards.Count(card =>
            !progressByWord.TryGetValue(card.WordID, out var p)
            || p.NextReviewDate is null
            || p.NextReviewDate <= now);

        var masteryPercentage = cards.Count == 0
            ? 0
            : Math.Round(
                cards.Average(card =>
                    progressByWord.TryGetValue(card.WordID, out var p)
                        ? Math.Clamp(p.MasteryLevel, 0, 5) / 5.0 * 100.0
                        : 0),
                1);

        return (cards.Count, dueCount, studyCount, masteryPercentage, progress.Sum(p => p.ReviewCount));
    }

    private static object MapCard(Vocabulary card) => new
    {
        WordId = card.WordID,
        card.DeckId,
        card.Term,
        card.Translation,
        card.ExampleSentence,
        card.ImageUrl,
        card.AudioUrl,
        card.CreatedAt,
        card.UpdatedAt
    };

    private int? TryGetUserId()
    {
        var raw = User.FindFirstValue(ClaimTypes.NameIdentifier);
        return int.TryParse(raw, out var id) ? id : null;
    }
}
