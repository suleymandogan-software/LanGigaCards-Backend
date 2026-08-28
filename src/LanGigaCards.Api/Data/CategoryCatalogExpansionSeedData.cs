using Microsoft.EntityFrameworkCore;

namespace LanGigaCards.Api.Data;

/// <summary>
/// <see cref="CategoryCatalogSeedData"/>'nin ilk 540 kelimelik kataloğuna eklenen
/// ikinci parti: on beş şablonun her birine sekiz yeni kelime, yine on dilde.
///
/// <para>
/// Ayrı bir dosyada tutulmasının nedeni <see cref="CategoryCatalogSeedData"/>'yı
/// büyütmemek: o dosya zaten 15 şablonun tam tanımını (emoji, renk, başlık,
/// açıklama, ilk 36 kelimelik üyelik) taşıyor. Bu dosya yalnızca ekliyor --
/// şablonun kendisini, başlığını ya da ilk kelime kümesini yeniden tanımlamıyor.
/// Kimlikler 10370'ten başlar: ilk katalog 10369'a kadar kullanıyordu.
/// </para>
///
/// <para>
/// Kelime seçimi ilk kataloğun sözlüğüyle çakışmayacak şekilde yapıldı --
/// "kütüphane" ve "kahvaltı" gibi bazı ilk-akla-gelen kelimeler zaten oradaydı,
/// bu yüzden bu parti bilinçli olarak ikinci sırada akla gelen kelimelere kaydı
/// ("kitaplık" yerine, "kahvaltı" yerine "atıştırmalık" gibi). Her şablon
/// kendi <see cref="DeckTemplateConcept.Ordinal"/> dizisini 37'den 44'e kadar
/// sürdürüyor; ilk katalogdaki hiçbir şablon 36'yı geçmiyordu.
/// </para>
///
/// <para>
/// Çeviri kalitesi notu: metinler bu turda anadili konuşanlarca doğrulanmadan
/// yazıldı -- <see cref="CategoryCatalogSeedData"/>'nın kendi çeviri notuyla aynı
/// çekince burada da geçerli. Kelimelerin kendisi kullanılabilir durumda, ama bir
/// anadili-konuşan incelemesi kataloğu kesinleşmiş saymadan önce iyi olur.
/// </para>
/// </summary>
internal static class CategoryCatalogExpansionSeedData
{
    /// <summary>
    /// <see cref="CategoryCatalogSeedData.LanguageOrder"/> ile aynı sıra; bu
    /// dosyanın kendi metin dizileri o sırayla okunuyor.
    /// </summary>
    private static readonly string[] LanguageOrder =
        { "en", "tr", "es", "fr", "de", "it", "pt", "ja", "ko", "zh" };

    private sealed record NewConcept(int Id, string Key, int CategoryId, string Level, int OrderIndex, string[] Texts);

    /// <summary>Şablon başına yeni sekiz kelime, hangi şablona ekleneceğiyle birlikte.</summary>
    private sealed record TemplateAddition(int TemplateId, int[] ConceptIds, string[] CefrLevels);

    /// <summary>
    /// Yalnızca bu partide eklenen kavramlar. Kimlikler 10370-10489 aralığında,
    /// şablon sırasıyla (technology..family) sekizerli gruplar halinde.
    /// </summary>
    private static readonly NewConcept[] NewConcepts =
    {
        // technology (şablon 1, kategori 4)
        new(10370, "technology_laptop", 4, "A1", 656, new[] { "Laptop", "Dizüstü bilgisayar", "Portátil", "Ordinateur portable", "Laptop", "Portatile", "Laptop", "ノートパソコン", "노트북", "笔记本电脑" }),
        new(10371, "technology_icon", 4, "A1", 657, new[] { "Icon", "Simge", "Icono", "Icône", "Symbol", "Icona", "Ícone", "アイコン", "아이콘", "图标" }),
        new(10372, "technology_tablet", 4, "A1", 658, new[] { "Tablet", "Tablet", "Tableta", "Tablette", "Tablet", "Tablet", "Tablet", "タブレット", "태블릿", "平板电脑" }),
        new(10373, "technology_notification", 4, "A2", 659, new[] { "Notification", "Bildirim", "Notificación", "Notification", "Benachrichtigung", "Notifica", "Notificação", "通知", "알림", "通知" }),
        new(10374, "technology_app", 4, "A2", 660, new[] { "App", "Uygulama", "Aplicación", "Application", "App", "App", "Aplicativo", "アプリ", "앱", "应用程序" }),
        new(10375, "technology_cursor", 4, "B1", 661, new[] { "Cursor", "İmleç", "Cursor", "Curseur", "Cursor", "Cursore", "Cursor", "カーソル", "커서", "光标" }),
        new(10376, "technology_mouse", 4, "B1+", 662, new[] { "Mouse", "Fare", "Ratón", "Souris", "Maus", "Mouse", "Mouse", "マウス", "마우스", "鼠标" }),
        new(10377, "technology_wifi", 4, "B2", 663, new[] { "Wifi", "Wifi", "Wifi", "Wifi", "WLAN", "Wifi", "Wifi", "Wi-Fi", "와이파이", "无线网络" }),

        // education (şablon 2, kategori 5)
        new(10378, "education_pencil", 5, "A1", 664, new[] { "Pencil", "Kalem", "Lápiz", "Crayon", "Bleistift", "Matita", "Lápis", "鉛筆", "연필", "铅笔" }),
        new(10379, "education_eraser", 5, "A1", 665, new[] { "Eraser", "Silgi", "Goma de borrar", "Gomme", "Radiergummi", "Gomma", "Borracha", "消しゴム", "지우개", "橡皮擦" }),
        new(10380, "education_principal", 5, "A1", 666, new[] { "Principal", "Okul müdürü", "Director de escuela", "Directeur d'école", "Schulleiter", "Preside", "Diretor de escola", "校長", "교장", "校长" }),
        new(10381, "education_homework", 5, "A2", 667, new[] { "Homework", "Ev ödevi", "Tarea", "Devoirs", "Hausaufgaben", "Compiti", "Dever de casa", "宿題", "숙제", "作业" }),
        new(10382, "education_bookshelf", 5, "A2", 668, new[] { "Bookshelf", "Kitaplık", "Estantería", "Étagère à livres", "Bücherregal", "Libreria", "Estante de livros", "本棚", "책장", "书架" }),
        new(10383, "education_exam", 5, "B1", 669, new[] { "Exam", "Sınav", "Examen", "Examen", "Prüfung", "Esame", "Exame", "試験", "시험", "考试" }),
        new(10384, "education_textbook", 5, "B1+", 670, new[] { "Textbook", "Ders kitabı", "Libro de texto", "Manuel scolaire", "Lehrbuch", "Libro di testo", "Livro didático", "教科書", "교과서", "教科书" }),
        new(10385, "education_blackboard", 5, "B2", 671, new[] { "Blackboard", "Kara tahta", "Pizarra", "Tableau noir", "Tafel", "Lavagna", "Quadro-negro", "黒板", "칠판", "黑板" }),

        // movies (şablon 3, kategori 6)
        new(10386, "movies_actor", 6, "A1", 672, new[] { "Actor", "Aktör", "Actor", "Acteur", "Schauspieler", "Attore", "Ator", "俳優", "배우", "男演员" }),
        new(10387, "movies_actress", 6, "A1", 673, new[] { "Actress", "Aktris", "Actriz", "Actrice", "Schauspielerin", "Attrice", "Atriz", "女優", "여배우", "女演员" }),
        new(10388, "movies_villain", 6, "A1", 674, new[] { "Villain", "Kötü karakter", "Villano", "Méchant", "Bösewicht", "Cattivo", "Vilão", "悪役", "악당", "反派" }),
        new(10389, "movies_screen", 6, "A2", 675, new[] { "Screen", "Ekran", "Pantalla", "Écran", "Bildschirm", "Schermo", "Tela", "スクリーン", "화면", "屏幕" }),
        new(10390, "movies_scene", 6, "A2", 676, new[] { "Scene", "Sahne", "Escena", "Scène", "Szene", "Scena", "Cena", "シーン", "장면", "场景" }),
        new(10391, "movies_subtitle", 6, "B1", 677, new[] { "Subtitle", "Altyazı", "Subtítulo", "Sous-titre", "Untertitel", "Sottotitolo", "Legenda", "字幕", "자막", "字幕" }),
        new(10392, "movies_spoiler", 6, "B1+", 678, new[] { "Spoiler", "Spoiler", "Spoiler", "Spoiler", "Spoiler", "Spoiler", "Spoiler", "ネタバレ", "스포일러", "剧透" }),
        new(10393, "movies_director", 6, "B2", 679, new[] { "Director", "Yönetmen", "Director", "Réalisateur", "Regisseur", "Regista", "Diretor", "監督", "감독", "导演" }),

        // music (şablon 4, kategori 7)
        new(10394, "music_guitar", 7, "A1", 680, new[] { "Guitar", "Gitar", "Guitarra", "Guitare", "Gitarre", "Chitarra", "Violão", "ギター", "기타", "吉他" }),
        new(10395, "music_trumpet", 7, "A1", 681, new[] { "Trumpet", "Trompet", "Trompeta", "Trompette", "Trompete", "Tromba", "Trompete", "トランペット", "트럼펫", "小号" }),
        new(10396, "music_duet", 7, "A1", 682, new[] { "Duet", "Düet", "Dúo", "Duo", "Duett", "Duetto", "Dueto", "デュエット", "듀엣", "二重唱" }),
        new(10397, "music_concert", 7, "A2", 683, new[] { "Concert", "Konser", "Concierto", "Concert", "Konzert", "Concerto", "Concerto", "コンサート", "콘서트", "音乐会" }),
        new(10398, "music_headphones", 7, "A2", 684, new[] { "Headphones", "Kulaklık", "Auriculares", "Écouteurs", "Kopfhörer", "Cuffie", "Fones de ouvido", "ヘッドフォン", "헤드폰", "耳机" }),
        new(10399, "music_microphone", 7, "B1", 685, new[] { "Microphone", "Mikrofon", "Micrófono", "Microphone", "Mikrofon", "Microfono", "Microfone", "マイク", "마이크", "麦克风" }),
        new(10400, "music_chord", 7, "B1+", 686, new[] { "Chord", "Akor", "Acorde", "Accord", "Akkord", "Accordo", "Acorde", "コード", "코드", "和弦" }),
        new(10401, "music_anthem", 7, "B2", 687, new[] { "Anthem", "Marş", "Himno", "Hymne", "Hymne", "Inno", "Hino", "賛歌", "찬가", "颂歌" }),

        // gaming (şablon 5, kategori 8)
        new(10402, "gaming_combo", 8, "A1", 688, new[] { "Combo", "Kombo", "Combo", "Combo", "Combo", "Combo", "Combo", "コンボ", "콤보", "连击" }),
        new(10403, "gaming_score", 8, "A1", 689, new[] { "Score", "Skor", "Puntuación", "Score", "Punktzahl", "Punteggio", "Pontuação", "スコア", "점수", "分数" }),
        new(10404, "gaming_save", 8, "A1", 690, new[] { "Save", "Kaydetmek", "Guardar", "Sauvegarder", "Speichern", "Salvare", "Salvar", "セーブ", "저장", "保存" }),
        new(10405, "gaming_character", 8, "A2", 691, new[] { "Character", "Karakter", "Personaje", "Personnage", "Charakter", "Personaggio", "Personagem", "キャラクター", "캐릭터", "角色" }),
        new(10406, "gaming_powerup", 8, "A2", 692, new[] { "Power-up", "Güçlendirme", "Power-up", "Bonus", "Power-up", "Power-up", "Power-up", "パワーアップ", "파워업", "能量提升" }),
        new(10407, "gaming_avatar", 8, "B1", 693, new[] { "Avatar", "Avatar", "Avatar", "Avatar", "Avatar", "Avatar", "Avatar", "アバター", "아바타", "头像" }),
        new(10408, "gaming_joystick", 8, "B1+", 694, new[] { "Joystick", "Joystick", "Joystick", "Joystick", "Joystick", "Joystick", "Joystick", "ジョイスティック", "조이스틱", "摇杆" }),
        new(10409, "gaming_multiplayer", 8, "B2", 695, new[] { "Multiplayer", "Çok oyunculu", "Multijugador", "Multijoueur", "Mehrspieler", "Multigiocatore", "Multijogador", "マルチプレイヤー", "멀티플레이어", "多人游戏" }),

        // sports (şablon 6, kategori 9)
        new(10410, "sports_whistle", 9, "A1", 696, new[] { "Whistle", "Düdük", "Silbato", "Sifflet", "Pfeife", "Fischietto", "Apito", "笛", "호루라기", "哨子" }),
        new(10411, "sports_sprint", 9, "A1", 697, new[] { "Sprint", "Sprint", "Esprint", "Sprint", "Sprint", "Scatto", "Sprint", "短距離走", "단거리 달리기", "冲刺" }),
        new(10412, "sports_jersey", 9, "A1", 698, new[] { "Jersey", "Forma", "Camiseta deportiva", "Maillot", "Trikot", "Maglia", "Camisa de time", "ユニフォーム", "유니폼", "球衣" }),
        new(10413, "sports_captain", 9, "A2", 699, new[] { "Captain", "Kaptan", "Capitán", "Capitaine", "Kapitän", "Capitano", "Capitão", "キャプテン", "주장", "队长" }),
        new(10414, "sports_arena", 9, "A2", 700, new[] { "Arena", "Arena", "Arena", "Arène", "Arena", "Arena", "Arena", "アリーナ", "경기장", "竞技场" }),
        new(10415, "sports_spectator", 9, "B1", 701, new[] { "Spectator", "Seyirci", "Espectador", "Spectateur", "Zuschauer", "Spettatore", "Espectador", "観客", "관중", "观众" }),
        new(10416, "sports_medal", 9, "B1+", 702, new[] { "Medal", "Madalya", "Medalla", "Médaille", "Medaille", "Medaglia", "Medalha", "メダル", "메달", "奖牌" }),
        new(10417, "sports_trophy", 9, "B2", 703, new[] { "Trophy", "Kupa", "Trofeo", "Trophée", "Trophäe", "Trofeo", "Troféu", "トロフィー", "트로피", "奖杯" }),

        // health (şablon 7, kategori 10)
        new(10418, "health_pain", 10, "A1", 704, new[] { "Pain", "Ağrı", "Dolor", "Douleur", "Schmerz", "Dolore", "Dor", "痛み", "통증", "疼痛" }),
        new(10419, "health_fever", 10, "A1", 705, new[] { "Fever", "Ateş", "Fiebre", "Fièvre", "Fieber", "Febbre", "Febre", "熱", "열", "发烧" }),
        new(10420, "health_hospital", 10, "A1", 706, new[] { "Hospital", "Hastane", "Hospital", "Hôpital", "Krankenhaus", "Ospedale", "Hospital", "病院", "병원", "医院" }),
        new(10421, "health_headache", 10, "A2", 707, new[] { "Headache", "Baş ağrısı", "Dolor de cabeza", "Mal de tête", "Kopfschmerzen", "Mal di testa", "Dor de cabeça", "頭痛", "두통", "头痛" }),
        new(10422, "health_medicine", 10, "A2", 708, new[] { "Medicine", "İlaç", "Medicina", "Médicament", "Medizin", "Medicina", "Remédio", "薬", "약", "药" }),
        new(10423, "health_ambulance", 10, "B1", 709, new[] { "Ambulance", "Ambulans", "Ambulancia", "Ambulance", "Krankenwagen", "Ambulanza", "Ambulância", "救急車", "구급차", "救护车" }),
        new(10424, "health_dizzy", 10, "B1+", 710, new[] { "Dizzy", "Baş dönmesi hisseden", "Mareado", "Étourdi", "Schwindelig", "Stordito", "Tonto", "めまいがする", "어지러운", "头晕" }),
        new(10425, "health_bandage", 10, "B2", 711, new[] { "Bandage", "Bandaj", "Vendaje", "Bandage", "Verband", "Benda", "Bandagem", "包帯", "붕대", "绷带" }),

        // shopping (şablon 8, kategori 11)
        new(10426, "shopping_label", 11, "A1", 712, new[] { "Label", "Etiket", "Etiqueta", "Étiquette", "Etikett", "Etichetta", "Etiqueta", "ラベル", "라벨", "标签" }),
        new(10427, "shopping_coupon", 11, "A1", 713, new[] { "Coupon", "Kupon", "Cupón", "Coupon", "Gutschein", "Buono sconto", "Cupom", "クーポン", "쿠폰", "优惠券" }),
        new(10428, "shopping_cart", 11, "A1", 714, new[] { "Cart", "Alışveriş sepeti", "Carrito", "Chariot", "Einkaufswagen", "Carrello", "Carrinho", "カート", "카트", "购物车" }),
        new(10429, "shopping_voucher", 11, "A2", 715, new[] { "Voucher", "Hediye çeki", "Vale", "Bon d'achat", "Gutscheinschein", "Buono", "Vale", "引換券", "상품권", "代金券" }),
        new(10430, "shopping_barcode", 11, "A2", 716, new[] { "Barcode", "Barkod", "Código de barras", "Code-barres", "Strichcode", "Codice a barre", "Código de barras", "バーコード", "바코드", "条形码" }),
        new(10431, "shopping_cashier", 11, "B1", 717, new[] { "Cashier", "Kasiyer", "Cajero", "Caissier", "Kassierer", "Cassiere", "Caixa", "レジ係", "계산원", "收银员" }),
        new(10432, "shopping_loyalty_card", 11, "B1+", 718, new[] { "Loyalty card", "Sadakat kartı", "Tarjeta de fidelidad", "Carte de fidélité", "Kundenkarte", "Carta fedeltà", "Cartão fidelidade", "会員カード", "멤버십 카드", "会员卡" }),
        new(10433, "shopping_checkout", 11, "B2", 719, new[] { "Checkout", "Ödeme noktası", "Caja", "Caisse", "Kasse", "Cassa", "Checkout", "レジ", "계산대", "结账" }),

        // nature (şablon 9, kategori 13)
        new(10434, "nature_peak", 13, "A1", 720, new[] { "Peak", "Zirve", "Cima", "Sommet", "Gipfel", "Vetta", "Cume", "山頂", "정상", "山顶" }),
        new(10435, "nature_stream", 13, "A1", 721, new[] { "Stream", "Dere", "Arroyo", "Ruisseau", "Bach", "Ruscello", "Riacho", "小川", "개울", "小溪" }),
        new(10436, "nature_cave", 13, "A1", 722, new[] { "Cave", "Mağara", "Cueva", "Grotte", "Höhle", "Grotta", "Caverna", "洞窟", "동굴", "洞穴" }),
        new(10437, "nature_ocean", 13, "A2", 723, new[] { "Ocean", "Okyanus", "Océano", "Océan", "Ozean", "Oceano", "Oceano", "海洋", "대양", "海洋" }),
        new(10438, "nature_coast", 13, "A2", 724, new[] { "Coast", "Kıyı", "Costa", "Côte", "Küste", "Costa", "Costa", "海岸", "해안", "海岸" }),
        new(10439, "nature_canyon", 13, "B1", 725, new[] { "Canyon", "Kanyon", "Cañón", "Canyon", "Schlucht", "Canyon", "Cânion", "峡谷", "협곡", "峡谷" }),
        new(10440, "nature_dune", 13, "B1+", 726, new[] { "Dune", "Kumul", "Duna", "Dune", "Düne", "Duna", "Duna", "砂丘", "모래언덕", "沙丘" }),
        new(10441, "nature_cliff", 13, "B2", 727, new[] { "Cliff", "Uçurum", "Acantilado", "Falaise", "Klippe", "Scogliera", "Penhasco", "崖", "절벽", "悬崖" }),

        // science (şablon 10, kategori 14)
        new(10442, "science_magnet", 14, "A1", 728, new[] { "Magnet", "Mıknatıs", "Imán", "Aimant", "Magnet", "Magnete", "Ímã", "磁石", "자석", "磁铁" }),
        new(10443, "science_orbit", 14, "A1", 729, new[] { "Orbit", "Yörünge", "Órbita", "Orbite", "Umlaufbahn", "Orbita", "Órbita", "軌道", "궤도", "轨道" }),
        new(10444, "science_crystal", 14, "A1", 730, new[] { "Crystal", "Kristal", "Cristal", "Cristal", "Kristall", "Cristallo", "Cristal", "結晶", "결정", "晶体" }),
        new(10445, "science_microscope", 14, "A2", 731, new[] { "Microscope", "Mikroskop", "Microscopio", "Microscope", "Mikroskop", "Microscopio", "Microscópio", "顕微鏡", "현미경", "显微镜" }),
        new(10446, "science_observatory", 14, "A2", 732, new[] { "Observatory", "Gözlemevi", "Observatorio", "Observatoire", "Sternwarte", "Osservatorio", "Observatório", "天文台", "천문대", "天文台" }),
        new(10447, "science_telescope", 14, "B1", 733, new[] { "Telescope", "Teleskop", "Telescopio", "Télescope", "Teleskop", "Telescopio", "Telescópio", "望遠鏡", "망원경", "望远镜" }),
        new(10448, "science_particle", 14, "B1+", 734, new[] { "Particle", "Parçacık", "Partícula", "Particule", "Teilchen", "Particella", "Partícula", "粒子", "입자", "粒子" }),
        new(10449, "science_friction", 14, "B2", 735, new[] { "Friction", "Sürtünme", "Fricción", "Friction", "Reibung", "Attrito", "Atrito", "摩擦", "마찰", "摩擦" }),

        // animals (şablon 11, kategori 15)
        new(10450, "animals_panda", 15, "A1", 736, new[] { "Panda", "Panda", "Panda", "Panda", "Panda", "Panda", "Panda", "パンダ", "판다", "熊猫" }),
        new(10451, "animals_kangaroo", 15, "A1", 737, new[] { "Kangaroo", "Kanguru", "Canguro", "Kangourou", "Känguru", "Canguro", "Canguru", "カンガルー", "캥거루", "袋鼠" }),
        new(10452, "animals_koala", 15, "A1", 738, new[] { "Koala", "Koala", "Koala", "Koala", "Koala", "Koala", "Coala", "コアラ", "코알라", "考拉" }),
        new(10453, "animals_zebra", 15, "A2", 739, new[] { "Zebra", "Zebra", "Cebra", "Zèbre", "Zebra", "Zebra", "Zebra", "シマウマ", "얼룩말", "斑马" }),
        new(10454, "animals_giraffe", 15, "A2", 740, new[] { "Giraffe", "Zürafa", "Jirafa", "Girafe", "Giraffe", "Giraffa", "Girafa", "キリン", "기린", "长颈鹿" }),
        new(10455, "animals_tiger", 15, "B1", 741, new[] { "Tiger", "Kaplan", "Tigre", "Tigre", "Tiger", "Tigre", "Tigre", "虎", "호랑이", "老虎" }),
        new(10456, "animals_fox", 15, "B1+", 742, new[] { "Fox", "Tilki", "Zorro", "Renard", "Fuchs", "Volpe", "Raposa", "キツネ", "여우", "狐狸" }),
        new(10457, "animals_turtle", 15, "B2", 743, new[] { "Turtle", "Kaplumbağa", "Tortuga", "Tortue", "Schildkröte", "Tartaruga", "Tartaruga", "亀", "거북이", "乌龟" }),

        // food (şablon 12, kategori 1)
        new(10458, "food_lunch", 1, "A1", 744, new[] { "Lunch", "Öğle yemeği", "Almuerzo", "Déjeuner", "Mittagessen", "Pranzo", "Almoço", "昼食", "점심", "午餐" }),
        new(10459, "food_dinner", 1, "A1", 745, new[] { "Dinner", "Akşam yemeği", "Cena", "Dîner", "Abendessen", "Cena", "Jantar", "夕食", "저녁 식사", "晚餐" }),
        new(10460, "food_soup", 1, "A1", 746, new[] { "Soup", "Çorba", "Sopa", "Soupe", "Suppe", "Zuppa", "Sopa", "スープ", "수프", "汤" }),
        new(10461, "food_snack", 1, "A2", 747, new[] { "Snack", "Atıştırmalık", "Aperitivo", "Collation", "Snack", "Spuntino", "Lanche", "おやつ", "간식", "零食" }),
        new(10462, "food_beverage", 1, "A2", 748, new[] { "Beverage", "İçecek", "Bebida", "Boisson", "Getränk", "Bevanda", "Bebida", "飲み物", "음료", "饮料" }),
        new(10463, "food_bakery", 1, "B1", 749, new[] { "Bakery", "Fırın", "Panadería", "Boulangerie", "Bäckerei", "Panetteria", "Padaria", "パン屋", "빵집", "面包店" }),
        new(10464, "food_appetizer", 1, "B1+", 750, new[] { "Appetizer", "Meze", "Entrante", "Entrée", "Vorspeise", "Antipasto", "Entrada", "前菜", "애피타이저", "开胃菜" }),
        new(10465, "food_grocery", 1, "B2", 751, new[] { "Grocery", "Bakkaliye", "Comestibles", "Épicerie", "Lebensmittel", "Generi alimentari", "Mercearia", "食料品", "식료품", "食品杂货" }),

        // travel (şablon 13, kategori 2)
        new(10466, "travel_hotel", 2, "A1", 752, new[] { "Hotel", "Otel", "Hotel", "Hôtel", "Hotel", "Hotel", "Hotel", "ホテル", "호텔", "酒店" }),
        new(10467, "travel_map", 2, "A1", 753, new[] { "Map", "Harita", "Mapa", "Carte", "Karte", "Mappa", "Mapa", "地図", "지도", "地图" }),
        new(10468, "travel_airport", 2, "A1", 754, new[] { "Airport", "Havalimanı", "Aeropuerto", "Aéroport", "Flughafen", "Aeroporto", "Aeroporto", "空港", "공항", "机场" }),
        new(10469, "travel_passport", 2, "A2", 755, new[] { "Passport", "Pasaport", "Pasaporte", "Passeport", "Reisepass", "Passaporto", "Passaporte", "パスポート", "여권", "护照" }),
        new(10470, "travel_luggage", 2, "A2", 756, new[] { "Luggage", "Bagaj", "Equipaje", "Bagages", "Gepäck", "Bagaglio", "Bagagem", "荷物", "짐", "行李" }),
        new(10471, "travel_tourist", 2, "B1", 757, new[] { "Tourist", "Turist", "Turista", "Touriste", "Tourist", "Turista", "Turista", "観光客", "관광객", "游客" }),
        new(10472, "travel_ticket", 2, "B1+", 758, new[] { "Ticket", "Bilet", "Billete", "Billet", "Ticket", "Biglietto", "Bilhete", "チケット", "티켓", "票" }),
        new(10473, "travel_souvenir", 2, "B2", 759, new[] { "Souvenir", "Hediyelik eşya", "Recuerdo", "Souvenir", "Andenken", "Souvenir", "Lembrança", "お土産", "기념품", "纪念品" }),

        // business (şablon 14, kategori 3)
        new(10474, "business_meeting", 3, "A1", 760, new[] { "Meeting", "Toplantı", "Reunión", "Réunion", "Besprechung", "Riunione", "Reunião", "会議", "회의", "会议" }),
        new(10475, "business_salary", 3, "A1", 761, new[] { "Salary", "Maaş", "Salario", "Salaire", "Gehalt", "Stipendio", "Salário", "給料", "급여", "工资" }),
        new(10476, "business_vendor", 3, "A1", 762, new[] { "Vendor", "Satıcı", "Vendedor", "Marchand", "Verkäufer", "Venditore", "Vendedor", "販売業者", "판매업체", "商家" }),
        new(10477, "business_coworker", 3, "A2", 763, new[] { "Coworker", "İş arkadaşı", "Compañero de trabajo", "Collègue de travail", "Arbeitskollege", "Collega di lavoro", "Colega de trabalho", "同僚", "직장 동료", "同事" }),
        new(10478, "business_deadline", 3, "A2", 764, new[] { "Deadline", "Son teslim tarihi", "Fecha límite", "Date limite", "Frist", "Scadenza", "Prazo", "締め切り", "마감일", "截止日期" }),
        new(10479, "business_payroll", 3, "B1", 765, new[] { "Payroll", "Bordro", "Nómina", "Paie", "Gehaltsabrechnung", "Libro paga", "Folha de pagamento", "給与計算", "급여 명부", "工资单" }),
        new(10480, "business_invoice", 3, "B1+", 766, new[] { "Invoice", "Fatura", "Factura", "Facture", "Rechnung", "Fattura", "Fatura", "請求書", "청구서", "发票" }),
        new(10481, "business_budget", 3, "B2", 767, new[] { "Budget", "Bütçe", "Presupuesto", "Budget", "Budget", "Bilancio", "Orçamento", "予算", "예산", "预算" }),

        // family (şablon 15, kategori 12)
        new(10482, "family_toddler", 12, "A1", 768, new[] { "Toddler", "Yeni yürüyen çocuk", "Niño pequeño", "Tout-petit", "Kleinkind", "Bambino piccolo", "Criança pequena", "幼児", "유아", "幼儿" }),
        new(10483, "family_godfather", 12, "A1", 769, new[] { "Godfather", "Vaftiz babası", "Padrino", "Parrain", "Pate", "Padrino", "Padrinho", "名付け親（男性）", "대부", "教父" }),
        new(10484, "family_godmother", 12, "A1", 770, new[] { "Godmother", "Vaftiz annesi", "Madrina", "Marraine", "Patin", "Madrina", "Madrinha", "名付け親（女性）", "대모", "教母" }),
        new(10485, "family_stepmother", 12, "A2", 771, new[] { "Stepmother", "Üvey anne", "Madrastra", "Belle-mère", "Stiefmutter", "Matrigna", "Madrasta", "継母", "새어머니", "继母" }),
        new(10486, "family_stepfather", 12, "A2", 772, new[] { "Stepfather", "Üvey baba", "Padrastro", "Beau-père", "Stiefvater", "Patrigno", "Padrasto", "継父", "새아버지", "继父" }),
        new(10487, "family_stepbrother", 12, "B1", 773, new[] { "Stepbrother", "Üvey erkek kardeş", "Hermanastro", "Demi-frère", "Stiefbruder", "Fratellastro", "Meio-irmão", "異父（母）兄弟", "이복형제", "继兄弟" }),
        new(10488, "family_husband", 12, "B1+", 774, new[] { "Husband", "Koca", "Esposo", "Mari", "Ehemann", "Marito", "Marido", "夫", "남편", "丈夫" }),
        new(10489, "family_wife", 12, "B2", 775, new[] { "Wife", "Eş", "Esposa", "Épouse", "Ehefrau", "Moglie", "Esposa", "妻", "아내", "妻子" }),
    };

    /// <summary>
    /// Hangi sekiz yeni kavramın hangi şablona eklendiği, şablonun mevcut 36
    /// üyesinin ardından 37-44 sıralı olarak. Şablon kimlikleri ve CEFR
    /// seviyeleri <see cref="CategoryCatalogSeedData.Templates"/> ile aynı
    /// on beşli sırayı izliyor.
    /// </summary>
    private static readonly TemplateAddition[] Additions =
    {
        new(1, new[] { 10370, 10371, 10372, 10373, 10374, 10375, 10376, 10377 }, new[] { "A1", "A1", "A1", "A2", "A2", "B1", "B1+", "B2" }),
        new(2, new[] { 10378, 10379, 10380, 10381, 10382, 10383, 10384, 10385 }, new[] { "A1", "A1", "A1", "A2", "A2", "B1", "B1+", "B2" }),
        new(3, new[] { 10386, 10387, 10388, 10389, 10390, 10391, 10392, 10393 }, new[] { "A1", "A1", "A1", "A2", "A2", "B1", "B1+", "B2" }),
        new(4, new[] { 10394, 10395, 10396, 10397, 10398, 10399, 10400, 10401 }, new[] { "A1", "A1", "A1", "A2", "A2", "B1", "B1+", "B2" }),
        new(5, new[] { 10402, 10403, 10404, 10405, 10406, 10407, 10408, 10409 }, new[] { "A1", "A1", "A1", "A2", "A2", "B1", "B1+", "B2" }),
        new(6, new[] { 10410, 10411, 10412, 10413, 10414, 10415, 10416, 10417 }, new[] { "A1", "A1", "A1", "A2", "A2", "B1", "B1+", "B2" }),
        new(7, new[] { 10418, 10419, 10420, 10421, 10422, 10423, 10424, 10425 }, new[] { "A1", "A1", "A1", "A2", "A2", "B1", "B1+", "B2" }),
        new(8, new[] { 10426, 10427, 10428, 10429, 10430, 10431, 10432, 10433 }, new[] { "A1", "A1", "A1", "A2", "A2", "B1", "B1+", "B2" }),
        new(9, new[] { 10434, 10435, 10436, 10437, 10438, 10439, 10440, 10441 }, new[] { "A1", "A1", "A1", "A2", "A2", "B1", "B1+", "B2" }),
        new(10, new[] { 10442, 10443, 10444, 10445, 10446, 10447, 10448, 10449 }, new[] { "A1", "A1", "A1", "A2", "A2", "B1", "B1+", "B2" }),
        new(11, new[] { 10450, 10451, 10452, 10453, 10454, 10455, 10456, 10457 }, new[] { "A1", "A1", "A1", "A2", "A2", "B1", "B1+", "B2" }),
        new(12, new[] { 10458, 10459, 10460, 10461, 10462, 10463, 10464, 10465 }, new[] { "A1", "A1", "A1", "A2", "A2", "B1", "B1+", "B2" }),
        new(13, new[] { 10466, 10467, 10468, 10469, 10470, 10471, 10472, 10473 }, new[] { "A1", "A1", "A1", "A2", "A2", "B1", "B1+", "B2" }),
        new(14, new[] { 10474, 10475, 10476, 10477, 10478, 10479, 10480, 10481 }, new[] { "A1", "A1", "A1", "A2", "A2", "B1", "B1+", "B2" }),
        new(15, new[] { 10482, 10483, 10484, 10485, 10486, 10487, 10488, 10489 }, new[] { "A1", "A1", "A1", "A2", "A2", "B1", "B1+", "B2" }),
    };

    /// <summary>
    /// <see cref="Concept"/>, <see cref="ConceptTranslation"/> ve
    /// <see cref="DeckTemplateConcept"/> için ek <c>HasData</c> satırları.
    /// Dört varlık türü de (<see cref="DeckTemplate"/> dahil) ilişkileriyle
    /// birlikte zaten <see cref="AppDbContext"/> ve
    /// <see cref="CategoryCatalogSeedData"/> tarafından yapılandırıldı; bu
    /// metot yalnızca veri ekliyor, yeniden yapılandırma yapmıyor.
    /// </summary>
    public static void Apply(ModelBuilder modelBuilder)
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
        modelBuilder.Entity<ConceptTranslation>().HasData(translations);

        var members = new List<DeckTemplateConcept>();
        foreach (var addition in Additions)
        {
            for (var i = 0; i < addition.ConceptIds.Length; i++)
            {
                members.Add(new DeckTemplateConcept
                {
                    DeckTemplateId = addition.TemplateId,
                    ConceptId = addition.ConceptIds[i],
                    Ordinal = 37 + i,
                    CefrLevel = addition.CefrLevels[i]
                });
            }
        }
        modelBuilder.Entity<DeckTemplateConcept>().HasData(members);
    }
}
