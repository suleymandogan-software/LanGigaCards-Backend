using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
            return new DeckSummaryDto
            {
                Id = deck.Id,
                Title = deck.Title,
                Description = deck.Description,
                CoverImageUrl = deck.CoverImageUrl,
                StarterKey = deck.StarterKey,
                LanguageCode = deck.LanguageCode,
                CreatedAt = deck.CreatedAt,
                UpdatedAt = deck.UpdatedAt,
                CardCount = stats.CardCount,
                DueCount = stats.DueCount,
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

        var stats = ComputeDeckStats(cards, progress, DateTime.UtcNow);
        return Ok(new
        {
            deck.Id,
            deck.Title,
            deck.Description,
            deck.CoverImageUrl,
            deck.StarterKey,
            deck.LanguageCode,
            deck.CreatedAt,
            deck.UpdatedAt,
            stats.CardCount,
            stats.DueCount,
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
        foreach (var card in cards)
        {
            _unitOfWork.Repository<Vocabulary>().Delete(card);
        }

        _unitOfWork.Repository<Deck>().Delete(deck);
        await _unitOfWork.CompleteAsync();

        return NoContent();
    }

    private static (int CardCount, int DueCount, double MasteryPercentage, int ReviewsCount) ComputeDeckStats(
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

        var masteryPercentage = cards.Count == 0
            ? 0
            : Math.Round(
                cards.Average(card =>
                    progressByWord.TryGetValue(card.WordID, out var p)
                        ? Math.Clamp(p.MasteryLevel, 0, 5) / 5.0 * 100.0
                        : 0),
                1);

        return (cards.Count, dueCount, masteryPercentage, progress.Sum(p => p.ReviewCount));
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
