using Microsoft.EntityFrameworkCore;

namespace LanGigaCards.Api.Data;

/// <summary>
/// Kategori destelerinin şablon kataloğu: on beş kategori, şablon başına 36
/// kelime, on dilde.
///
/// <para>
/// Kelime metni ayrı bir şablon tablosunda değil, müfredatla aynı yerde durur:
/// her kelime bir <see cref="Concept"/>, dil başına bir
/// <see cref="ConceptTranslation"/>. Katalogdaki 540 kelimenin 167'si zaten
/// müfredatta bulunan bir terime denk geliyordu ("Computer", "Teacher",
/// "Ticket"...); bunlar için yeni kavram üretilmedi, mevcut kavrama eksik
/// dillerin çevirileri eklendi. Aksi halde aynı anlam iki kez görünür ve tekrar
/// kuyruğunda ayırt edilemeyen bir çift oluşurdu.
/// </para>
///
/// <para>
/// Şablonun hangi kavramları içerdiği <see cref="DeckTemplateConcept"/> ile
/// ayrıca yazılır, kategoriden türetilmez: katalogda bilerek başka kategoriden
/// alınmış kelimeler var (teknoloji destesindeki "Cloud" kavram olarak doğa
/// kategorisinde durur) ve aynı kavram birden çok şablonda geçebiliyor.
/// </para>
///
/// <para>
/// Kelimeler CEFR seviyesine ayrılmıştır: A1 10, A2 7, B1 6, B1+ 4, B2 4, C1 3,
/// C2 2. Dağılım bilerek tabana ağırlık verir; seviye birikimli okunduğu için
/// alt seviyeler her destenin zeminini oluşturur — A1 çalışan biri 10, B1
/// çalışan 27, C2 çalışan 36 kart alır.
/// </para>
///
/// <para>
/// Veri, okunabilirlik için sıkışık dizilerle yazılır ve <see cref="Apply"/>
/// içinde <c>HasData</c> satırlarına açılır; dil sırası
/// <see cref="LanguageOrder"/> ile sabittir.
/// </para>
/// </summary>
internal static class CategoryCatalogSeedData
{
    /// <summary>
    /// Aşağıdaki metin dizilerindeki dil sırası; <see cref="Language.Code"/>
    /// ile aynı ISO kodları.
    /// </summary>
    private static readonly string[] LanguageOrder =
        { "en", "tr", "es", "fr", "de", "it", "pt", "ja", "ko", "zh" };

    /// <summary>Müfredatta zaten bulunan bir kavrama eklenecek çeviriler.</summary>
    private sealed record MergedConcept(int ConceptId, string[] Texts);

    /// <summary>Yalnızca katalogda geçen kavram.</summary>
    private sealed record NewConcept(int Id, string Key, int CategoryId, string Level, int OrderIndex, string[] Texts);

    private sealed record TemplateSpec(
        int Id,
        string Slug,
        int CategoryId,
        string Emoji,
        string ColorHex,
        string[] Titles,
        string[] Descriptions,
        (int ConceptId, string CefrLevel)[] Members);
    /// <summary>
    /// Şablon kimlikleri elle verilir: <c>HasData</c> satırlarının migration'lar
    /// arasında yerinde kalması için sabit olmaları gerekir. Renk ve emoji
    /// Categories tablosundaki <c>ColorHex</c> ile hizalıdır.
    /// </summary>
    private static readonly TemplateSpec[] Templates =
    {
        new(1, "technology", 4, "💻", "#06B6D4",
            new[] { "Technology", "Teknoloji", "Tecnología", "Technologie", "Technik", "Tecnologia", "Tecnologia", "テクノロジー", "기술", "科技" },
            new[] { "Computers, phones and the internet", "Bilgisayarlar, telefonlar ve internet", "Ordenadores, teléfonos e internet", "Ordinateurs, téléphones et internet", "Computer, Handys und das Internet", "Computer, telefoni e internet", "Computadores, telefones e internet", "コンピューター、電話、インターネット", "컴퓨터, 전화 그리고 인터넷", "电脑、手机和互联网" },
            new[] { (155, "A1"), (10001, "A1"), (156, "A1"), (157, "A1"), (158, "A1"), (159, "A1"), (161, "A1"), (10002, "A1"), (10003, "A1"), (160, "A1"), (164, "A2"), (165, "A2"), (163, "A2"), (10004, "A2"), (10005, "A2"), (10006, "A2"), (10007, "A2"), (162, "B1"), (10008, "B1"), (10009, "B1"), (166, "B1"), (10010, "B1"), (10011, "B1"), (122, "B1+"), (10012, "B1+"), (10013, "B1+"), (10014, "B1+"), (10015, "B2"), (10016, "B2"), (10017, "B2"), (10018, "B2"), (10019, "C1"), (10020, "C1"), (10021, "C1"), (10022, "C2"), (10023, "C2") }),
        new(2, "education", 5, "🎓", "#8B5CF6",
            new[] { "Education", "Eğitim", "Educación", "Éducation", "Bildung", "Istruzione", "Educação", "教育", "교육", "教育" },
            new[] { "School, study and exams", "Okul, ders ve sınavlar", "Escuela, estudio y exámenes", "École, études et examens", "Schule, Lernen und Prüfungen", "Scuola, studio ed esami", "Escola, estudo e provas", "学校、勉強、そして試験", "학교, 공부 그리고 시험", "学校、学习和考试" },
            new[] { (86, "A1"), (87, "A1"), (88, "A1"), (89, "A1"), (90, "A1"), (10024, "A1"), (91, "A1"), (92, "A1"), (10025, "A1"), (10026, "A1"), (94, "A2"), (93, "A2"), (10027, "A2"), (10028, "A2"), (10029, "A2"), (10030, "A2"), (10031, "A2"), (10032, "B1"), (10033, "B1"), (252, "B1"), (10034, "B1"), (10035, "B1"), (10036, "B1"), (10037, "B1+"), (10038, "B1+"), (10039, "B1+"), (10040, "B1+"), (10041, "B2"), (10042, "B2"), (10043, "B2"), (10044, "B2"), (10045, "C1"), (10046, "C1"), (10047, "C1"), (10048, "C2"), (10049, "C2") }),
        new(3, "movies", 6, "🎬", "#EC4899",
            new[] { "Movies", "Filmler", "Películas", "Films", "Filme", "Film", "Filmes", "映画", "영화", "电影" },
            new[] { "Cinema, series and what to watch", "Sinema, diziler ve ne izlesek", "Cine, series y qué ver", "Cinéma, séries et quoi regarder", "Kino, Serien und was man schaut", "Cinema, serie e cosa guardare", "Cinema, séries e o que assistir", "映画、ドラマ、何を観るか", "영화, 드라마 그리고 무엇을 볼까", "电影、剧集和看什么" },
            new[] { (10050, "A1"), (265, "A1"), (73, "A1"), (264, "A1"), (231, "A1"), (269, "A1"), (271, "A1"), (10051, "A1"), (10052, "A1"), (10053, "A1"), (266, "A2"), (267, "A2"), (268, "A2"), (10054, "A2"), (274, "A2"), (10055, "A2"), (10056, "A2"), (10057, "B1"), (10058, "B1"), (10059, "B1"), (10060, "B1"), (10061, "B1"), (10062, "B1"), (10063, "B1+"), (10064, "B1+"), (10065, "B1+"), (10066, "B1+"), (10067, "B2"), (10068, "B2"), (10069, "B2"), (10070, "B2"), (10071, "C1"), (10072, "C1"), (10073, "C1"), (10074, "C2"), (10075, "C2") }),
        new(4, "music", 7, "🎵", "#F43F5E",
            new[] { "Music", "Müzik", "Música", "Musique", "Musik", "Musica", "Música", "音楽", "음악", "音乐" },
            new[] { "Songs, instruments and listening", "Şarkılar, çalgılar ve dinlemek", "Canciones, instrumentos y escuchar", "Chansons, instruments et écoute", "Lieder, Instrumente und Zuhören", "Canzoni, strumenti e ascolto", "Canções, instrumentos e ouvir", "歌、楽器、そして聴くこと", "노래, 악기 그리고 듣기", "歌曲、乐器和聆听" },
            new[] { (191, "A1"), (192, "A1"), (193, "A1"), (10076, "A1"), (10077, "A1"), (10078, "A1"), (194, "A1"), (10079, "A1"), (10080, "A1"), (10081, "A1"), (10082, "A2"), (199, "A2"), (10083, "A2"), (198, "A2"), (10084, "A2"), (200, "A2"), (10085, "A2"), (10086, "B1"), (10087, "B1"), (10088, "B1"), (10089, "B1"), (10090, "B1"), (10091, "B1"), (10092, "B1+"), (10066, "B1+"), (10093, "B1+"), (10094, "B1+"), (10095, "B2"), (10096, "B2"), (10097, "B2"), (10098, "B2"), (10099, "C1"), (10100, "C1"), (10101, "C1"), (10102, "C2"), (10103, "C2") }),
        new(5, "gaming", 8, "🎮", "#10B981",
            new[] { "Gaming", "Oyun", "Videojuegos", "Jeux vidéo", "Gaming", "Videogiochi", "Games", "ゲーム", "게임", "电子游戏" },
            new[] { "Video games and playing online", "Video oyunları ve çevrimiçi oynamak", "Videojuegos y jugar en línea", "Jeux vidéo et jouer en ligne", "Videospiele und Online-Spielen", "Videogiochi e giocare online", "Videogames e jogar online", "ビデオゲームとオンライン対戦", "비디오 게임과 온라인 플레이", "电子游戏和在线游玩" },
            new[] { (275, "A1"), (180, "A1"), (276, "A1"), (185, "A1"), (10104, "A1"), (10105, "A1"), (179, "A1"), (78, "A1"), (278, "A1"), (274, "A1"), (181, "A2"), (10106, "A2"), (279, "A2"), (10107, "A2"), (10108, "A2"), (280, "A2"), (10012, "A2"), (282, "B1"), (10109, "B1"), (10110, "B1"), (10111, "B1"), (10112, "B1"), (10113, "B1"), (284, "B1+"), (281, "B1+"), (10114, "B1+"), (10115, "B1+"), (10116, "B2"), (10117, "B2"), (10118, "B2"), (10119, "B2"), (10120, "C1"), (10121, "C1"), (10122, "C1"), (10123, "C2"), (10124, "C2") }),
        new(6, "sports", 9, "⚽", "#22C55E",
            new[] { "Sports", "Spor", "Deportes", "Sport", "Sport", "Sport", "Esportes", "スポーツ", "스포츠", "运动" },
            new[] { "Games, training and keeping fit", "Maçlar, antrenman ve forma girmek", "Partidos, entrenamiento y estar en forma", "Matchs, entraînement et forme physique", "Spiele, Training und Fitness", "Partite, allenamento e forma fisica", "Jogos, treino e ficar em forma", "試合、トレーニング、体づくり", "경기, 훈련 그리고 체력 관리", "比赛、训练和保持健康" },
            new[] { (10125, "A1"), (10126, "A1"), (10127, "A1"), (10128, "A1"), (179, "A1"), (181, "A1"), (180, "A1"), (10129, "A1"), (182, "A1"), (10130, "A1"), (183, "A2"), (186, "A2"), (184, "A2"), (188, "A2"), (187, "A2"), (10131, "A2"), (10132, "A2"), (10133, "B1"), (190, "B1"), (10134, "B1"), (10135, "B1"), (10136, "B1"), (10137, "B1"), (281, "B1+"), (10138, "B1+"), (10139, "B1+"), (10140, "B1+"), (10141, "B2"), (10142, "B2"), (10143, "B2"), (10144, "B2"), (10145, "C1"), (10146, "C1"), (10147, "C1"), (10148, "C2"), (10149, "C2") }),
        new(7, "health", 10, "❤️", "#EF4444",
            new[] { "Health", "Sağlık", "Salud", "Santé", "Gesundheit", "Salute", "Saúde", "健康", "건강", "健康" },
            new[] { "The body, feeling ill and the doctor", "Vücut, hastalık ve doktor", "El cuerpo, la enfermedad y el médico", "Le corps, la maladie et le médecin", "Körper, Krankheit und Arztbesuch", "Il corpo, la malattia e il medico", "O corpo, a doença e o médico", "体調と病院で使う言葉", "몸, 아플 때 그리고 병원", "身体、生病和看医生" },
            new[] { (100, "A1"), (101, "A1"), (102, "A1"), (103, "A1"), (104, "A1"), (10150, "A1"), (10151, "A1"), (10152, "A1"), (95, "A1"), (106, "A1"), (10153, "A2"), (10154, "A2"), (10155, "A2"), (10156, "A2"), (190, "A2"), (10157, "A2"), (10158, "A2"), (10159, "B1"), (10160, "B1"), (10161, "B1"), (10162, "B1"), (10163, "B1"), (10164, "B1"), (10165, "B1+"), (10166, "B1+"), (10167, "B1+"), (10168, "B1+"), (10169, "B2"), (10170, "B2"), (10171, "B2"), (10172, "B2"), (10173, "C1"), (10174, "C1"), (10175, "C1"), (10176, "C2"), (10177, "C2") }),
        new(8, "shopping", 11, "🛍️", "#F59E0B",
            new[] { "Shopping", "Alışveriş", "Compras", "Achats", "Einkaufen", "Shopping", "Compras", "買い物", "쇼핑", "购物" },
            new[] { "Buying, paying and what to wear", "Almak, ödemek ve ne giymek", "Comprar, pagar y qué ponerse", "Acheter, payer et quoi porter", "Kaufen, bezahlen und was man anzieht", "Comprare, pagare e cosa indossare", "Comprar, pagar e o que vestir", "買う、払う、何を着るか", "사고, 계산하고, 무엇을 입을까", "购买、付款和穿什么" },
            new[] { (143, "A1"), (118, "A1"), (148, "A1"), (10178, "A1"), (10179, "A1"), (10180, "A1"), (147, "A1"), (10181, "A1"), (151, "A1"), (150, "A1"), (144, "A2"), (145, "A2"), (146, "A2"), (149, "A2"), (10182, "A2"), (10183, "A2"), (10184, "A2"), (152, "B1"), (10185, "B1"), (10186, "B1"), (154, "B1"), (10187, "B1"), (10188, "B1"), (10189, "B1+"), (10190, "B1+"), (219, "B1+"), (10191, "B1+"), (10192, "B2"), (10193, "B2"), (10109, "B2"), (10194, "B2"), (10195, "C1"), (10196, "C1"), (10197, "C1"), (10198, "C2"), (10199, "C2") }),
        new(9, "nature", 13, "🌳", "#84CC16",
            new[] { "Nature", "Doğa", "Naturaleza", "Nature", "Natur", "Natura", "Natureza", "自然", "자연", "大自然" },
            new[] { "Weather, landscape and the outdoors", "Hava, manzara ve açık hava", "Clima, paisaje y aire libre", "Météo, paysage et plein air", "Wetter, Landschaft und Natur", "Tempo, paesaggio e aria aperta", "Clima, paisagem e ar livre", "天気、風景、そして戸外", "날씨, 풍경 그리고 야외", "天气、风景和户外" },
            new[] { (167, "A1"), (169, "A1"), (170, "A1"), (171, "A1"), (119, "A1"), (121, "A1"), (172, "A1"), (168, "A1"), (123, "A1"), (173, "A1"), (120, "A2"), (175, "A2"), (177, "A2"), (122, "A2"), (10200, "A2"), (174, "A2"), (176, "A2"), (10201, "B1"), (10202, "B1"), (178, "B1"), (10203, "B1"), (10204, "B1"), (10205, "B1"), (10206, "B1+"), (10207, "B1+"), (10208, "B1+"), (10209, "B1+"), (10210, "B2"), (10211, "B2"), (10212, "B2"), (10213, "B2"), (10214, "C1"), (10215, "C1"), (10216, "C1"), (10217, "C2"), (10218, "C2") }),
        new(10, "science", 14, "🔬", "#0EA5E9",
            new[] { "Science", "Bilim", "Ciencia", "Science", "Wissenschaft", "Scienza", "Ciência", "科学", "과학", "科学" },
            new[] { "Research, experiments and discovery", "Araştırma, deney ve keşif", "Investigación, experimentos y descubrimiento", "Recherche, expériences et découverte", "Forschung, Experimente und Entdeckung", "Ricerca, esperimenti e scoperta", "Pesquisa, experimentos e descoberta", "研究、実験、そして発見", "연구, 실험 그리고 발견", "研究、实验和发现" },
            new[] { (13, "A1"), (10219, "A1"), (10220, "A1"), (10221, "A1"), (10222, "A1"), (10223, "A1"), (10224, "A1"), (10225, "A1"), (10226, "A1"), (10227, "A1"), (255, "A2"), (259, "A2"), (253, "A2"), (10228, "A2"), (10229, "A2"), (10230, "A2"), (10231, "A2"), (252, "B1"), (256, "B1"), (257, "B1"), (254, "B1"), (10232, "B1"), (262, "B1"), (258, "B1+"), (10233, "B1+"), (10234, "B1+"), (10235, "B1+"), (10236, "B2"), (10237, "B2"), (10238, "B2"), (10239, "B2"), (10240, "C1"), (10241, "C1"), (10242, "C1"), (10243, "C2"), (10244, "C2") }),
        new(11, "animals", 15, "🐾", "#A855F7",
            new[] { "Animals", "Hayvanlar", "Animales", "Animaux", "Tiere", "Animali", "Animais", "動物", "동물", "动物" },
            new[] { "Pets, wild animals and their world", "Evcil hayvanlar, yabani hayvanlar ve dünyaları", "Mascotas, animales salvajes y su mundo", "Animaux de compagnie, animaux sauvages et leur monde", "Haustiere, wilde Tiere und ihre Welt", "Animali domestici, animali selvatici e il loro mondo", "Animais de estimação, animais selvagens e seu mundo", "ペット、野生動物、そしてその世界", "반려동물, 야생동물 그리고 그들의 세계", "宠物、野生动物和它们的世界" },
            new[] { (239, "A1"), (240, "A1"), (241, "A1"), (243, "A1"), (242, "A1"), (245, "A1"), (244, "A1"), (247, "A1"), (10245, "A1"), (246, "A1"), (250, "A2"), (10246, "A2"), (248, "A2"), (10247, "A2"), (10248, "A2"), (10249, "A2"), (10250, "A2"), (10251, "B1"), (10252, "B1"), (10253, "B1"), (10254, "B1"), (10255, "B1"), (10256, "B1"), (10257, "B1+"), (10258, "B1+"), (10259, "B1+"), (10260, "B1+"), (10261, "B2"), (10262, "B2"), (10263, "B2"), (10264, "B2"), (10265, "C1"), (10266, "C1"), (10267, "C1"), (10268, "C2"), (10269, "C2") }),
        new(12, "food", 1, "🍎", "#F97316",
            new[] { "Food & Drink", "Yiyecek ve İçecek", "Comida y bebida", "Nourriture et boissons", "Essen & Trinken", "Cibo e bevande", "Comida e bebida", "食べ物と飲み物", "음식과 음료", "食物和饮品" },
            new[] { "What you order, buy and cook", "Sipariş ettiğin, aldığın ve pişirdiğin şeyler", "Lo que pides, compras y cocinas", "Ce que vous commandez, achetez et cuisinez", "Was man bestellt, kauft und kocht", "Quello che ordini, compri e cucini", "O que você pede, compra e cozinha", "注文する、買う、そして作るもの", "주문하고, 사고, 요리하는 것", "你点的、买的和做的食物" },
            new[] { (15, "A1"), (17, "A1"), (16, "A1"), (18, "A1"), (19, "A1"), (20, "A1"), (242, "A1"), (22, "A1"), (21, "A1"), (23, "A1"), (14, "A2"), (13, "A2"), (24, "A2"), (10270, "A2"), (10271, "A2"), (10272, "A2"), (10273, "A2"), (203, "B1"), (10274, "B1"), (10275, "B1"), (10276, "B1"), (214, "B1"), (10277, "B1"), (10278, "B1+"), (10279, "B1+"), (10280, "B1+"), (10281, "B1+"), (10282, "B2"), (10283, "B2"), (10284, "B2"), (10285, "B2"), (10286, "C1"), (10287, "C1"), (10288, "C1"), (10289, "C2"), (10290, "C2") }),
        new(13, "travel", 2, "✈️", "#0EA5E9",
            new[] { "Travel & Directions", "Seyahat ve Yön Tarifi", "Viajes y direcciones", "Voyage et itinéraires", "Reisen & Wegbeschreibung", "Viaggi e indicazioni", "Viagem e direções", "旅行と道案内", "여행과 길 안내", "旅行和问路" },
            new[] { "Getting around a city you do not know yet", "Henüz tanımadığın bir şehirde yol bulmak", "Moverte por una ciudad que aún no conoces", "Se déplacer dans une ville qu'on ne connaît pas encore", "Sich in einer fremden Stadt zurechtfinden", "Muoversi in una città che non conosci ancora", "Circular por uma cidade que você ainda não conhece", "まだ知らない街での移動", "아직 모르는 도시에서 길 찾기", "在陌生城市里通行" },
            new[] { (71, "A1"), (72, "A1"), (73, "A1"), (74, "A1"), (78, "A1"), (75, "A1"), (76, "A1"), (117, "A1"), (81, "A1"), (10291, "A1"), (80, "A2"), (79, "A2"), (10292, "A2"), (10293, "A2"), (10294, "A2"), (10295, "A2"), (10296, "A2"), (10297, "B1"), (10298, "B1"), (10299, "B1"), (10300, "B1"), (224, "B1"), (10301, "B1"), (10302, "B1+"), (10303, "B1+"), (10304, "B1+"), (10305, "B1+"), (10306, "B2"), (10307, "B2"), (10308, "B2"), (10309, "B2"), (10310, "C1"), (10311, "C1"), (10312, "C1"), (10313, "C2"), (10314, "C2") }),
        new(14, "business", 3, "💼", "#6366F1",
            new[] { "Business Basics", "İş Hayatı Temelleri", "Fundamentos de negocios", "Bases du monde professionnel", "Business-Grundlagen", "Basi del business", "Fundamentos de negócios", "ビジネスの基本", "비즈니스 기초", "商务基础" },
            new[] { "The office, meetings, and getting work done", "Ofis, toplantılar ve günlük iş", "La oficina, las reuniones y el trabajo diario", "Le bureau, les réunions et le travail au quotidien", "Büro, Besprechungen und die tägliche Arbeit", "Ufficio, riunioni e lavoro quotidiano", "O escritório, as reuniões e o trabalho do dia a dia", "オフィス、会議、日々の仕事", "사무실, 회의 그리고 업무", "办公室、会议和日常工作" },
            new[] { (84, "A1"), (85, "A1"), (10315, "A1"), (10316, "A1"), (10317, "A1"), (10318, "A1"), (179, "A1"), (10319, "A1"), (10320, "A1"), (10321, "A1"), (10322, "A2"), (217, "A2"), (10323, "A2"), (10324, "A2"), (10325, "A2"), (10326, "A2"), (10327, "A2"), (10328, "B1"), (10038, "B1"), (10329, "B1"), (223, "B1"), (10330, "B1"), (10331, "B1"), (10332, "B1+"), (10333, "B1+"), (10334, "B1+"), (10335, "B1+"), (10336, "B2"), (10337, "B2"), (10338, "B2"), (10339, "B2"), (10340, "C1"), (10341, "C1"), (10342, "C1"), (10343, "C2"), (10344, "C2") }),
        new(15, "family", 12, "👨‍👩‍👧", "#14B8A6",
            new[] { "Family & People", "Aile ve İnsanlar", "Familia y personas", "Famille et personnes", "Familie & Menschen", "Famiglia e persone", "Família e pessoas", "家族と人々", "가족과 사람들", "家人与他人" },
            new[] { "The people around you", "Etrafındaki insanlar", "Las personas que te rodean", "Les gens qui vous entourent", "Die Menschen um dich herum", "Le persone intorno a te", "As pessoas à sua volta", "あなたのまわりの人たち", "당신 주변의 사람들", "你身边的人" },
            new[] { (49, "A1"), (50, "A1"), (51, "A1"), (52, "A1"), (58, "A1"), (60, "A1"), (55, "A1"), (56, "A1"), (10345, "A1"), (10346, "A1"), (59, "A2"), (10347, "A2"), (54, "A2"), (53, "A2"), (10348, "A2"), (10349, "A2"), (10350, "A2"), (10351, "B1"), (10352, "B1"), (10353, "B1"), (10354, "B1"), (10355, "B1"), (10356, "B1"), (10357, "B1+"), (10358, "B1+"), (10359, "B1+"), (10360, "B1+"), (10361, "B2"), (10362, "B2"), (10363, "B2"), (10364, "B2"), (10365, "C1"), (10366, "C1"), (10367, "C1"), (10368, "C2"), (10369, "C2") }),
    };

    /// <summary>
    /// Yalnızca katalogda geçen kavramlar. Kimlikler 10001'den başlar:
    /// müfredat 1..286 aralığını kullanıyor ve araya kavram eklemek onları
    /// kaydırmamalı.
    /// </summary>
    private static readonly NewConcept[] NewConcepts =
    {
        new(10001, "technology_phone", 4, "A1", 287, new[] { "Phone", "Telefon", "Teléfono", "Téléphone", "Telefon", "Telefono", "Telefone", "電話", "전화", "手机" }),
        new(10002, "technology_search", 4, "A1", 288, new[] { "Search", "Aramak", "Buscar", "Chercher", "Suchen", "Cercare", "Procurar", "検索", "검색", "搜索" }),
        new(10003, "technology_camera", 4, "A1", 289, new[] { "Camera", "Kamera", "Cámara", "Appareil photo", "Kamera", "Fotocamera", "Câmera", "カメラ", "카메라", "相机" }),
        new(10004, "technology_charger", 4, "A2", 290, new[] { "Charger", "Şarj aleti", "Cargador", "Chargeur", "Ladegerät", "Caricabatterie", "Carregador", "充電器", "충전기", "充电器" }),
        new(10005, "technology_website", 4, "A2", 291, new[] { "Website", "Web sitesi", "Sitio web", "Site web", "Webseite", "Sito web", "Site", "ウェブサイト", "웹사이트", "网站" }),
        new(10006, "technology_printer", 4, "A2", 292, new[] { "Printer", "Yazıcı", "Impresora", "Imprimante", "Drucker", "Stampante", "Impressora", "プリンター", "프린터", "打印机" }),
        new(10007, "technology_speaker", 4, "A2", 293, new[] { "Speaker", "Hoparlör", "Altavoz", "Haut-parleur", "Lautsprecher", "Altoparlante", "Alto-falante", "スピーカー", "스피커", "扬声器" }),
        new(10008, "technology_hardware", 4, "B1", 294, new[] { "Hardware", "Donanım", "Hardware", "Matériel", "Hardware", "Hardware", "Hardware", "ハードウェア", "하드웨어", "硬件" }),
        new(10009, "technology_backup", 4, "B1", 295, new[] { "Backup", "Yedek", "Copia de seguridad", "Sauvegarde", "Sicherung", "Backup", "Backup", "バックアップ", "백업", "备份" }),
        new(10010, "technology_setting", 4, "B1", 296, new[] { "Setting", "Ayar", "Ajuste", "Réglage", "Einstellung", "Impostazione", "Configuração", "設定", "설정", "设置" }),
        new(10011, "technology_browser", 4, "B1", 297, new[] { "Browser", "Tarayıcı", "Navegador", "Navigateur", "Browser", "Browser", "Navegador", "ブラウザ", "브라우저", "浏览器" }),
        new(10012, "technology_server", 4, "B1+", 298, new[] { "Server", "Sunucu", "Servidor", "Serveur", "Server", "Server", "Servidor", "サーバー", "서버", "服务器" }),
        new(10013, "technology_database", 4, "B1+", 299, new[] { "Database", "Veritabanı", "Base de datos", "Base de données", "Datenbank", "Database", "Banco de dados", "データベース", "데이터베이스", "数据库" }),
        new(10014, "technology_wireless", 4, "B1+", 300, new[] { "Wireless", "Kablosuz", "Inalámbrico", "Sans fil", "Drahtlos", "Senza fili", "Sem fio", "無線", "무선", "无线" }),
        new(10015, "technology_encryption", 4, "B2", 301, new[] { "Encryption", "Şifreleme", "Cifrado", "Chiffrement", "Verschlüsselung", "Crittografia", "Criptografia", "暗号化", "암호화", "加密" }),
        new(10016, "technology_bandwidth", 4, "B2", 302, new[] { "Bandwidth", "Bant genişliği", "Ancho de banda", "Bande passante", "Bandbreite", "Larghezza di banda", "Largura de banda", "帯域幅", "대역폭", "带宽" }),
        new(10017, "technology_interface", 4, "B2", 303, new[] { "Interface", "Arayüz", "Interfaz", "Interface", "Schnittstelle", "Interfaccia", "Interface", "インターフェース", "인터페이스", "界面" }),
        new(10018, "technology_firewall", 4, "B2", 304, new[] { "Firewall", "Güvenlik duvarı", "Cortafuegos", "Pare-feu", "Firewall", "Firewall", "Firewall", "ファイアウォール", "방화벽", "防火墙" }),
        new(10019, "technology_algorithm", 4, "C1", 305, new[] { "Algorithm", "Algoritma", "Algoritmo", "Algorithme", "Algorithmus", "Algoritmo", "Algoritmo", "アルゴリズム", "알고리즘", "算法" }),
        new(10020, "technology_compatibility", 4, "C1", 306, new[] { "Compatibility", "Uyumluluk", "Compatibilidad", "Compatibilité", "Kompatibilität", "Compatibilità", "Compatibilidade", "互換性", "호환성", "兼容性" }),
        new(10021, "technology_deployment", 4, "C1", 307, new[] { "Deployment", "Dağıtım", "Despliegue", "Déploiement", "Bereitstellung", "Distribuzione", "Implantação", "展開", "배포", "部署" }),
        new(10022, "technology_redundancy", 4, "C2", 308, new[] { "Redundancy", "Yedeklilik", "Redundancia", "Redondance", "Redundanz", "Ridondanza", "Redundância", "冗長性", "이중화", "冗余" }),
        new(10023, "technology_latency", 4, "C2", 309, new[] { "Latency", "Gecikme", "Latencia", "Latence", "Latenz", "Latenza", "Latência", "遅延", "지연 시간", "延迟" }),
        new(10024, "education_notebook", 5, "A1", 310, new[] { "Notebook", "Defter", "Cuaderno", "Cahier", "Heft", "Quaderno", "Caderno", "ノート", "공책", "笔记本" }),
        new(10025, "education_lesson", 5, "A1", 311, new[] { "Lesson", "Ders", "Lección", "Leçon", "Unterricht", "Lezione", "Aula", "授業", "수업", "课" }),
        new(10026, "education_classroom", 5, "A1", 312, new[] { "Classroom", "Sınıf", "Aula", "Salle de classe", "Klassenzimmer", "Aula", "Sala de aula", "教室", "교실", "教室" }),
        new(10027, "education_library", 5, "A2", 313, new[] { "Library", "Kütüphane", "Biblioteca", "Bibliothèque", "Bibliothek", "Biblioteca", "Biblioteca", "図書館", "도서관", "图书馆" }),
        new(10028, "education_grade", 5, "A2", 314, new[] { "Grade", "Not", "Nota", "Note", "Note", "Voto", "Nota", "成績", "성적", "成绩" }),
        new(10029, "education_subject", 5, "A2", 315, new[] { "Subject", "Konu", "Asignatura", "Matière", "Fach", "Materia", "Matéria", "科目", "과목", "科目" }),
        new(10030, "education_dictionary", 5, "A2", 316, new[] { "Dictionary", "Sözlük", "Diccionario", "Dictionnaire", "Wörterbuch", "Dizionario", "Dicionário", "辞書", "사전", "词典" }),
        new(10031, "education_break", 5, "A2", 317, new[] { "Break", "Teneffüs", "Recreo", "Récréation", "Pause", "Ricreazione", "Recreio", "休み時間", "쉬는 시간", "课间休息" }),
        new(10032, "education_university", 5, "B1", 318, new[] { "University", "Üniversite", "Universidad", "Université", "Universität", "Università", "Universidade", "大学", "대학교", "大学" }),
        new(10033, "education_degree", 5, "B1", 319, new[] { "Degree", "Diploma", "Título", "Diplôme", "Abschluss", "Laurea", "Diploma", "学位", "학위", "学位" }),
        new(10034, "education_essay", 5, "B1", 320, new[] { "Essay", "Deneme", "Ensayo", "Dissertation", "Aufsatz", "Saggio", "Redação", "小論文", "에세이", "论文" }),
        new(10035, "education_attendance", 5, "B1", 321, new[] { "Attendance", "Devam", "Asistencia", "Présence", "Anwesenheit", "Presenza", "Frequência", "出席", "출석", "出勤" }),
        new(10036, "education_scholarship", 5, "B1", 322, new[] { "Scholarship", "Burs", "Beca", "Bourse", "Stipendium", "Borsa di studio", "Bolsa", "奨学金", "장학금", "奖学金" }),
        new(10037, "education_curriculum", 5, "B1+", 323, new[] { "Curriculum", "Müfredat", "Plan de estudios", "Programme", "Lehrplan", "Programma di studi", "Currículo", "カリキュラム", "교육과정", "课程" }),
        new(10038, "education_deadline", 5, "B1+", 324, new[] { "Deadline", "Son teslim tarihi", "Fecha límite", "Date limite", "Frist", "Scadenza", "Prazo", "締め切り", "마감일", "截止日期" }),
        new(10039, "education_semester", 5, "B1+", 325, new[] { "Semester", "Dönem", "Semestre", "Semestre", "Semester", "Semestre", "Semestre", "学期", "학기", "学期" }),
        new(10040, "education_tutor", 5, "B1+", 326, new[] { "Tutor", "Özel öğretmen", "Tutor", "Tuteur", "Nachhilfelehrer", "Tutor", "Tutor", "家庭教師", "과외 교사", "家教" }),
        new(10041, "education_thesis", 5, "B2", 327, new[] { "Thesis", "Tez", "Tesis", "Thèse", "Abschlussarbeit", "Tesi", "Tese", "論文", "논문", "论文" }),
        new(10042, "education_lecture", 5, "B2", 328, new[] { "Lecture", "Konferans", "Conferencia", "Cours magistral", "Vorlesung", "Lezione magistrale", "Palestra", "講義", "강의", "讲座" }),
        new(10043, "education_assessment", 5, "B2", 329, new[] { "Assessment", "Değerlendirme", "Evaluación", "Évaluation", "Bewertung", "Valutazione", "Avaliação", "評価", "평가", "评估" }),
        new(10044, "education_enrolment", 5, "B2", 330, new[] { "Enrolment", "Kayıt", "Matrícula", "Inscription", "Einschreibung", "Iscrizione", "Matrícula", "登録", "등록", "注册" }),
        new(10045, "education_pedagogy", 5, "C1", 331, new[] { "Pedagogy", "Pedagoji", "Pedagogía", "Pédagogie", "Pädagogik", "Pedagogia", "Pedagogia", "教育学", "교육학", "教育学" }),
        new(10046, "education_accreditation", 5, "C1", 332, new[] { "Accreditation", "Akreditasyon", "Acreditación", "Accréditation", "Akkreditierung", "Accreditamento", "Acreditação", "認定", "인증", "认证" }),
        new(10047, "education_dissertation", 5, "C1", 333, new[] { "Dissertation", "Doktora tezi", "Tesis doctoral", "Thèse de doctorat", "Dissertation", "Tesi di dottorato", "Dissertação", "博士論文", "박사 논문", "博士论文" }),
        new(10048, "education_cognition", 5, "C2", 334, new[] { "Cognition", "Biliş", "Cognición", "Cognition", "Kognition", "Cognizione", "Cognição", "認知", "인지", "认知" }),
        new(10049, "education_epistemology", 5, "C2", 335, new[] { "Epistemology", "Epistemoloji", "Epistemología", "Épistémologie", "Erkenntnistheorie", "Epistemologia", "Epistemologia", "認識論", "인식론", "认识论" }),
        new(10050, "movies_movie", 6, "A1", 336, new[] { "Movie", "Film", "Película", "Film", "Film", "Film", "Filme", "映画", "영화", "电影" }),
        new(10051, "movies_seat", 6, "A1", 337, new[] { "Seat", "Koltuk", "Asiento", "Siège", "Sitzplatz", "Posto", "Assento", "座席", "좌석", "座位" }),
        new(10052, "movies_popcorn", 6, "A1", 338, new[] { "Popcorn", "Patlamış mısır", "Palomitas", "Pop-corn", "Popcorn", "Popcorn", "Pipoca", "ポップコーン", "팝콘", "爆米花" }),
        new(10053, "movies_poster", 6, "A1", 339, new[] { "Poster", "Afiş", "Cartel", "Affiche", "Plakat", "Locandina", "Cartaz", "ポスター", "포스터", "海报" }),
        new(10054, "movies_award", 6, "A2", 340, new[] { "Award", "Ödül", "Premio", "Prix", "Preis", "Premio", "Prêmio", "賞", "상", "奖" }),
        new(10055, "movies_horror", 6, "A2", 341, new[] { "Horror", "Korku", "Terror", "Horreur", "Horror", "Horror", "Terror", "ホラー", "공포", "恐怖" }),
        new(10056, "movies_trailer", 6, "A2", 342, new[] { "Trailer", "Fragman", "Tráiler", "Bande-annonce", "Trailer", "Trailer", "Trailer", "予告編", "예고편", "预告片" }),
        new(10057, "movies_script", 6, "B1", 343, new[] { "Script", "Senaryo", "Guion", "Scénario", "Drehbuch", "Sceneggiatura", "Roteiro", "脚本", "각본", "剧本" }),
        new(10058, "movies_producer", 6, "B1", 344, new[] { "Producer", "Yapımcı", "Productor", "Producteur", "Produzent", "Produttore", "Produtor", "プロデューサー", "프로듀서", "制片人" }),
        new(10059, "movies_plot", 6, "B1", 345, new[] { "Plot", "Olay örgüsü", "Trama", "Intrigue", "Handlung", "Trama", "Enredo", "筋書き", "줄거리", "情节" }),
        new(10060, "movies_soundtrack", 6, "B1", 346, new[] { "Soundtrack", "Film müziği", "Banda sonora", "Bande originale", "Filmmusik", "Colonna sonora", "Trilha sonora", "サウンドトラック", "사운드트랙", "原声带" }),
        new(10061, "movies_review", 6, "B1", 347, new[] { "Review", "Eleştiri", "Reseña", "Critique", "Kritik", "Recensione", "Crítica", "レビュー", "리뷰", "影评" }),
        new(10062, "movies_sequel", 6, "B1", 348, new[] { "Sequel", "Devam filmi", "Secuela", "Suite", "Fortsetzung", "Sequel", "Continuação", "続編", "속편", "续集" }),
        new(10063, "movies_documentary", 6, "B1+", 349, new[] { "Documentary", "Belgesel", "Documental", "Documentaire", "Dokumentarfilm", "Documentario", "Documentário", "ドキュメンタリー", "다큐멘터리", "纪录片" }),
        new(10064, "movies_cast", 6, "B1+", 350, new[] { "Cast", "Oyuncu kadrosu", "Reparto", "Distribution", "Besetzung", "Cast", "Elenco", "キャスト", "출연진", "演员阵容" }),
        new(10065, "movies_premiere", 6, "B1+", 351, new[] { "Premiere", "Gala", "Estreno", "Première", "Premiere", "Prima", "Estreia", "初公開", "개봉", "首映" }),
        new(10066, "movies_genre", 6, "B1+", 352, new[] { "Genre", "Tür", "Género", "Genre", "Genre", "Genere", "Gênero", "ジャンル", "장르", "类型" }),
        new(10067, "movies_cinematography", 6, "B2", 353, new[] { "Cinematography", "Sinematografi", "Cinematografía", "Photographie", "Kameraführung", "Fotografia", "Fotografia", "撮影技術", "촬영 기법", "摄影" }),
        new(10068, "movies_adaptation", 6, "B2", 354, new[] { "Adaptation", "Uyarlama", "Adaptación", "Adaptation", "Verfilmung", "Adattamento", "Adaptação", "脚色", "각색", "改编" }),
        new(10069, "movies_box_office", 6, "B2", 355, new[] { "Box office", "Gişe", "Taquilla", "Box-office", "Kasse", "Botteghino", "Bilheteria", "興行収入", "흥행 수입", "票房" }),
        new(10070, "movies_editing", 6, "B2", 356, new[] { "Editing", "Kurgu", "Montaje", "Montage", "Schnitt", "Montaggio", "Montagem", "編集", "편집", "剪辑" }),
        new(10071, "movies_protagonist", 6, "C1", 357, new[] { "Protagonist", "Başkahraman", "Protagonista", "Protagoniste", "Protagonist", "Protagonista", "Protagonista", "主人公", "주인공", "主角" }),
        new(10072, "movies_narrative", 6, "C1", 358, new[] { "Narrative", "Anlatı", "Narrativa", "Récit", "Erzählung", "Narrazione", "Narrativa", "語り", "서사", "叙事" }),
        new(10073, "movies_cameo", 6, "C1", 359, new[] { "Cameo", "Konuk oyunculuk", "Cameo", "Caméo", "Cameo-Auftritt", "Cameo", "Participação especial", "カメオ出演", "카메오", "客串" }),
        new(10074, "movies_allegory", 6, "C2", 360, new[] { "Allegory", "Alegori", "Alegoría", "Allégorie", "Allegorie", "Allegoria", "Alegoria", "寓意", "우화", "寓言" }),
        new(10075, "movies_denouement", 6, "C2", 361, new[] { "Denouement", "Çözülme", "Desenlace", "Dénouement", "Auflösung", "Scioglimento", "Desenlace", "大詰め", "대단원", "结局" }),
        new(10076, "music_piano", 7, "A1", 362, new[] { "Piano", "Piyano", "Piano", "Piano", "Klavier", "Pianoforte", "Piano", "ピアノ", "피아노", "钢琴" }),
        new(10077, "music_drum", 7, "A1", 363, new[] { "Drum", "Davul", "Tambor", "Tambour", "Trommel", "Tamburo", "Tambor", "太鼓", "드럼", "鼓" }),
        new(10078, "music_voice", 7, "A1", 364, new[] { "Voice", "Ses", "Voz", "Voix", "Stimme", "Voce", "Voz", "声", "목소리", "嗓音" }),
        new(10079, "music_band", 7, "A1", 365, new[] { "Band", "Grup", "Banda", "Groupe", "Band", "Gruppo", "Banda", "バンド", "밴드", "乐队" }),
        new(10080, "music_violin", 7, "A1", 366, new[] { "Violin", "Keman", "Violín", "Violon", "Geige", "Violino", "Violino", "バイオリン", "바이올린", "小提琴" }),
        new(10081, "music_flute", 7, "A1", 367, new[] { "Flute", "Flüt", "Flauta", "Flûte", "Flöte", "Flauto", "Flauta", "フルート", "플루트", "长笛" }),
        new(10082, "music_lyrics", 7, "A2", 368, new[] { "Lyrics", "Söz", "Letra", "Paroles", "Liedtext", "Testo", "Letra", "歌詞", "가사", "歌词" }),
        new(10083, "music_album", 7, "A2", 369, new[] { "Album", "Albüm", "Álbum", "Album", "Album", "Album", "Álbum", "アルバム", "앨범", "专辑" }),
        new(10084, "music_melody", 7, "A2", 370, new[] { "Melody", "Melodi", "Melodía", "Mélodie", "Melodie", "Melodia", "Melodia", "旋律", "멜로디", "旋律" }),
        new(10085, "music_dance", 7, "A2", 371, new[] { "Dance", "Dans", "Baile", "Danse", "Tanz", "Danza", "Dança", "ダンス", "춤", "舞蹈" }),
        new(10086, "music_composer", 7, "B1", 372, new[] { "Composer", "Besteci", "Compositor", "Compositeur", "Komponist", "Compositore", "Compositor", "作曲家", "작곡가", "作曲家" }),
        new(10087, "music_orchestra", 7, "B1", 373, new[] { "Orchestra", "Orkestra", "Orquesta", "Orchestre", "Orchester", "Orchestra", "Orquestra", "オーケストラ", "오케스트라", "管弦乐团" }),
        new(10088, "music_chorus", 7, "B1", 374, new[] { "Chorus", "Nakarat", "Estribillo", "Refrain", "Refrain", "Ritornello", "Refrão", "サビ", "후렴", "副歌" }),
        new(10089, "music_instrument", 7, "B1", 375, new[] { "Instrument", "Enstrüman", "Instrumento", "Instrument", "Instrument", "Strumento", "Instrumento", "楽器", "악기", "乐器" }),
        new(10090, "music_rehearsal", 7, "B1", 376, new[] { "Rehearsal", "Prova", "Ensayo", "Répétition", "Probe", "Prova", "Ensaio", "リハーサル", "리허설", "排练" }),
        new(10091, "music_tune", 7, "B1", 377, new[] { "Tune", "Ezgi", "Tonada", "Air", "Weise", "Motivo", "Melodia", "曲調", "곡조", "曲调" }),
        new(10092, "music_harmony", 7, "B1+", 378, new[] { "Harmony", "Armoni", "Armonía", "Harmonie", "Harmonie", "Armonia", "Harmonia", "ハーモニー", "화음", "和声" }),
        new(10093, "music_performance", 7, "B1+", 379, new[] { "Performance", "Performans", "Actuación", "Représentation", "Auftritt", "Esibizione", "Apresentação", "演奏", "공연", "演出" }),
        new(10094, "music_recording", 7, "B1+", 380, new[] { "Recording", "Kayıt", "Grabación", "Enregistrement", "Aufnahme", "Registrazione", "Gravação", "録音", "녹음", "录音" }),
        new(10095, "music_improvisation", 7, "B2", 381, new[] { "Improvisation", "Doğaçlama", "Improvisación", "Improvisation", "Improvisation", "Improvvisazione", "Improvisação", "即興", "즉흥 연주", "即兴" }),
        new(10096, "music_acoustics", 7, "B2", 382, new[] { "Acoustics", "Akustik", "Acústica", "Acoustique", "Akustik", "Acustica", "Acústica", "音響", "음향", "声学" }),
        new(10097, "music_arrangement", 7, "B2", 383, new[] { "Arrangement", "Düzenleme", "Arreglo", "Arrangement", "Arrangement", "Arrangiamento", "Arranjo", "編曲", "편곡", "编曲" }),
        new(10098, "music_pitch", 7, "B2", 384, new[] { "Pitch", "Perde", "Tono", "Hauteur", "Tonhöhe", "Intonazione", "Afinação", "音程", "음높이", "音高" }),
        new(10099, "music_counterpoint", 7, "C1", 385, new[] { "Counterpoint", "Kontrpuan", "Contrapunto", "Contrepoint", "Kontrapunkt", "Contrappunto", "Contraponto", "対位法", "대위법", "对位法" }),
        new(10100, "music_timbre", 7, "C1", 386, new[] { "Timbre", "Tını", "Timbre", "Timbre", "Klangfarbe", "Timbro", "Timbre", "音色", "음색", "音色" }),
        new(10101, "music_resonance", 7, "C1", 387, new[] { "Resonance", "Rezonans", "Resonancia", "Résonance", "Resonanz", "Risonanza", "Ressonância", "共鳴", "공명", "共鸣" }),
        new(10102, "music_polyphony", 7, "C2", 388, new[] { "Polyphony", "Çokseslilik", "Polifonía", "Polyphonie", "Polyphonie", "Polifonia", "Polifonia", "多声音楽", "다성음악", "复调" }),
        new(10103, "music_cadence", 7, "C2", 389, new[] { "Cadence", "Kadans", "Cadencia", "Cadence", "Kadenz", "Cadenza", "Cadência", "終止形", "종지", "终止式" }),
        new(10104, "gaming_win", 8, "A1", 390, new[] { "Win", "Kazanmak", "Ganar", "Gagner", "Gewinnen", "Vincere", "Ganhar", "勝つ", "이기다", "赢" }),
        new(10105, "gaming_lose", 8, "A1", 391, new[] { "Lose", "Kaybetmek", "Perder", "Perdre", "Verlieren", "Perdere", "Perder", "負ける", "지다", "输" }),
        new(10106, "gaming_weapon", 8, "A2", 392, new[] { "Weapon", "Silah", "Arma", "Arme", "Waffe", "Arma", "Arma", "武器", "무기", "武器" }),
        new(10107, "gaming_health", 8, "A2", 393, new[] { "Health", "Can", "Salud", "Santé", "Leben", "Salute", "Vida", "体力", "체력", "生命值" }),
        new(10108, "gaming_speed", 8, "A2", 394, new[] { "Speed", "Hız", "Velocidad", "Vitesse", "Geschwindigkeit", "Velocità", "Velocidade", "速度", "속도", "速度" }),
        new(10109, "gaming_inventory", 8, "B1", 395, new[] { "Inventory", "Envanter", "Inventario", "Inventaire", "Inventar", "Inventario", "Inventário", "持ち物", "인벤토리", "背包" }),
        new(10110, "gaming_checkpoint", 8, "B1", 396, new[] { "Checkpoint", "Kontrol noktası", "Punto de control", "Point de contrôle", "Kontrollpunkt", "Checkpoint", "Ponto de salvamento", "チェックポイント", "체크포인트", "存档点" }),
        new(10111, "gaming_skill", 8, "B1", 397, new[] { "Skill", "Yetenek", "Habilidad", "Compétence", "Fähigkeit", "Abilità", "Habilidade", "スキル", "스킬", "技能" }),
        new(10112, "gaming_upgrade", 8, "B1", 398, new[] { "Upgrade", "Yükseltme", "Mejora", "Amélioration", "Verbesserung", "Potenziamento", "Melhoria", "アップグレード", "업그레이드", "升级" }),
        new(10113, "gaming_lag", 8, "B1", 399, new[] { "Lag", "Gecikme", "Retardo", "Latence", "Verzögerung", "Ritardo", "Atraso", "ラグ", "렉", "延迟" }),
        new(10114, "gaming_difficulty", 8, "B1+", 400, new[] { "Difficulty", "Zorluk", "Dificultad", "Difficulté", "Schwierigkeit", "Difficoltà", "Dificuldade", "難易度", "난이도", "难度" }),
        new(10115, "gaming_respawn", 8, "B1+", 401, new[] { "Respawn", "Yeniden doğma", "Reaparición", "Réapparition", "Wiedereinstieg", "Rinascita", "Renascimento", "復活", "리스폰", "重生" }),
        new(10116, "gaming_matchmaking", 8, "B2", 402, new[] { "Matchmaking", "Eşleştirme", "Emparejamiento", "Matchmaking", "Spielersuche", "Matchmaking", "Emparelhamento", "マッチメイキング", "매치메이킹", "匹配" }),
        new(10117, "gaming_leaderboard", 8, "B2", 403, new[] { "Leaderboard", "Sıralama tablosu", "Clasificación", "Classement", "Bestenliste", "Classifica", "Placar", "ランキング", "순위표", "排行榜" }),
        new(10118, "gaming_expansion", 8, "B2", 404, new[] { "Expansion", "Genişleme paketi", "Expansión", "Extension", "Erweiterung", "Espansione", "Expansão", "拡張版", "확장팩", "资料片" }),
        new(10119, "gaming_cooperative", 8, "B2", 405, new[] { "Cooperative", "İşbirlikçi", "Cooperativo", "Coopératif", "Kooperativ", "Cooperativo", "Cooperativo", "協力プレイ", "협동", "合作" }),
        new(10120, "gaming_immersion", 8, "C1", 406, new[] { "Immersion", "Kendini kaptırma", "Inmersión", "Immersion", "Immersion", "Immersione", "Imersão", "没入感", "몰입", "沉浸感" }),
        new(10121, "gaming_mechanics", 8, "C1", 407, new[] { "Mechanics", "Oyun mekanikleri", "Mecánicas", "Mécaniques", "Spielmechanik", "Meccaniche", "Mecânicas", "ゲーム性", "게임 메커니즘", "玩法机制" }),
        new(10122, "gaming_rendering", 8, "C1", 408, new[] { "Rendering", "Görüntüleme", "Renderizado", "Rendu", "Darstellung", "Rendering", "Renderização", "描画", "렌더링", "渲染" }),
        new(10123, "gaming_procedural", 8, "C2", 409, new[] { "Procedural", "Yordamsal", "Procedimental", "Procédural", "Prozedural", "Procedurale", "Procedural", "自動生成の", "절차적", "程序化" }),
        new(10124, "gaming_emergent", 8, "C2", 410, new[] { "Emergent", "Kendiliğinden beliren", "Emergente", "Émergent", "Emergent", "Emergente", "Emergente", "創発的", "창발적", "涌现的" }),
        new(10125, "sports_football", 9, "A1", 411, new[] { "Football", "Futbol", "Fútbol", "Football", "Fußball", "Calcio", "Futebol", "サッカー", "축구", "足球" }),
        new(10126, "sports_ball", 9, "A1", 412, new[] { "Ball", "Top", "Pelota", "Balle", "Ball", "Palla", "Bola", "ボール", "공", "球" }),
        new(10127, "sports_run", 9, "A1", 413, new[] { "Run", "Koşmak", "Correr", "Courir", "Laufen", "Correre", "Correr", "走る", "달리다", "跑" }),
        new(10128, "sports_swim", 9, "A1", 414, new[] { "Swim", "Yüzmek", "Nadar", "Nager", "Schwimmen", "Nuotare", "Nadar", "泳ぐ", "수영하다", "游泳" }),
        new(10129, "sports_jump", 9, "A1", 415, new[] { "Jump", "Zıplamak", "Saltar", "Sauter", "Springen", "Saltare", "Pular", "跳ぶ", "뛰다", "跳" }),
        new(10130, "sports_bicycle", 9, "A1", 416, new[] { "Bicycle", "Bisiklet", "Bicicleta", "Vélo", "Fahrrad", "Bicicletta", "Bicicleta", "自転車", "자전거", "自行车" }),
        new(10131, "sports_muscle", 9, "A2", 417, new[] { "Muscle", "Kas", "Músculo", "Muscle", "Muskel", "Muscolo", "Músculo", "筋肉", "근육", "肌肉" }),
        new(10132, "sports_race", 9, "A2", 418, new[] { "Race", "Yarış", "Carrera", "Course", "Rennen", "Corsa", "Corrida", "レース", "경주", "赛跑" }),
        new(10133, "sports_championship", 9, "B1", 419, new[] { "Championship", "Şampiyona", "Campeonato", "Championnat", "Meisterschaft", "Campionato", "Campeonato", "選手権", "선수권", "锦标赛" }),
        new(10134, "sports_fitness", 9, "B1", 420, new[] { "Fitness", "Kondisyon", "Forma física", "Condition physique", "Fitness", "Forma fisica", "Condicionamento", "体力づくり", "체력", "健身" }),
        new(10135, "sports_defence", 9, "B1", 421, new[] { "Defence", "Savunma", "Defensa", "Défense", "Verteidigung", "Difesa", "Defesa", "守備", "수비", "防守" }),
        new(10136, "sports_attack", 9, "B1", 422, new[] { "Attack", "Hücum", "Ataque", "Attaque", "Angriff", "Attacco", "Ataque", "攻撃", "공격", "进攻" }),
        new(10137, "sports_endurance", 9, "B1", 423, new[] { "Endurance", "Dayanıklılık", "Resistencia", "Endurance", "Ausdauer", "Resistenza", "Resistência", "持久力", "지구력", "耐力" }),
        new(10138, "sports_substitute", 9, "B1+", 424, new[] { "Substitute", "Yedek oyuncu", "Suplente", "Remplaçant", "Auswechselspieler", "Riserva", "Reserva", "控え選手", "교체 선수", "替补" }),
        new(10139, "sports_penalty", 9, "B1+", 425, new[] { "Penalty", "Ceza", "Penalti", "Pénalité", "Strafstoß", "Rigore", "Pênalti", "ペナルティ", "페널티", "点球" }),
        new(10140, "sports_warm_up", 9, "B1+", 426, new[] { "Warm-up", "Isınma", "Calentamiento", "Échauffement", "Aufwärmen", "Riscaldamento", "Aquecimento", "ウォームアップ", "준비 운동", "热身" }),
        new(10141, "sports_stamina", 9, "B2", 427, new[] { "Stamina", "Dayanma gücü", "Aguante", "Endurance physique", "Kondition", "Vigore", "Vigor", "スタミナ", "스태미나", "体能" }),
        new(10142, "sports_tactics", 9, "B2", 428, new[] { "Tactics", "Taktik", "Táctica", "Tactique", "Taktik", "Tattica", "Tática", "戦術", "전술", "战术" }),
        new(10143, "sports_qualification", 9, "B2", 429, new[] { "Qualification", "Eleme", "Clasificación", "Qualification", "Qualifikation", "Qualificazione", "Classificação", "予選", "예선", "资格赛" }),
        new(10144, "sports_doping", 9, "B2", 430, new[] { "Doping", "Doping", "Dopaje", "Dopage", "Doping", "Doping", "Doping", "ドーピング", "도핑", "兴奋剂" }),
        new(10145, "sports_rehabilitation", 9, "C1", 431, new[] { "Rehabilitation", "Rehabilitasyon", "Rehabilitación", "Rééducation", "Rehabilitation", "Riabilitazione", "Reabilitação", "リハビリ", "재활", "康复" }),
        new(10146, "sports_aerobic", 9, "C1", 432, new[] { "Aerobic", "Aerobik", "Aeróbico", "Aérobie", "Aerob", "Aerobico", "Aeróbico", "有酸素の", "유산소", "有氧" }),
        new(10147, "sports_momentum", 9, "C1", 433, new[] { "Momentum", "İvme", "Impulso", "Élan", "Schwung", "Slancio", "Impulso", "勢い", "기세", "势头" }),
        new(10148, "sports_periodisation", 9, "C2", 434, new[] { "Periodisation", "Periyotlama", "Periodización", "Périodisation", "Periodisierung", "Periodizzazione", "Periodização", "期分け", "주기화", "周期化" }),
        new(10149, "sports_biomechanics", 9, "C2", 435, new[] { "Biomechanics", "Biyomekanik", "Biomecánica", "Biomécanique", "Biomechanik", "Biomeccanica", "Biomecânica", "生体力学", "생체역학", "生物力学" }),
        new(10150, "health_nurse", 10, "A1", 436, new[] { "Nurse", "Hemşire", "Enfermera", "Infirmière", "Krankenschwester", "Infermiera", "Enfermeira", "看護師", "간호사", "护士" }),
        new(10151, "health_sleep", 10, "A1", 437, new[] { "Sleep", "Uyku", "Sueño", "Sommeil", "Schlaf", "Sonno", "Sono", "睡眠", "잠", "睡眠" }),
        new(10152, "health_blood", 10, "A1", 438, new[] { "Blood", "Kan", "Sangre", "Sang", "Blut", "Sangue", "Sangue", "血", "피", "血" }),
        new(10153, "health_healthy", 10, "A2", 439, new[] { "Healthy", "Sağlıklı", "Sano", "Sain", "Gesund", "Sano", "Saudável", "健康な", "건강한", "健康的" }),
        new(10154, "health_appointment", 10, "A2", 440, new[] { "Appointment", "Randevu", "Cita", "Rendez-vous", "Termin", "Appuntamento", "Consulta", "予約", "예약", "预约" }),
        new(10155, "health_cough", 10, "A2", 441, new[] { "Cough", "Öksürük", "Tos", "Toux", "Husten", "Tosse", "Tosse", "せき", "기침", "咳嗽" }),
        new(10156, "health_pharmacy", 10, "A2", 442, new[] { "Pharmacy", "Eczane", "Farmacia", "Pharmacie", "Apotheke", "Farmacia", "Farmácia", "薬局", "약국", "药店" }),
        new(10157, "health_diet", 10, "A2", 443, new[] { "Diet", "Beslenme", "Dieta", "Régime", "Ernährung", "Dieta", "Dieta", "食事", "식단", "饮食" }),
        new(10158, "health_exercise", 10, "A2", 444, new[] { "Exercise", "Egzersiz", "Ejercicio", "Exercice", "Bewegung", "Esercizio", "Exercício", "運動", "운동", "锻炼" }),
        new(10159, "health_treatment", 10, "B1", 445, new[] { "Treatment", "Tedavi", "Tratamiento", "Traitement", "Behandlung", "Trattamento", "Tratamento", "治療", "치료", "治疗" }),
        new(10160, "health_symptom", 10, "B1", 446, new[] { "Symptom", "Belirti", "Síntoma", "Symptôme", "Symptom", "Sintomo", "Sintoma", "症状", "증상", "症状" }),
        new(10161, "health_surgery", 10, "B1", 447, new[] { "Surgery", "Ameliyat", "Cirugía", "Chirurgie", "Operation", "Chirurgia", "Cirurgia", "手術", "수술", "手术" }),
        new(10162, "health_vaccine", 10, "B1", 448, new[] { "Vaccine", "Aşı", "Vacuna", "Vaccin", "Impfstoff", "Vaccino", "Vacina", "ワクチン", "백신", "疫苗" }),
        new(10163, "health_allergy", 10, "B1", 449, new[] { "Allergy", "Alerji", "Alergia", "Allergie", "Allergie", "Allergia", "Alergia", "アレルギー", "알레르기", "过敏" }),
        new(10164, "health_recovery", 10, "B1", 450, new[] { "Recovery", "İyileşme", "Recuperación", "Guérison", "Genesung", "Guarigione", "Recuperação", "回復", "회복", "康复" }),
        new(10165, "health_diagnosis", 10, "B1+", 451, new[] { "Diagnosis", "Teşhis", "Diagnóstico", "Diagnostic", "Diagnose", "Diagnosi", "Diagnóstico", "診断", "진단", "诊断" }),
        new(10166, "health_prescription", 10, "B1+", 452, new[] { "Prescription", "Reçete", "Receta", "Ordonnance", "Rezept", "Ricetta", "Receita", "処方箋", "처방전", "处方" }),
        new(10167, "health_infection", 10, "B1+", 453, new[] { "Infection", "Enfeksiyon", "Infección", "Infection", "Infektion", "Infezione", "Infecção", "感染", "감염", "感染" }),
        new(10168, "health_immune", 10, "B1+", 454, new[] { "Immune", "Bağışıklık", "Inmune", "Immunitaire", "Immun", "Immune", "Imune", "免疫の", "면역", "免疫" }),
        new(10169, "health_chronic", 10, "B2", 455, new[] { "Chronic", "Kronik", "Crónico", "Chronique", "Chronisch", "Cronico", "Crônico", "慢性の", "만성", "慢性" }),
        new(10170, "health_therapy", 10, "B2", 456, new[] { "Therapy", "Terapi", "Terapia", "Thérapie", "Therapie", "Terapia", "Terapia", "療法", "치료법", "疗法" }),
        new(10171, "health_nutrition", 10, "B2", 457, new[] { "Nutrition", "Beslenme bilimi", "Nutrición", "Nutrition", "Ernährungslehre", "Nutrizione", "Nutrição", "栄養", "영양", "营养" }),
        new(10172, "health_dosage", 10, "B2", 458, new[] { "Dosage", "Doz", "Dosis", "Dosage", "Dosierung", "Dosaggio", "Dosagem", "用量", "용량", "剂量" }),
        new(10173, "health_prognosis", 10, "C1", 459, new[] { "Prognosis", "Prognoz", "Pronóstico", "Pronostic", "Prognose", "Prognosi", "Prognóstico", "予後", "예후", "预后" }),
        new(10174, "health_inflammation", 10, "C1", 460, new[] { "Inflammation", "İltihap", "Inflamación", "Inflammation", "Entzündung", "Infiammazione", "Inflamação", "炎症", "염증", "炎症" }),
        new(10175, "health_metabolism", 10, "C1", 461, new[] { "Metabolism", "Metabolizma", "Metabolismo", "Métabolisme", "Stoffwechsel", "Metabolismo", "Metabolismo", "代謝", "신진대사", "新陈代谢" }),
        new(10176, "health_pathology", 10, "C2", 462, new[] { "Pathology", "Patoloji", "Patología", "Pathologie", "Pathologie", "Patologia", "Patologia", "病理学", "병리학", "病理学" }),
        new(10177, "health_epidemiology", 10, "C2", 463, new[] { "Epidemiology", "Epidemiyoloji", "Epidemiología", "Épidémiologie", "Epidemiologie", "Epidemiologia", "Epidemiologia", "疫学", "역학", "流行病学" }),
        new(10178, "shopping_buy", 11, "A1", 464, new[] { "Buy", "Satın almak", "Comprar", "Acheter", "Kaufen", "Comprare", "Comprar", "買う", "사다", "买" }),
        new(10179, "shopping_shirt", 11, "A1", 465, new[] { "Shirt", "Gömlek", "Camisa", "Chemise", "Hemd", "Camicia", "Camisa", "シャツ", "셔츠", "衬衫" }),
        new(10180, "shopping_shoes", 11, "A1", 466, new[] { "Shoes", "Ayakkabı", "Zapatos", "Chaussures", "Schuhe", "Scarpe", "Sapatos", "靴", "신발", "鞋" }),
        new(10181, "shopping_bag", 11, "A1", 467, new[] { "Bag", "Çanta", "Bolso", "Sac", "Tasche", "Borsa", "Bolsa", "かばん", "가방", "包" }),
        new(10182, "shopping_market", 11, "A2", 468, new[] { "Market", "Pazar", "Mercado", "Marché", "Markt", "Mercato", "Mercado", "市場", "시장", "市场" }),
        new(10183, "shopping_trousers", 11, "A2", 469, new[] { "Trousers", "Pantolon", "Pantalones", "Pantalon", "Hose", "Pantaloni", "Calça", "ズボン", "바지", "裤子" }),
        new(10184, "shopping_jacket", 11, "A2", 470, new[] { "Jacket", "Ceket", "Chaqueta", "Veste", "Jacke", "Giacca", "Jaqueta", "ジャケット", "재킷", "夹克" }),
        new(10185, "shopping_brand", 11, "B1", 471, new[] { "Brand", "Marka", "Marca", "Marque", "Marke", "Marca", "Marca", "ブランド", "브랜드", "品牌" }),
        new(10186, "shopping_quality", 11, "B1", 472, new[] { "Quality", "Kalite", "Calidad", "Qualité", "Qualität", "Qualità", "Qualidade", "品質", "품질", "质量" }),
        new(10187, "shopping_exchange", 11, "B1", 473, new[] { "Exchange", "Değişim", "Cambio", "Échange", "Umtausch", "Cambio", "Troca", "交換", "교환", "换货" }),
        new(10188, "shopping_fitting_room", 11, "B1", 474, new[] { "Fitting room", "Deneme kabini", "Probador", "Cabine d'essayage", "Umkleidekabine", "Camerino", "Provador", "試着室", "탈의실", "试衣间" }),
        new(10189, "shopping_warranty", 11, "B1+", 475, new[] { "Warranty", "Garanti", "Garantía", "Garantie", "Garantie", "Garanzia", "Garantia", "保証", "보증", "保修" }),
        new(10190, "shopping_bargain", 11, "B1+", 476, new[] { "Bargain", "Kelepir", "Ganga", "Bonne affaire", "Schnäppchen", "Affare", "Pechincha", "掘り出し物", "특가품", "便宜货" }),
        new(10191, "shopping_instalment", 11, "B1+", 477, new[] { "Instalment", "Taksit", "Cuota", "Versement", "Rate", "Rata", "Prestação", "分割払い", "할부", "分期" }),
        new(10192, "shopping_retail", 11, "B2", 478, new[] { "Retail", "Perakende", "Venta al por menor", "Vente au détail", "Einzelhandel", "Vendita al dettaglio", "Varejo", "小売", "소매", "零售" }),
        new(10193, "shopping_wholesale", 11, "B2", 479, new[] { "Wholesale", "Toptan", "Venta al por mayor", "Vente en gros", "Großhandel", "Vendita all'ingrosso", "Atacado", "卸売", "도매", "批发" }),
        new(10194, "shopping_consumer", 11, "B2", 480, new[] { "Consumer", "Tüketici", "Consumidor", "Consommateur", "Verbraucher", "Consumatore", "Consumidor", "消費者", "소비자", "消费者" }),
        new(10195, "shopping_merchandising", 11, "C1", 481, new[] { "Merchandising", "Ürün yerleştirme", "Merchandising", "Merchandisage", "Warenpräsentation", "Merchandising", "Merchandising", "商品化計画", "머천다이징", "商品企划" }),
        new(10196, "shopping_depreciation", 11, "C1", 482, new[] { "Depreciation", "Değer kaybı", "Depreciación", "Dépréciation", "Wertminderung", "Deprezzamento", "Depreciação", "減価", "감가상각", "折旧" }),
        new(10197, "shopping_procurement", 11, "C1", 483, new[] { "Procurement", "Tedarik", "Adquisición", "Approvisionnement", "Beschaffung", "Approvvigionamento", "Aquisição", "調達", "조달", "采购" }),
        new(10198, "shopping_elasticity", 11, "C2", 484, new[] { "Elasticity", "Esneklik", "Elasticidad", "Élasticité", "Elastizität", "Elasticità", "Elasticidade", "弾力性", "탄력성", "弹性" }),
        new(10199, "shopping_arbitrage", 11, "C2", 485, new[] { "Arbitrage", "Arbitraj", "Arbitraje", "Arbitrage", "Arbitrage", "Arbitraggio", "Arbitragem", "裁定取引", "차익거래", "套利" }),
        new(10200, "nature_leaf", 13, "A2", 486, new[] { "Leaf", "Yaprak", "Hoja", "Feuille", "Blatt", "Foglia", "Folha", "葉", "잎", "叶子" }),
        new(10201, "nature_climate", 13, "B1", 487, new[] { "Climate", "İklim", "Clima", "Climat", "Klima", "Clima", "Clima", "気候", "기후", "气候" }),
        new(10202, "nature_desert", 13, "B1", 488, new[] { "Desert", "Çöl", "Desierto", "Désert", "Wüste", "Deserto", "Deserto", "砂漠", "사막", "沙漠" }),
        new(10203, "nature_soil", 13, "B1", 489, new[] { "Soil", "Toprak", "Suelo", "Sol", "Boden", "Suolo", "Solo", "土壌", "토양", "土壤" }),
        new(10204, "nature_species", 13, "B1", 490, new[] { "Species", "Tür", "Especie", "Espèce", "Art", "Specie", "Espécie", "種", "종", "物种" }),
        new(10205, "nature_waterfall", 13, "B1", 491, new[] { "Waterfall", "Şelale", "Cascada", "Cascade", "Wasserfall", "Cascata", "Cachoeira", "滝", "폭포", "瀑布" }),
        new(10206, "nature_environment", 13, "B1+", 492, new[] { "Environment", "Çevre", "Medio ambiente", "Environnement", "Umwelt", "Ambiente", "Meio ambiente", "環境", "환경", "环境" }),
        new(10207, "nature_pollution", 13, "B1+", 493, new[] { "Pollution", "Kirlilik", "Contaminación", "Pollution", "Verschmutzung", "Inquinamento", "Poluição", "汚染", "오염", "污染" }),
        new(10208, "nature_glacier", 13, "B1+", 494, new[] { "Glacier", "Buzul", "Glaciar", "Glacier", "Gletscher", "Ghiacciaio", "Geleira", "氷河", "빙하", "冰川" }),
        new(10209, "nature_habitat", 13, "B1+", 495, new[] { "Habitat", "Yaşam alanı", "Hábitat", "Habitat", "Lebensraum", "Habitat", "Habitat", "生息地", "서식지", "栖息地" }),
        new(10210, "nature_ecosystem", 13, "B2", 496, new[] { "Ecosystem", "Ekosistem", "Ecosistema", "Écosystème", "Ökosystem", "Ecosistema", "Ecossistema", "生態系", "생태계", "生态系统" }),
        new(10211, "nature_erosion", 13, "B2", 497, new[] { "Erosion", "Erozyon", "Erosión", "Érosion", "Erosion", "Erosione", "Erosão", "侵食", "침식", "侵蚀" }),
        new(10212, "nature_renewable", 13, "B2", 498, new[] { "Renewable", "Yenilenebilir", "Renovable", "Renouvelable", "Erneuerbar", "Rinnovabile", "Renovável", "再生可能な", "재생 가능", "可再生" }),
        new(10213, "nature_drought", 13, "B2", 499, new[] { "Drought", "Kuraklık", "Sequía", "Sécheresse", "Dürre", "Siccità", "Seca", "干ばつ", "가뭄", "干旱" }),
        new(10214, "nature_biodiversity", 13, "C1", 500, new[] { "Biodiversity", "Biyoçeşitlilik", "Biodiversidad", "Biodiversité", "Biodiversität", "Biodiversità", "Biodiversidade", "生物多様性", "생물 다양성", "生物多样性" }),
        new(10215, "nature_sustainability", 13, "C1", 501, new[] { "Sustainability", "Sürdürülebilirlik", "Sostenibilidad", "Durabilité", "Nachhaltigkeit", "Sostenibilità", "Sustentabilidade", "持続可能性", "지속 가능성", "可持续性" }),
        new(10216, "nature_sediment", 13, "C1", 502, new[] { "Sediment", "Tortu", "Sedimento", "Sédiment", "Sediment", "Sedimento", "Sedimento", "堆積物", "퇴적물", "沉积物" }),
        new(10217, "nature_symbiosis", 13, "C2", 503, new[] { "Symbiosis", "Ortak yaşam", "Simbiosis", "Symbiose", "Symbiose", "Simbiosi", "Simbiose", "共生", "공생", "共生" }),
        new(10218, "nature_anthropogenic", 13, "C2", 504, new[] { "Anthropogenic", "İnsan kaynaklı", "Antropogénico", "Anthropique", "Anthropogen", "Antropogenico", "Antropogênico", "人為的な", "인위적", "人为的" }),
        new(10219, "science_fire", 14, "A1", 505, new[] { "Fire", "Ateş", "Fuego", "Feu", "Feuer", "Fuoco", "Fogo", "火", "불", "火" }),
        new(10220, "science_light", 14, "A1", 506, new[] { "Light", "Işık", "Luz", "Lumière", "Licht", "Luce", "Luz", "光", "빛", "光" }),
        new(10221, "science_air", 14, "A1", 507, new[] { "Air", "Hava", "Aire", "Air", "Luft", "Aria", "Ar", "空気", "공기", "空气" }),
        new(10222, "science_heat", 14, "A1", 508, new[] { "Heat", "Isı", "Calor", "Chaleur", "Wärme", "Calore", "Calor", "熱", "열", "热" }),
        new(10223, "science_star", 14, "A1", 509, new[] { "Star", "Yıldız", "Estrella", "Étoile", "Stern", "Stella", "Estrela", "星", "별", "星星" }),
        new(10224, "science_moon", 14, "A1", 510, new[] { "Moon", "Ay", "Luna", "Lune", "Mond", "Luna", "Lua", "月", "달", "月亮" }),
        new(10225, "science_earth", 14, "A1", 511, new[] { "Earth", "Dünya", "Tierra", "Terre", "Erde", "Terra", "Terra", "地球", "지구", "地球" }),
        new(10226, "science_number", 14, "A1", 512, new[] { "Number", "Sayı", "Número", "Nombre", "Zahl", "Numero", "Número", "数", "숫자", "数字" }),
        new(10227, "science_sound", 14, "A1", 513, new[] { "Sound", "Ses", "Sonido", "Son", "Schall", "Suono", "Som", "音", "소리", "声音" }),
        new(10228, "science_result", 14, "A2", 514, new[] { "Result", "Sonuç", "Resultado", "Résultat", "Ergebnis", "Risultato", "Resultado", "結果", "결과", "结果" }),
        new(10229, "science_measure", 14, "A2", 515, new[] { "Measure", "Ölçmek", "Medir", "Mesurer", "Messen", "Misurare", "Medir", "測る", "측정하다", "测量" }),
        new(10230, "science_metal", 14, "A2", 516, new[] { "Metal", "Metal", "Metal", "Métal", "Metall", "Metallo", "Metal", "金属", "금속", "金属" }),
        new(10231, "science_machine", 14, "A2", 517, new[] { "Machine", "Makine", "Máquina", "Machine", "Maschine", "Macchina", "Máquina", "機械", "기계", "机器" }),
        new(10232, "science_discovery", 14, "B1", 518, new[] { "Discovery", "Keşif", "Descubrimiento", "Découverte", "Entdeckung", "Scoperta", "Descoberta", "発見", "발견", "发现" }),
        new(10233, "science_molecule", 14, "B1+", 519, new[] { "Molecule", "Molekül", "Molécula", "Molécule", "Molekül", "Molecola", "Molécula", "分子", "분자", "分子" }),
        new(10234, "science_hypothesis", 14, "B1+", 520, new[] { "Hypothesis", "Hipotez", "Hipótesis", "Hypothèse", "Hypothese", "Ipotesi", "Hipótese", "仮説", "가설", "假设" }),
        new(10235, "science_laboratory", 14, "B1+", 521, new[] { "Laboratory", "Laboratuvar", "Laboratorio", "Laboratoire", "Labor", "Laboratorio", "Laboratório", "実験室", "실험실", "实验室" }),
        new(10236, "science_analysis", 14, "B2", 522, new[] { "Analysis", "Analiz", "Análisis", "Analyse", "Analyse", "Analisi", "Análise", "分析", "분석", "分析" }),
        new(10237, "science_radiation", 14, "B2", 523, new[] { "Radiation", "Radyasyon", "Radiación", "Radiation", "Strahlung", "Radiazione", "Radiação", "放射線", "방사선", "辐射" }),
        new(10238, "science_evolution", 14, "B2", 524, new[] { "Evolution", "Evrim", "Evolución", "Évolution", "Evolution", "Evoluzione", "Evolução", "進化", "진화", "进化" }),
        new(10239, "science_compound", 14, "B2", 525, new[] { "Compound", "Bileşik", "Compuesto", "Composé", "Verbindung", "Composto", "Composto", "化合物", "화합물", "化合物" }),
        new(10240, "science_catalyst", 14, "C1", 526, new[] { "Catalyst", "Katalizör", "Catalizador", "Catalyseur", "Katalysator", "Catalizzatore", "Catalisador", "触媒", "촉매", "催化剂" }),
        new(10241, "science_entropy", 14, "C1", 527, new[] { "Entropy", "Entropi", "Entropía", "Entropie", "Entropie", "Entropia", "Entropia", "エントロピー", "엔트로피", "熵" }),
        new(10242, "science_isotope", 14, "C1", 528, new[] { "Isotope", "İzotop", "Isótopo", "Isotope", "Isotop", "Isotopo", "Isótopo", "同位体", "동위원소", "同位素" }),
        new(10243, "science_quantum", 14, "C2", 529, new[] { "Quantum", "Kuantum", "Cuántico", "Quantique", "Quantenhaft", "Quantistico", "Quântico", "量子", "양자", "量子" }),
        new(10244, "science_thermodynamics", 14, "C2", 530, new[] { "Thermodynamics", "Termodinamik", "Termodinámica", "Thermodynamique", "Thermodynamik", "Termodinamica", "Termodinâmica", "熱力学", "열역학", "热力学" }),
        new(10245, "animals_mouse", 15, "A1", 531, new[] { "Mouse", "Fare", "Ratón", "Souris", "Maus", "Topo", "Rato", "ねずみ", "쥐", "老鼠" }),
        new(10246, "animals_elephant", 15, "A2", 532, new[] { "Elephant", "Fil", "Elefante", "Éléphant", "Elefant", "Elefante", "Elefante", "象", "코끼리", "大象" }),
        new(10247, "animals_wing", 15, "A2", 533, new[] { "Wing", "Kanat", "Ala", "Aile", "Flügel", "Ala", "Asa", "翼", "날개", "翅膀" }),
        new(10248, "animals_tail", 15, "A2", 534, new[] { "Tail", "Kuyruk", "Cola", "Queue", "Schwanz", "Coda", "Cauda", "尾", "꼬리", "尾巴" }),
        new(10249, "animals_monkey", 15, "A2", 535, new[] { "Monkey", "Maymun", "Mono", "Singe", "Affe", "Scimmia", "Macaco", "猿", "원숭이", "猴子" }),
        new(10250, "animals_snake", 15, "A2", 536, new[] { "Snake", "Yılan", "Serpiente", "Serpent", "Schlange", "Serpente", "Cobra", "蛇", "뱀", "蛇" }),
        new(10251, "animals_wildlife", 15, "B1", 537, new[] { "Wildlife", "Yaban hayatı", "Fauna salvaje", "Faune sauvage", "Wildtiere", "Fauna selvatica", "Vida selvagem", "野生動物", "야생 동물", "野生动物" }),
        new(10252, "animals_feather", 15, "B1", 538, new[] { "Feather", "Tüy", "Pluma", "Plume", "Feder", "Piuma", "Pena", "羽", "깃털", "羽毛" }),
        new(10253, "animals_nest", 15, "B1", 539, new[] { "Nest", "Yuva", "Nido", "Nid", "Nest", "Nido", "Ninho", "巣", "둥지", "巢" }),
        new(10254, "animals_insect", 15, "B1", 540, new[] { "Insect", "Böcek", "Insecto", "Insecte", "Insekt", "Insetto", "Inseto", "昆虫", "곤충", "昆虫" }),
        new(10255, "animals_reptile", 15, "B1", 541, new[] { "Reptile", "Sürüngen", "Reptil", "Reptile", "Reptil", "Rettile", "Réptil", "爬虫類", "파충류", "爬行动物" }),
        new(10256, "animals_mammal", 15, "B1", 542, new[] { "Mammal", "Memeli", "Mamífero", "Mammifère", "Säugetier", "Mammifero", "Mamífero", "哺乳類", "포유류", "哺乳动物" }),
        new(10257, "animals_predator", 15, "B1+", 543, new[] { "Predator", "Yırtıcı", "Depredador", "Prédateur", "Raubtier", "Predatore", "Predador", "捕食者", "포식자", "捕食者" }),
        new(10258, "animals_prey", 15, "B1+", 544, new[] { "Prey", "Av", "Presa", "Proie", "Beute", "Preda", "Presa", "獲物", "먹이", "猎物" }),
        new(10259, "animals_herd", 15, "B1+", 545, new[] { "Herd", "Sürü", "Manada", "Troupeau", "Herde", "Mandria", "Rebanho", "群れ", "무리", "兽群" }),
        new(10260, "animals_endangered", 15, "B1+", 546, new[] { "Endangered", "Nesli tükenmekte", "En peligro", "En voie de disparition", "Bedroht", "In via di estinzione", "Ameaçado", "絶滅危惧の", "멸종 위기", "濒危" }),
        new(10261, "animals_migration", 15, "B2", 547, new[] { "Migration", "Göç", "Migración", "Migration", "Wanderung", "Migrazione", "Migração", "渡り", "이동", "迁徙" }),
        new(10262, "animals_camouflage", 15, "B2", 548, new[] { "Camouflage", "Kamuflaj", "Camuflaje", "Camouflage", "Tarnung", "Mimetismo", "Camuflagem", "擬態", "위장", "伪装" }),
        new(10263, "animals_extinction", 15, "B2", 549, new[] { "Extinction", "Yok oluş", "Extinción", "Extinction", "Aussterben", "Estinzione", "Extinção", "絶滅", "멸종", "灭绝" }),
        new(10264, "animals_domestic", 15, "B2", 550, new[] { "Domestic", "Evcil", "Doméstico", "Domestique", "Zahm", "Domestico", "Doméstico", "家畜の", "가축의", "家养的" }),
        new(10265, "animals_hibernation", 15, "C1", 551, new[] { "Hibernation", "Kış uykusu", "Hibernación", "Hibernation", "Winterschlaf", "Ibernazione", "Hibernação", "冬眠", "겨울잠", "冬眠" }),
        new(10266, "animals_nocturnal", 15, "C1", 552, new[] { "Nocturnal", "Gececil", "Nocturno", "Nocturne", "Nachtaktiv", "Notturno", "Noturno", "夜行性の", "야행성", "夜行性" }),
        new(10267, "animals_habitat_loss", 15, "C1", 553, new[] { "Habitat loss", "Yaşam alanı kaybı", "Pérdida de hábitat", "Perte d'habitat", "Lebensraumverlust", "Perdita di habitat", "Perda de habitat", "生息地の減少", "서식지 감소", "栖息地丧失" }),
        new(10268, "animals_metamorphosis", 15, "C2", 554, new[] { "Metamorphosis", "Başkalaşım", "Metamorfosis", "Métamorphose", "Metamorphose", "Metamorfosi", "Metamorfose", "変態", "변태", "变态" }),
        new(10269, "animals_ethology", 15, "C2", 555, new[] { "Ethology", "Etoloji", "Etología", "Éthologie", "Ethologie", "Etologia", "Etologia", "動物行動学", "동물행동학", "动物行为学" }),
        new(10270, "food_vegetable", 1, "A2", 556, new[] { "Vegetable", "Sebze", "Verdura", "Légume", "Gemüse", "Verdura", "Legume", "野菜", "채소", "蔬菜" }),
        new(10271, "food_fruit", 1, "A2", 557, new[] { "Fruit", "Meyve", "Fruta", "Fruit", "Obst", "Frutta", "Fruta", "果物", "과일", "水果" }),
        new(10272, "food_restaurant", 1, "A2", 558, new[] { "Restaurant", "Restoran", "Restaurante", "Restaurant", "Restaurant", "Ristorante", "Restaurante", "レストラン", "식당", "餐厅" }),
        new(10273, "food_menu", 1, "A2", 559, new[] { "Menu", "Menü", "Menú", "Menu", "Speisekarte", "Menù", "Cardápio", "メニュー", "메뉴", "菜单" }),
        new(10274, "food_dessert", 1, "B1", 560, new[] { "Dessert", "Tatlı", "Postre", "Dessert", "Nachtisch", "Dolce", "Sobremesa", "デザート", "디저트", "甜点" }),
        new(10275, "food_breakfast", 1, "B1", 561, new[] { "Breakfast", "Kahvaltı", "Desayuno", "Petit-déjeuner", "Frühstück", "Colazione", "Café da manhã", "朝食", "아침 식사", "早餐" }),
        new(10276, "food_flavour", 1, "B1", 562, new[] { "Flavour", "Lezzet", "Sabor", "Saveur", "Geschmack", "Sapore", "Sabor", "味", "맛", "味道" }),
        new(10277, "food_waiter", 1, "B1", 563, new[] { "Waiter", "Garson", "Camarero", "Serveur", "Kellner", "Cameriere", "Garçom", "ウェイター", "웨이터", "服务员" }),
        new(10278, "food_portion", 1, "B1+", 564, new[] { "Portion", "Porsiyon", "Ración", "Portion", "Portion", "Porzione", "Porção", "一人前", "1인분", "份量" }),
        new(10279, "food_vegetarian", 1, "B1+", 565, new[] { "Vegetarian", "Vejetaryen", "Vegetariano", "Végétarien", "Vegetarisch", "Vegetariano", "Vegetariano", "ベジタリアン", "채식주의자", "素食者" }),
        new(10280, "food_spice", 1, "B1+", 566, new[] { "Spice", "Baharat", "Especia", "Épice", "Gewürz", "Spezia", "Tempero", "香辛料", "향신료", "香料" }),
        new(10281, "food_roast", 1, "B1+", 567, new[] { "Roast", "Kızartmak", "Asar", "Rôtir", "Braten", "Arrostire", "Assar", "焼く", "굽다", "烤" }),
        new(10282, "food_cuisine", 1, "B2", 568, new[] { "Cuisine", "Mutfak", "Cocina", "Cuisine", "Küche", "Cucina", "Culinária", "料理", "요리", "菜系" }),
        new(10283, "food_seasoning", 1, "B2", 569, new[] { "Seasoning", "Çeşni", "Condimento", "Assaisonnement", "Würzung", "Condimento", "Temperagem", "味付け", "양념", "调味" }),
        new(10284, "food_nutrient", 1, "B2", 570, new[] { "Nutrient", "Besin", "Nutriente", "Nutriment", "Nährstoff", "Nutriente", "Nutriente", "栄養素", "영양소", "营养素" }),
        new(10285, "food_marinate", 1, "B2", 571, new[] { "Marinate", "Marine etmek", "Marinar", "Mariner", "Marinieren", "Marinare", "Marinar", "漬け込む", "재우다", "腌制" }),
        new(10286, "food_fermentation", 1, "C1", 572, new[] { "Fermentation", "Fermantasyon", "Fermentación", "Fermentation", "Gärung", "Fermentazione", "Fermentação", "発酵", "발효", "发酵" }),
        new(10287, "food_palate", 1, "C1", 573, new[] { "Palate", "Damak", "Paladar", "Palais", "Gaumen", "Palato", "Paladar", "味覚", "미각", "味觉" }),
        new(10288, "food_garnish", 1, "C1", 574, new[] { "Garnish", "Süsleme", "Guarnición", "Garniture", "Garnitur", "Guarnizione", "Guarnição", "付け合わせ", "고명", "配菜" }),
        new(10289, "food_umami", 1, "C2", 575, new[] { "Umami", "Umami", "Umami", "Umami", "Umami", "Umami", "Umami", "うま味", "감칠맛", "鲜味" }),
        new(10290, "food_emulsion", 1, "C2", 576, new[] { "Emulsion", "Emülsiyon", "Emulsión", "Émulsion", "Emulsion", "Emulsione", "Emulsão", "乳化", "유화", "乳化液" }),
        new(10291, "travel_bus", 2, "A1", 577, new[] { "Bus", "Otobüs", "Autobús", "Bus", "Bus", "Autobus", "Ônibus", "バス", "버스", "公共汽车" }),
        new(10292, "travel_train", 2, "A2", 578, new[] { "Train", "Tren", "Tren", "Train", "Zug", "Treno", "Trem", "電車", "기차", "火车" }),
        new(10293, "travel_flight", 2, "A2", 579, new[] { "Flight", "Uçuş", "Vuelo", "Vol", "Flug", "Volo", "Voo", "フライト", "항공편", "航班" }),
        new(10294, "travel_border", 2, "A2", 580, new[] { "Border", "Sınır", "Frontera", "Frontière", "Grenze", "Confine", "Fronteira", "国境", "국경", "边境" }),
        new(10295, "travel_straight_on", 2, "A2", 581, new[] { "Straight on", "Düz", "Recto", "Tout droit", "Geradeaus", "Dritto", "Em frente", "まっすぐ", "직진", "一直走" }),
        new(10296, "travel_address", 2, "A2", 582, new[] { "Address", "Adres", "Dirección", "Adresse", "Adresse", "Indirizzo", "Endereço", "住所", "주소", "地址" }),
        new(10297, "travel_reservation", 2, "B1", 583, new[] { "Reservation", "Rezervasyon", "Reserva", "Réservation", "Reservierung", "Prenotazione", "Reserva", "予約", "예약", "预订" }),
        new(10298, "travel_departure", 2, "B1", 584, new[] { "Departure", "Kalkış", "Salida", "Départ", "Abfahrt", "Partenza", "Partida", "出発", "출발", "出发" }),
        new(10299, "travel_arrival", 2, "B1", 585, new[] { "Arrival", "Varış", "Llegada", "Arrivée", "Ankunft", "Arrivo", "Chegada", "到着", "도착", "到达" }),
        new(10300, "travel_journey", 2, "B1", 586, new[] { "Journey", "Yolculuk", "Viaje", "Trajet", "Reise", "Viaggio", "Viagem", "旅", "여정", "旅程" }),
        new(10301, "travel_guide", 2, "B1", 587, new[] { "Guide", "Rehber", "Guía", "Guide", "Reiseführer", "Guida", "Guia", "ガイド", "가이드", "导游" }),
        new(10302, "travel_itinerary", 2, "B1+", 588, new[] { "Itinerary", "Güzergâh", "Itinerario", "Itinéraire", "Reiseroute", "Itinerario", "Itinerário", "旅程表", "여행 일정", "行程" }),
        new(10303, "travel_accommodation", 2, "B1+", 589, new[] { "Accommodation", "Konaklama", "Alojamiento", "Hébergement", "Unterkunft", "Alloggio", "Hospedagem", "宿泊", "숙박", "住宿" }),
        new(10304, "travel_customs", 2, "B1+", 590, new[] { "Customs", "Gümrük", "Aduana", "Douane", "Zoll", "Dogana", "Alfândega", "税関", "세관", "海关" }),
        new(10305, "travel_delay", 2, "B1+", 591, new[] { "Delay", "Rötar", "Retraso", "Retard", "Verspätung", "Ritardo", "Atraso", "遅延", "지연", "延误" }),
        new(10306, "travel_visa", 2, "B2", 592, new[] { "Visa", "Vize", "Visado", "Visa", "Visum", "Visto", "Visto", "ビザ", "비자", "签证" }),
        new(10307, "travel_destination", 2, "B2", 593, new[] { "Destination", "Varış yeri", "Destino", "Destination", "Reiseziel", "Destinazione", "Destino", "目的地", "목적지", "目的地" }),
        new(10308, "travel_insurance", 2, "B2", 594, new[] { "Insurance", "Sigorta", "Seguro", "Assurance", "Versicherung", "Assicurazione", "Seguro", "保険", "보험", "保险" }),
        new(10309, "travel_transit", 2, "B2", 595, new[] { "Transit", "Aktarma", "Tránsito", "Transit", "Transit", "Transito", "Trânsito", "乗り継ぎ", "환승", "中转" }),
        new(10310, "travel_excursion", 2, "C1", 596, new[] { "Excursion", "Gezi", "Excursión", "Excursion", "Ausflug", "Escursione", "Excursão", "遠足", "소풍", "短途旅行" }),
        new(10311, "travel_jet_lag", 2, "C1", 597, new[] { "Jet lag", "Saat farkı yorgunluğu", "Desfase horario", "Décalage horaire", "Jetlag", "Fuso orario", "Jet lag", "時差ぼけ", "시차증", "时差反应" }),
        new(10312, "travel_landmark", 2, "C1", 598, new[] { "Landmark", "Simge yapı", "Punto de referencia", "Point de repère", "Wahrzeichen", "Punto di riferimento", "Ponto de referência", "名所", "랜드마크", "地标" }),
        new(10313, "travel_wanderlust", 2, "C2", 599, new[] { "Wanderlust", "Gezme tutkusu", "Pasión por viajar", "Envie d'ailleurs", "Fernweh", "Voglia di viaggiare", "Vontade de viajar", "旅への憧れ", "방랑벽", "旅行癖" }),
        new(10314, "travel_expatriate", 2, "C2", 600, new[] { "Expatriate", "Gurbetçi", "Expatriado", "Expatrié", "Auswanderer", "Espatriato", "Expatriado", "駐在員", "국외 거주자", "侨居者" }),
        new(10315, "business_email", 3, "A1", 601, new[] { "Email", "E-posta", "Correo electrónico", "E-mail", "E-Mail", "Email", "E-mail", "メール", "이메일", "电子邮件" }),
        new(10316, "business_boss", 3, "A1", 602, new[] { "Boss", "Patron", "Jefe", "Patron", "Chef", "Capo", "Chefe", "上司", "상사", "老板" }),
        new(10317, "business_company", 3, "A1", 603, new[] { "Company", "Şirket", "Empresa", "Entreprise", "Firma", "Azienda", "Empresa", "会社", "회사", "公司" }),
        new(10318, "business_desk", 3, "A1", 604, new[] { "Desk", "Masa", "Escritorio", "Bureau", "Schreibtisch", "Scrivania", "Mesa", "机", "책상", "桌子" }),
        new(10319, "business_job", 3, "A1", 605, new[] { "Job", "İş", "Empleo", "Emploi", "Stelle", "Impiego", "Emprego", "職", "직업", "职位" }),
        new(10320, "business_manager", 3, "A1", 606, new[] { "Manager", "Yönetici", "Gerente", "Directeur", "Manager", "Direttore", "Gerente", "マネージャー", "매니저", "经理" }),
        new(10321, "business_client", 3, "A1", 607, new[] { "Client", "Müşteri", "Cliente", "Client", "Kunde", "Cliente", "Cliente", "クライアント", "고객", "客户" }),
        new(10322, "business_colleague", 3, "A2", 608, new[] { "Colleague", "Meslektaş", "Colega", "Collègue", "Kollege", "Collega", "Colega", "同僚", "동료", "同事" }),
        new(10323, "business_report", 3, "A2", 609, new[] { "Report", "Rapor", "Informe", "Rapport", "Bericht", "Rapporto", "Relatório", "報告書", "보고서", "报告" }),
        new(10324, "business_schedule", 3, "A2", 610, new[] { "Schedule", "Program", "Horario", "Emploi du temps", "Zeitplan", "Orario", "Agenda", "予定", "일정", "日程" }),
        new(10325, "business_project", 3, "A2", 611, new[] { "Project", "Proje", "Proyecto", "Projet", "Projekt", "Progetto", "Projeto", "プロジェクト", "프로젝트", "项目" }),
        new(10326, "business_interview", 3, "A2", 612, new[] { "Interview", "Mülakat", "Entrevista", "Entretien", "Vorstellungsgespräch", "Colloquio", "Entrevista", "面接", "면접", "面试" }),
        new(10327, "business_document", 3, "A2", 613, new[] { "Document", "Belge", "Documento", "Document", "Dokument", "Documento", "Documento", "書類", "서류", "文件" }),
        new(10328, "business_contract", 3, "B1", 614, new[] { "Contract", "Sözleşme", "Contrato", "Contrat", "Vertrag", "Contratto", "Contrato", "契約", "계약", "合同" }),
        new(10329, "business_presentation", 3, "B1", 615, new[] { "Presentation", "Sunum", "Presentación", "Présentation", "Präsentation", "Presentazione", "Apresentação", "プレゼン", "발표", "演示" }),
        new(10330, "business_department", 3, "B1", 616, new[] { "Department", "Departman", "Departamento", "Service", "Abteilung", "Reparto", "Departamento", "部署", "부서", "部门" }),
        new(10331, "business_profit", 3, "B1", 617, new[] { "Profit", "Kâr", "Beneficio", "Bénéfice", "Gewinn", "Profitto", "Lucro", "利益", "이익", "利润" }),
        new(10332, "business_negotiation", 3, "B1+", 618, new[] { "Negotiation", "Müzakere", "Negociación", "Négociation", "Verhandlung", "Trattativa", "Negociação", "交渉", "협상", "谈判" }),
        new(10333, "business_promotion", 3, "B1+", 619, new[] { "Promotion", "Terfi", "Ascenso", "Promotion", "Beförderung", "Promozione", "Promoção", "昇進", "승진", "晋升" }),
        new(10334, "business_supplier", 3, "B1+", 620, new[] { "Supplier", "Tedarikçi", "Proveedor", "Fournisseur", "Lieferant", "Fornitore", "Fornecedor", "仕入先", "공급업체", "供应商" }),
        new(10335, "business_revenue", 3, "B1+", 621, new[] { "Revenue", "Gelir", "Ingresos", "Chiffre d'affaires", "Umsatz", "Ricavo", "Receita", "収益", "매출", "收入" }),
        new(10336, "business_stakeholder", 3, "B2", 622, new[] { "Stakeholder", "Paydaş", "Parte interesada", "Partie prenante", "Interessengruppe", "Portatore d'interesse", "Parte interessada", "利害関係者", "이해관계자", "利益相关者" }),
        new(10337, "business_compliance", 3, "B2", 623, new[] { "Compliance", "Uyum", "Cumplimiento", "Conformité", "Regeltreue", "Conformità", "Conformidade", "法令遵守", "준법", "合规" }),
        new(10338, "business_merger", 3, "B2", 624, new[] { "Merger", "Birleşme", "Fusión", "Fusion", "Fusion", "Fusione", "Fusão", "合併", "합병", "合并" }),
        new(10339, "business_outsourcing", 3, "B2", 625, new[] { "Outsourcing", "Dış kaynak kullanımı", "Externalización", "Externalisation", "Auslagerung", "Esternalizzazione", "Terceirização", "外部委託", "외주", "外包" }),
        new(10340, "business_liquidity", 3, "C1", 626, new[] { "Liquidity", "Likidite", "Liquidez", "Liquidité", "Liquidität", "Liquidità", "Liquidez", "流動性", "유동성", "流动性" }),
        new(10341, "business_leverage", 3, "C1", 627, new[] { "Leverage", "Kaldıraç", "Apalancamiento", "Effet de levier", "Hebelwirkung", "Leva finanziaria", "Alavancagem", "レバレッジ", "레버리지", "杠杆" }),
        new(10342, "business_due_diligence", 3, "C1", 628, new[] { "Due diligence", "Durum tespiti", "Diligencia debida", "Diligence raisonnable", "Sorgfaltsprüfung", "Dovuta diligenza", "Auditoria prévia", "デューデリジェンス", "실사", "尽职调查" }),
        new(10343, "business_amortisation", 3, "C2", 629, new[] { "Amortisation", "İtfa", "Amortización", "Amortissement", "Tilgung", "Ammortamento", "Amortização", "償却", "상각", "摊销" }),
        new(10344, "business_fiduciary", 3, "C2", 630, new[] { "Fiduciary", "Mütevelli", "Fiduciario", "Fiduciaire", "Treuhänderisch", "Fiduciario", "Fiduciário", "受託者の", "수탁의", "受托的" }),
        new(10345, "family_man", 12, "A1", 631, new[] { "Man", "Adam", "Hombre", "Homme", "Mann", "Uomo", "Homem", "男", "남자", "男人" }),
        new(10346, "family_woman", 12, "A1", 632, new[] { "Woman", "Kadın", "Mujer", "Femme", "Frau", "Donna", "Mulher", "女", "여자", "女人" }),
        new(10347, "family_baby", 12, "A2", 633, new[] { "Baby", "Bebek", "Bebé", "Bébé", "Baby", "Neonato", "Bebê", "赤ちゃん", "아기", "婴儿" }),
        new(10348, "family_aunt", 12, "A2", 634, new[] { "Aunt", "Teyze", "Tía", "Tante", "Tante", "Zia", "Tia", "おば", "이모", "姑姑" }),
        new(10349, "family_uncle", 12, "A2", 635, new[] { "Uncle", "Amca", "Tío", "Oncle", "Onkel", "Zio", "Tio", "おじ", "삼촌", "叔叔" }),
        new(10350, "family_neighbour", 12, "A2", 636, new[] { "Neighbour", "Komşu", "Vecino", "Voisin", "Nachbar", "Vicino", "Vizinho", "隣人", "이웃", "邻居" }),
        new(10351, "family_cousin", 12, "B1", 637, new[] { "Cousin", "Kuzen", "Primo", "Cousin", "Cousin", "Cugino", "Primo", "いとこ", "사촌", "表亲" }),
        new(10352, "family_marriage", 12, "B1", 638, new[] { "Marriage", "Evlilik", "Matrimonio", "Mariage", "Ehe", "Matrimonio", "Casamento", "結婚", "결혼", "婚姻" }),
        new(10353, "family_relative", 12, "B1", 639, new[] { "Relative", "Akraba", "Pariente", "Parent", "Verwandter", "Parente", "Parente", "親戚", "친척", "亲戚" }),
        new(10354, "family_couple", 12, "B1", 640, new[] { "Couple", "Çift", "Pareja", "Couple", "Paar", "Coppia", "Casal", "夫婦", "부부", "夫妻" }),
        new(10355, "family_twin", 12, "B1", 641, new[] { "Twin", "İkiz", "Gemelo", "Jumeau", "Zwilling", "Gemello", "Gêmeo", "双子", "쌍둥이", "双胞胎" }),
        new(10356, "family_generation", 12, "B1", 642, new[] { "Generation", "Kuşak", "Generación", "Génération", "Generation", "Generazione", "Geração", "世代", "세대", "一代" }),
        new(10357, "family_household", 12, "B1+", 643, new[] { "Household", "Hane", "Hogar", "Foyer", "Haushalt", "Nucleo familiare", "Domicílio", "世帯", "가구", "家户" }),
        new(10358, "family_nephew", 12, "B1+", 644, new[] { "Nephew", "Erkek yeğen", "Sobrino", "Neveu", "Neffe", "Nipote", "Sobrinho", "甥", "조카", "侄子" }),
        new(10359, "family_mother_in_law", 12, "B1+", 645, new[] { "Mother-in-law", "Kayınvalide", "Suegra", "Belle-mère", "Schwiegermutter", "Suocera", "Sogra", "義母", "시어머니", "婆婆" }),
        new(10360, "family_upbringing", 12, "B1+", 646, new[] { "Upbringing", "Yetiştirilme", "Crianza", "Éducation", "Erziehung", "Educazione", "Criação", "育ち", "양육", "教养" }),
        new(10361, "family_ancestor", 12, "B2", 647, new[] { "Ancestor", "Ata", "Antepasado", "Ancêtre", "Vorfahre", "Antenato", "Ancestral", "先祖", "조상", "祖先" }),
        new(10362, "family_sibling", 12, "B2", 648, new[] { "Sibling", "Kardeş", "Hermano o hermana", "Frère ou sœur", "Geschwister", "Fratello o sorella", "Irmão ou irmã", "兄弟姉妹", "형제자매", "兄弟姐妹" }),
        new(10363, "family_guardian", 12, "B2", 649, new[] { "Guardian", "Vasi", "Tutor legal", "Tuteur", "Vormund", "Tutore", "Tutor legal", "保護者", "보호자", "监护人" }),
        new(10364, "family_inheritance", 12, "B2", 650, new[] { "Inheritance", "Miras", "Herencia", "Héritage", "Erbe", "Eredità", "Herança", "相続", "상속", "遗产" }),
        new(10365, "family_kinship", 12, "C1", 651, new[] { "Kinship", "Akrabalık", "Parentesco", "Parenté", "Verwandtschaft", "Parentela", "Parentesco", "親族関係", "친족 관계", "亲属关系" }),
        new(10366, "family_descendant", 12, "C1", 652, new[] { "Descendant", "Soydan gelen", "Descendiente", "Descendant", "Nachkomme", "Discendente", "Descendente", "子孫", "후손", "后代" }),
        new(10367, "family_estrangement", 12, "C1", 653, new[] { "Estrangement", "Küslük", "Distanciamiento", "Éloignement", "Entfremdung", "Allontanamento", "Afastamento", "疎遠", "소원", "疏远" }),
        new(10368, "family_lineage", 12, "C2", 654, new[] { "Lineage", "Soy", "Linaje", "Lignée", "Abstammung", "Lignaggio", "Linhagem", "血筋", "혈통", "血统" }),
        new(10369, "family_matriarch", 12, "C2", 655, new[] { "Matriarch", "Aile büyüğü kadın", "Matriarca", "Matriarche", "Matriarchin", "Matriarca", "Matriarca", "女家長", "여가장", "女族长" }),
    };

    /// <summary>
    /// Müfredatta zaten bulunan kavramlara eklenen çeviriler. İngilizce ve
    /// Türkçe satırlarını <see cref="ConceptSeedData"/> zaten yazıyor, bu
    /// yüzden <see cref="Apply"/> o iki dili atlar.
    /// </summary>
    private static readonly MergedConcept[] MergedConcepts =
    {
        new(13, new[] { "Water", "Su", "Agua", "Eau", "Wasser", "Acqua", "Água", "水", "물", "水" }),
        new(14, new[] { "Bread", "Ekmek", "Pan", "Pain", "Brot", "Pane", "Pão", "パン", "빵", "面包" }),
        new(15, new[] { "Milk", "Süt", "Leche", "Lait", "Milch", "Latte", "Leite", "牛乳", "우유", "牛奶" }),
        new(16, new[] { "Tea", "Çay", "Té", "Thé", "Tee", "Tè", "Chá", "お茶", "차", "茶" }),
        new(17, new[] { "Coffee", "Kahve", "Café", "Café", "Kaffee", "Caffè", "Café", "コーヒー", "커피", "咖啡" }),
        new(18, new[] { "Apple", "Elma", "Manzana", "Pomme", "Apfel", "Mela", "Maçã", "りんご", "사과", "苹果" }),
        new(19, new[] { "Cheese", "Peynir", "Queso", "Fromage", "Käse", "Formaggio", "Queijo", "チーズ", "치즈", "奶酪" }),
        new(20, new[] { "Egg", "Yumurta", "Huevo", "Œuf", "Ei", "Uovo", "Ovo", "卵", "계란", "鸡蛋" }),
        new(21, new[] { "Rice", "Pirinç", "Arroz", "Riz", "Reis", "Riso", "Arroz", "ご飯", "밥", "米饭" }),
        new(22, new[] { "Meat", "Et", "Carne", "Viande", "Fleisch", "Carne", "Carne", "肉", "고기", "肉" }),
        new(23, new[] { "Salt", "Tuz", "Sal", "Sel", "Salz", "Sale", "Sal", "塩", "소금", "盐" }),
        new(24, new[] { "Sugar", "Şeker", "Azúcar", "Sucre", "Zucker", "Zucchero", "Açúcar", "砂糖", "설탕", "糖" }),
        new(49, new[] { "Mother", "Anne", "Madre", "Mère", "Mutter", "Madre", "Mãe", "母", "어머니", "母亲" }),
        new(50, new[] { "Father", "Baba", "Padre", "Père", "Vater", "Padre", "Pai", "父", "아버지", "父亲" }),
        new(51, new[] { "Sister", "Kız kardeş", "Hermana", "Sœur", "Schwester", "Sorella", "Irmã", "姉妹", "자매", "姐妹" }),
        new(52, new[] { "Brother", "Erkek kardeş", "Hermano", "Frère", "Bruder", "Fratello", "Irmão", "兄弟", "형제", "兄弟" }),
        new(53, new[] { "Daughter", "Kız evlat", "Hija", "Fille", "Tochter", "Figlia", "Filha", "娘", "딸", "女儿" }),
        new(54, new[] { "Son", "Oğul", "Hijo", "Fils", "Sohn", "Figlio", "Filho", "息子", "아들", "儿子" }),
        new(55, new[] { "Grandmother", "Büyükanne", "Abuela", "Grand-mère", "Großmutter", "Nonna", "Avó", "祖母", "할머니", "祖母" }),
        new(56, new[] { "Grandfather", "Büyükbaba", "Abuelo", "Grand-père", "Großvater", "Nonno", "Avô", "祖父", "할아버지", "祖父" }),
        new(58, new[] { "Child", "Çocuk", "Niño", "Enfant", "Kind", "Bambino", "Criança", "子供", "아이", "孩子" }),
        new(59, new[] { "Friend", "Arkadaş", "Amigo", "Ami", "Freund", "Amico", "Amigo", "友達", "친구", "朋友" }),
        new(60, new[] { "Family", "Aile", "Familia", "Famille", "Familie", "Famiglia", "Família", "家族", "가족", "家庭" }),
        new(71, new[] { "Airport", "Havalimanı", "Aeropuerto", "Aéroport", "Flughafen", "Aeroporto", "Aeroporto", "空港", "공항", "机场" }),
        new(72, new[] { "Station", "İstasyon", "Estación", "Gare", "Bahnhof", "Stazione", "Estação", "駅", "역", "车站" }),
        new(73, new[] { "Ticket", "Bilet", "Entrada", "Billet", "Karte", "Biglietto", "Ingresso", "チケット", "티켓", "票" }),
        new(74, new[] { "Hotel", "Otel", "Hotel", "Hôtel", "Hotel", "Hotel", "Hotel", "ホテル", "호텔", "酒店" }),
        new(75, new[] { "Left", "Sol", "Izquierda", "Gauche", "Links", "Sinistra", "Esquerda", "左", "왼쪽", "左" }),
        new(76, new[] { "Right", "Sağ", "Derecha", "Droite", "Rechts", "Destra", "Direita", "右", "오른쪽", "右" }),
        new(78, new[] { "Map", "Harita", "Mapa", "Carte", "Karte", "Mappa", "Mapa", "マップ", "지도", "地图" }),
        new(79, new[] { "Luggage", "Bavul", "Equipaje", "Bagages", "Gepäck", "Bagaglio", "Bagagem", "荷物", "짐", "行李" }),
        new(80, new[] { "Passport", "Pasaport", "Pasaporte", "Passeport", "Reisepass", "Passaporto", "Passaporte", "パスポート", "여권", "护照" }),
        new(81, new[] { "Road", "Yol", "Camino", "Route", "Straße", "Strada", "Estrada", "道", "길", "路" }),
        new(84, new[] { "Office", "Ofis", "Oficina", "Bureau", "Büro", "Ufficio", "Escritório", "オフィス", "사무실", "办公室" }),
        new(85, new[] { "Meeting", "Toplantı", "Reunión", "Réunion", "Besprechung", "Riunione", "Reunião", "会議", "회의", "会议" }),
        new(86, new[] { "Teacher", "Öğretmen", "Profesor", "Professeur", "Lehrer", "Insegnante", "Professor", "先生", "선생님", "老师" }),
        new(87, new[] { "Student", "Öğrenci", "Estudiante", "Étudiant", "Schüler", "Studente", "Estudante", "学生", "학생", "学生" }),
        new(88, new[] { "School", "Okul", "Escuela", "École", "Schule", "Scuola", "Escola", "学校", "학교", "学校" }),
        new(89, new[] { "Book", "Kitap", "Libro", "Livre", "Buch", "Libro", "Livro", "本", "책", "书" }),
        new(90, new[] { "Pen", "Kalem", "Bolígrafo", "Stylo", "Stift", "Penna", "Caneta", "ペン", "펜", "笔" }),
        new(91, new[] { "Question", "Soru", "Pregunta", "Question", "Frage", "Domanda", "Pergunta", "質問", "질문", "问题" }),
        new(92, new[] { "Answer", "Cevap", "Respuesta", "Réponse", "Antwort", "Risposta", "Resposta", "答え", "대답", "回答" }),
        new(93, new[] { "Exam", "Sınav", "Examen", "Examen", "Prüfung", "Esame", "Prova", "試験", "시험", "考试" }),
        new(94, new[] { "Homework", "Ödev", "Deberes", "Devoirs", "Hausaufgaben", "Compiti", "Dever de casa", "宿題", "숙제", "作业" }),
        new(95, new[] { "Head", "Baş", "Cabeza", "Tête", "Kopf", "Testa", "Cabeça", "頭", "머리", "头" }),
        new(100, new[] { "Doctor", "Doktor", "Médico", "Médecin", "Arzt", "Medico", "Médico", "医者", "의사", "医生" }),
        new(101, new[] { "Hospital", "Hastane", "Hospital", "Hôpital", "Krankenhaus", "Ospedale", "Hospital", "病院", "병원", "医院" }),
        new(102, new[] { "Medicine", "İlaç", "Medicina", "Médicament", "Medikament", "Medicina", "Remédio", "薬", "약", "药" }),
        new(103, new[] { "Pain", "Ağrı", "Dolor", "Douleur", "Schmerz", "Dolore", "Dor", "痛み", "통증", "疼痛" }),
        new(104, new[] { "Fever", "Ateş", "Fiebre", "Fièvre", "Fieber", "Febbre", "Febre", "熱", "열", "发烧" }),
        new(106, new[] { "Tooth", "Diş", "Diente", "Dent", "Zahn", "Dente", "Dente", "歯", "이", "牙齿" }),
        new(117, new[] { "Car", "Araba", "Coche", "Voiture", "Auto", "Auto", "Carro", "車", "자동차", "汽车" }),
        new(118, new[] { "Money", "Para", "Dinero", "Argent", "Geld", "Denaro", "Dinheiro", "お金", "돈", "钱" }),
        new(119, new[] { "Rain", "Yağmur", "Lluvia", "Pluie", "Regen", "Pioggia", "Chuva", "雨", "비", "雨" }),
        new(120, new[] { "Snow", "Kar", "Nieve", "Neige", "Schnee", "Neve", "Neve", "雪", "눈", "雪" }),
        new(121, new[] { "Sun", "Güneş", "Sol", "Soleil", "Sonne", "Sole", "Sol", "太陽", "태양", "太阳" }),
        new(122, new[] { "Cloud", "Bulut", "Nube", "Nuage", "Cloud", "Nuvola", "Nuvem", "クラウド", "클라우드", "云" }),
        new(123, new[] { "Wind", "Rüzgâr", "Viento", "Vent", "Wind", "Vento", "Vento", "風", "바람", "风" }),
        new(143, new[] { "Price", "Fiyat", "Precio", "Prix", "Preis", "Prezzo", "Preço", "値段", "가격", "价格" }),
        new(144, new[] { "Discount", "İndirim", "Descuento", "Réduction", "Rabatt", "Sconto", "Desconto", "割引", "할인", "折扣" }),
        new(145, new[] { "Receipt", "Fiş", "Recibo", "Reçu", "Quittung", "Scontrino", "Recibo", "レシート", "영수증", "收据" }),
        new(146, new[] { "Cash", "Nakit", "Efectivo", "Espèces", "Bargeld", "Contanti", "Dinheiro vivo", "現金", "현금", "现金" }),
        new(147, new[] { "Size", "Beden", "Talla", "Taille", "Größe", "Taglia", "Tamanho", "サイズ", "사이즈", "尺码" }),
        new(148, new[] { "Shop", "Mağaza", "Tienda", "Magasin", "Geschäft", "Negozio", "Loja", "店", "가게", "商店" }),
        new(149, new[] { "Customer", "Müşteri", "Cliente", "Client", "Kunde", "Cliente", "Cliente", "客", "손님", "顾客" }),
        new(150, new[] { "Expensive", "Pahalı", "Caro", "Cher", "Teuer", "Costoso", "Caro", "高い", "비싸다", "贵" }),
        new(151, new[] { "Cheap", "Ucuz", "Barato", "Bon marché", "Billig", "Economico", "Barato", "安い", "싸다", "便宜" }),
        new(152, new[] { "Refund", "İade", "Reembolso", "Remboursement", "Rückerstattung", "Rimborso", "Reembolso", "返金", "환불", "退款" }),
        new(154, new[] { "Delivery", "Teslimat", "Entrega", "Livraison", "Lieferung", "Consegna", "Entrega", "配達", "배송", "配送" }),
        new(155, new[] { "Computer", "Bilgisayar", "Ordenador", "Ordinateur", "Computer", "Computer", "Computador", "コンピューター", "컴퓨터", "电脑" }),
        new(156, new[] { "Screen", "Ekran", "Pantalla", "Écran", "Bildschirm", "Schermo", "Tela", "画面", "화면", "屏幕" }),
        new(157, new[] { "Keyboard", "Klavye", "Teclado", "Clavier", "Tastatur", "Tastiera", "Teclado", "キーボード", "키보드", "键盘" }),
        new(158, new[] { "Password", "Şifre", "Contraseña", "Mot de passe", "Passwort", "Password", "Senha", "パスワード", "비밀번호", "密码" }),
        new(159, new[] { "File", "Dosya", "Archivo", "Fichier", "Datei", "File", "Arquivo", "ファイル", "파일", "文件" }),
        new(160, new[] { "Message", "Mesaj", "Mensaje", "Message", "Nachricht", "Messaggio", "Mensagem", "メッセージ", "메시지", "消息" }),
        new(161, new[] { "Battery", "Pil", "Batería", "Batterie", "Batterie", "Batteria", "Bateria", "電池", "배터리", "电池" }),
        new(162, new[] { "Software", "Yazılım", "Software", "Logiciel", "Software", "Software", "Software", "ソフトウェア", "소프트웨어", "软件" }),
        new(163, new[] { "Network", "Ağ", "Red", "Réseau", "Netzwerk", "Rete", "Rede", "ネットワーク", "네트워크", "网络" }),
        new(164, new[] { "Download", "İndirmek", "Descargar", "Télécharger", "Herunterladen", "Scaricare", "Baixar", "ダウンロード", "다운로드", "下载" }),
        new(165, new[] { "Update", "Güncelleme", "Actualización", "Mise à jour", "Aktualisierung", "Aggiornamento", "Atualização", "アップデート", "업데이트", "更新" }),
        new(166, new[] { "Device", "Cihaz", "Dispositivo", "Appareil", "Gerät", "Dispositivo", "Dispositivo", "端末", "기기", "设备" }),
        new(167, new[] { "Tree", "Ağaç", "Árbol", "Arbre", "Baum", "Albero", "Árvore", "木", "나무", "树" }),
        new(168, new[] { "Flower", "Çiçek", "Flor", "Fleur", "Blume", "Fiore", "Flor", "花", "꽃", "花" }),
        new(169, new[] { "River", "Nehir", "Río", "Rivière", "Fluss", "Fiume", "Rio", "川", "강", "河" }),
        new(170, new[] { "Mountain", "Dağ", "Montaña", "Montagne", "Berg", "Montagna", "Montanha", "山", "산", "山" }),
        new(171, new[] { "Sea", "Deniz", "Mar", "Mer", "Meer", "Mare", "Mar", "海", "바다", "海" }),
        new(172, new[] { "Forest", "Orman", "Bosque", "Forêt", "Wald", "Foresta", "Floresta", "森", "숲", "森林" }),
        new(173, new[] { "Sky", "Gökyüzü", "Cielo", "Ciel", "Himmel", "Cielo", "Céu", "空", "하늘", "天空" }),
        new(174, new[] { "Stone", "Taş", "Piedra", "Pierre", "Stein", "Pietra", "Pedra", "石", "돌", "石头" }),
        new(175, new[] { "Lake", "Göl", "Lago", "Lac", "See", "Lago", "Lago", "湖", "호수", "湖" }),
        new(176, new[] { "Island", "Ada", "Isla", "Île", "Insel", "Isola", "Ilha", "島", "섬", "岛" }),
        new(177, new[] { "Beach", "Plaj", "Playa", "Plage", "Strand", "Spiaggia", "Praia", "浜辺", "해변", "海滩" }),
        new(178, new[] { "Valley", "Vadi", "Valle", "Vallée", "Tal", "Valle", "Vale", "谷", "계곡", "山谷" }),
        new(179, new[] { "Team", "Takım", "Equipo", "Équipe", "Team", "Squadra", "Equipe", "チーム", "팀", "队伍" }),
        new(180, new[] { "Player", "Oyuncu", "Jugador", "Joueur", "Spieler", "Giocatore", "Jogador", "プレイヤー", "플레이어", "玩家" }),
        new(181, new[] { "Match", "Maç", "Partida", "Partie", "Partie", "Partita", "Partida", "試合", "경기", "比赛" }),
        new(182, new[] { "Goal", "Gol", "Gol", "But", "Tor", "Gol", "Gol", "ゴール", "골", "进球" }),
        new(183, new[] { "Coach", "Antrenör", "Entrenador", "Entraîneur", "Trainer", "Allenatore", "Treinador", "コーチ", "코치", "教练" }),
        new(184, new[] { "Training", "Antrenman", "Entrenamiento", "Entraînement", "Training", "Allenamento", "Treino", "トレーニング", "훈련", "训练" }),
        new(185, new[] { "Score", "Puan", "Puntuación", "Score", "Punktzahl", "Punteggio", "Pontuação", "スコア", "점수", "分数" }),
        new(186, new[] { "Stadium", "Stat", "Estadio", "Stade", "Stadion", "Stadio", "Estádio", "スタジアム", "경기장", "体育场" }),
        new(187, new[] { "Referee", "Hakem", "Árbitro", "Arbitre", "Schiedsrichter", "Arbitro", "Árbitro", "審判", "심판", "裁判" }),
        new(188, new[] { "Victory", "Zafer", "Victoria", "Victoire", "Sieg", "Vittoria", "Vitória", "勝利", "승리", "胜利" }),
        new(190, new[] { "Injury", "Sakatlık", "Lesión", "Blessure", "Verletzung", "Infortunio", "Lesão", "けが", "부상", "受伤" }),
        new(191, new[] { "Song", "Şarkı", "Canción", "Chanson", "Lied", "Canzone", "Canção", "歌", "노래", "歌曲" }),
        new(192, new[] { "Singer", "Şarkıcı", "Cantante", "Chanteur", "Sänger", "Cantante", "Cantor", "歌手", "가수", "歌手" }),
        new(193, new[] { "Guitar", "Gitar", "Guitarra", "Guitare", "Gitarre", "Chitarra", "Guitarra", "ギター", "기타", "吉他" }),
        new(194, new[] { "Concert", "Konser", "Concierto", "Concert", "Konzert", "Concerto", "Concerto", "コンサート", "콘서트", "音乐会" }),
        new(198, new[] { "Stage", "Sahne", "Escenario", "Scène", "Bühne", "Palco", "Palco", "舞台", "무대", "舞台" }),
        new(199, new[] { "Rhythm", "Ritim", "Ritmo", "Rythme", "Rhythmus", "Ritmo", "Ritmo", "リズム", "리듬", "节奏" }),
        new(200, new[] { "Audience", "Seyirci", "Público", "Public", "Publikum", "Pubblico", "Plateia", "観客", "관객", "观众" }),
        new(203, new[] { "Recipe", "Tarif", "Receta", "Recette", "Rezept", "Ricetta", "Receita", "レシピ", "조리법", "食谱" }),
        new(214, new[] { "Ingredient", "Malzeme", "Ingrediente", "Ingrédient", "Zutat", "Ingrediente", "Ingrediente", "材料", "재료", "食材" }),
        new(217, new[] { "Salary", "Maaş", "Salario", "Salaire", "Gehalt", "Stipendio", "Salário", "給料", "급여", "工资" }),
        new(219, new[] { "Invoice", "Fatura", "Factura", "Facture", "Rechnung", "Fattura", "Fatura", "請求書", "청구서", "发票" }),
        new(223, new[] { "Budget", "Bütçe", "Presupuesto", "Budget", "Budget", "Bilancio", "Orçamento", "予算", "예산", "预算" }),
        new(224, new[] { "Currency", "Para birimi", "Moneda", "Devise", "Währung", "Valuta", "Moeda", "通貨", "통화", "货币" }),
        new(231, new[] { "Story", "Hikâye", "Historia", "Histoire", "Geschichte", "Storia", "História", "物語", "이야기", "故事" }),
        new(239, new[] { "Dog", "Köpek", "Perro", "Chien", "Hund", "Cane", "Cachorro", "犬", "개", "狗" }),
        new(240, new[] { "Cat", "Kedi", "Gato", "Chat", "Katze", "Gatto", "Gato", "猫", "고양이", "猫" }),
        new(241, new[] { "Bird", "Kuş", "Pájaro", "Oiseau", "Vogel", "Uccello", "Pássaro", "鳥", "새", "鸟" }),
        new(242, new[] { "Fish", "Balık", "Pez", "Poisson", "Fisch", "Pesce", "Peixe", "魚", "물고기", "鱼" }),
        new(243, new[] { "Horse", "At", "Caballo", "Cheval", "Pferd", "Cavallo", "Cavalo", "馬", "말", "马" }),
        new(244, new[] { "Sheep", "Koyun", "Oveja", "Mouton", "Schaf", "Pecora", "Ovelha", "羊", "양", "羊" }),
        new(245, new[] { "Cow", "İnek", "Vaca", "Vache", "Kuh", "Mucca", "Vaca", "牛", "소", "牛" }),
        new(246, new[] { "Chicken", "Tavuk", "Pollo", "Poulet", "Huhn", "Pollo", "Frango", "鶏", "닭", "鸡" }),
        new(247, new[] { "Rabbit", "Tavşan", "Conejo", "Lapin", "Kaninchen", "Coniglio", "Coelho", "うさぎ", "토끼", "兔子" }),
        new(248, new[] { "Bear", "Ayı", "Oso", "Ours", "Bär", "Orso", "Urso", "熊", "곰", "熊" }),
        new(250, new[] { "Lion", "Aslan", "León", "Lion", "Löwe", "Leone", "Leão", "ライオン", "사자", "狮子" }),
        new(252, new[] { "Research", "Araştırma", "Investigación", "Recherche", "Forschung", "Ricerca", "Pesquisa", "研究", "연구", "研究" }),
        new(253, new[] { "Experiment", "Deney", "Experimento", "Expérience", "Experiment", "Esperimento", "Experimento", "実験", "실험", "实验" }),
        new(254, new[] { "Theory", "Teori", "Teoría", "Théorie", "Theorie", "Teoria", "Teoria", "理論", "이론", "理论" }),
        new(255, new[] { "Energy", "Enerji", "Energía", "Énergie", "Energie", "Energia", "Energia", "エネルギー", "에너지", "能量" }),
        new(256, new[] { "Gravity", "Yerçekimi", "Gravedad", "Gravité", "Schwerkraft", "Gravità", "Gravidade", "重力", "중력", "重力" }),
        new(257, new[] { "Cell", "Hücre", "Célula", "Cellule", "Zelle", "Cellula", "Célula", "細胞", "세포", "细胞" }),
        new(258, new[] { "Atom", "Atom", "Átomo", "Atome", "Atom", "Atomo", "Átomo", "原子", "원자", "原子" }),
        new(259, new[] { "Planet", "Gezegen", "Planeta", "Planète", "Planet", "Pianeta", "Planeta", "惑星", "행성", "行星" }),
        new(262, new[] { "Evidence", "Kanıt", "Evidencia", "Preuve", "Beweis", "Prova", "Evidência", "証拠", "증거", "证据" }),
        new(264, new[] { "Cinema", "Sinema", "Cine", "Cinéma", "Kino", "Cinema", "Cinema", "映画館", "영화관", "电影院" }),
        new(265, new[] { "Actor", "Oyuncu", "Actor", "Acteur", "Schauspieler", "Attore", "Ator", "俳優", "배우", "演员" }),
        new(266, new[] { "Director", "Yönetmen", "Director", "Réalisateur", "Regisseur", "Regista", "Diretor", "監督", "감독", "导演" }),
        new(267, new[] { "Scene", "Sahne", "Escena", "Scène", "Szene", "Scena", "Cena", "シーン", "장면", "场景" }),
        new(268, new[] { "Subtitle", "Altyazı", "Subtítulo", "Sous-titre", "Untertitel", "Sottotitolo", "Legenda", "字幕", "자막", "字幕" }),
        new(269, new[] { "Comedy", "Komedi", "Comedia", "Comédie", "Komödie", "Commedia", "Comédia", "コメディ", "코미디", "喜剧" }),
        new(271, new[] { "Series", "Dizi", "Serie", "Série", "Serie", "Serie", "Série", "ドラマ", "드라마", "电视剧" }),
        new(274, new[] { "Character", "Karakter", "Personaje", "Personnage", "Figur", "Personaggio", "Personagem", "登場人物", "등장인물", "角色" }),
        new(275, new[] { "Game", "Oyun", "Juego", "Jeu", "Spiel", "Gioco", "Jogo", "ゲーム", "게임", "游戏" }),
        new(276, new[] { "Level", "Seviye", "Nivel", "Niveau", "Level", "Livello", "Nível", "レベル", "레벨", "关卡" }),
        new(278, new[] { "Controller", "Kumanda", "Mando", "Manette", "Controller", "Controller", "Controle", "コントローラー", "컨트롤러", "手柄" }),
        new(279, new[] { "Mission", "Görev", "Misión", "Mission", "Mission", "Missione", "Missão", "ミッション", "미션", "任务" }),
        new(280, new[] { "Reward", "Ödül", "Recompensa", "Récompense", "Belohnung", "Ricompensa", "Recompensa", "報酬", "보상", "奖励" }),
        new(281, new[] { "Tournament", "Turnuva", "Torneo", "Tournoi", "Turnier", "Torneo", "Torneio", "トーナメント", "토너먼트", "锦标赛" }),
        new(282, new[] { "Achievement", "Başarım", "Logro", "Succès", "Erfolg", "Obiettivo", "Conquista", "実績", "업적", "成就" }),
        new(284, new[] { "Strategy", "Strateji", "Estrategia", "Stratégie", "Strategie", "Strategia", "Estratégia", "戦略", "전략", "策略" }),
    };

    internal static void Apply(ModelBuilder modelBuilder)
    {
        ConfigureRelations(modelBuilder);
        Seed(modelBuilder);
    }

    private static void ConfigureRelations(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DeckTemplate>(e =>
        {
            // Slug istemcinin desteyi tanıdığı ad; iki şablonun aynı slug'ı
            // taşıması kullanıcıda çakışan StarterKey üretirdi.
            e.HasIndex(t => t.Slug).IsUnique();

            // "Bu kategorinin şablonu var mı" sorgusu senkronizasyonun sıcak
            // yolunda, kullanıcının seçtiği her kategori için çalışıyor.
            e.HasIndex(t => t.CategoryId);

            e.HasOne(t => t.Category)
                .WithMany()
                .HasForeignKey(t => t.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<DeckTemplateLabel>(e =>
        {
            e.HasKey(l => new { l.DeckTemplateId, l.LanguageCode });

            e.HasOne(l => l.DeckTemplate)
                .WithMany(t => t.Labels)
                .HasForeignKey(l => l.DeckTemplateId)
                .OnDelete(DeleteBehavior.Cascade);

            // Dil satırı Languages tablosuna bağlanmaz: katalog dilleri ile
            // içerik dilleri ayrı yaşamalı, yoksa bir dili listeden kaldırmak
            // şablon metnini de silerdi.
        });

        modelBuilder.Entity<DeckTemplateConcept>(e =>
        {
            e.HasKey(x => new { x.DeckTemplateId, x.ConceptId });

            // Deste kurulurken tek sorgu "bu şablonun kavramları, sırasıyla".
            e.HasIndex(x => new { x.DeckTemplateId, x.Ordinal }).IsUnique();

            // "Bu şablonun şu kademeye kadarki kavramları" sorgusu deste
            // kurulumunun tamamını taşıyor.
            e.HasIndex(x => new { x.DeckTemplateId, x.CefrLevel });

            e.ToTable(x => x.HasCheckConstraint(
                "CK_DeckTemplateConcept_CefrLevel",
                "[CefrLevel] IN ('A1', 'A2', 'B1', 'B1+', 'B2', 'C1', 'C2')"));

            e.HasOne(x => x.DeckTemplate)
                .WithMany(t => t.Concepts)
                .HasForeignKey(x => x.DeckTemplateId)
                .OnDelete(DeleteBehavior.Cascade);

            e.HasOne(x => x.Concept)
                .WithMany()
                .HasForeignKey(x => x.ConceptId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }

    private static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Concept>().HasData(
            NewConcepts.Select(c => new Concept
            {
                Id = c.Id,
                Key = c.Key,
                CategoryId = c.CategoryId,
                Level = c.Level,
                OrderIndex = c.OrderIndex
            }));

        var translations = new List<ConceptTranslation>();

        foreach (var concept in NewConcepts)
        {
            for (var i = 0; i < LanguageOrder.Length; i++)
            {
                translations.Add(new ConceptTranslation
                {
                    ConceptId = concept.Id,
                    LanguageCode = LanguageOrder[i],
                    Term = concept.Texts[i]
                });
            }
        }

        foreach (var concept in MergedConcepts)
        {
            for (var i = 0; i < LanguageOrder.Length; i++)
            {
                // ConceptSeedData bu kavramın en ve tr satırlarını zaten yazdı;
                // ikinci kez yazmak çakışan birincil anahtar demek olurdu. Oradaki
                // metin ayrıca elle düzenlenmiş (örnek cümlesi de var), katalogun
                // karşılığıyla değiştirilmemeli.
                if (LanguageOrder[i] is "en" or "tr")
                {
                    continue;
                }

                translations.Add(new ConceptTranslation
                {
                    ConceptId = concept.ConceptId,
                    LanguageCode = LanguageOrder[i],
                    Term = concept.Texts[i]
                });
            }
        }

        modelBuilder.Entity<ConceptTranslation>().HasData(translations);

        var templates = new List<DeckTemplate>();
        var labels = new List<DeckTemplateLabel>();
        var members = new List<DeckTemplateConcept>();

        foreach (var spec in Templates)
        {
            templates.Add(new DeckTemplate
            {
                Id = spec.Id,
                Slug = spec.Slug,
                CategoryId = spec.CategoryId,
                Emoji = spec.Emoji,
                ColorHex = spec.ColorHex,
                SortOrder = spec.Id
            });

            for (var i = 0; i < LanguageOrder.Length; i++)
            {
                labels.Add(new DeckTemplateLabel
                {
                    DeckTemplateId = spec.Id,
                    LanguageCode = LanguageOrder[i],
                    Title = spec.Titles[i],
                    Description = spec.Descriptions[i]
                });
            }

            for (var i = 0; i < spec.Members.Length; i++)
            {
                members.Add(new DeckTemplateConcept
                {
                    DeckTemplateId = spec.Id,
                    ConceptId = spec.Members[i].ConceptId,
                    Ordinal = i + 1,
                    CefrLevel = spec.Members[i].CefrLevel
                });
            }
        }

        modelBuilder.Entity<DeckTemplate>().HasData(templates);
        modelBuilder.Entity<DeckTemplateLabel>().HasData(labels);
        modelBuilder.Entity<DeckTemplateConcept>().HasData(members);
    }
}
