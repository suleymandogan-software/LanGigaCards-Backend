using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LanGigaCards.Api.Migrations
{
    /// <inheritdoc />
    public partial class ExpandCategoryDeckVocabulary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Concepts",
                columns: new[] { "Id", "CategoryId", "Key", "Level", "OrderIndex" },
                values: new object[,]
                {
                    { 10370, 4, "technology_laptop", "A1", 656 },
                    { 10371, 4, "technology_icon", "A1", 657 },
                    { 10372, 4, "technology_tablet", "A1", 658 },
                    { 10373, 4, "technology_notification", "A2", 659 },
                    { 10374, 4, "technology_app", "A2", 660 },
                    { 10375, 4, "technology_cursor", "B1", 661 },
                    { 10376, 4, "technology_mouse", "B1+", 662 },
                    { 10377, 4, "technology_wifi", "B2", 663 },
                    { 10378, 5, "education_pencil", "A1", 664 },
                    { 10379, 5, "education_eraser", "A1", 665 },
                    { 10380, 5, "education_principal", "A1", 666 },
                    { 10381, 5, "education_homework", "A2", 667 },
                    { 10382, 5, "education_bookshelf", "A2", 668 },
                    { 10383, 5, "education_exam", "B1", 669 },
                    { 10384, 5, "education_textbook", "B1+", 670 },
                    { 10385, 5, "education_blackboard", "B2", 671 },
                    { 10386, 6, "movies_actor", "A1", 672 },
                    { 10387, 6, "movies_actress", "A1", 673 },
                    { 10388, 6, "movies_villain", "A1", 674 },
                    { 10389, 6, "movies_screen", "A2", 675 },
                    { 10390, 6, "movies_scene", "A2", 676 },
                    { 10391, 6, "movies_subtitle", "B1", 677 },
                    { 10392, 6, "movies_spoiler", "B1+", 678 },
                    { 10393, 6, "movies_director", "B2", 679 },
                    { 10394, 7, "music_guitar", "A1", 680 },
                    { 10395, 7, "music_trumpet", "A1", 681 },
                    { 10396, 7, "music_duet", "A1", 682 },
                    { 10397, 7, "music_concert", "A2", 683 },
                    { 10398, 7, "music_headphones", "A2", 684 },
                    { 10399, 7, "music_microphone", "B1", 685 },
                    { 10400, 7, "music_chord", "B1+", 686 },
                    { 10401, 7, "music_anthem", "B2", 687 },
                    { 10402, 8, "gaming_combo", "A1", 688 },
                    { 10403, 8, "gaming_score", "A1", 689 },
                    { 10404, 8, "gaming_save", "A1", 690 },
                    { 10405, 8, "gaming_character", "A2", 691 },
                    { 10406, 8, "gaming_powerup", "A2", 692 },
                    { 10407, 8, "gaming_avatar", "B1", 693 },
                    { 10408, 8, "gaming_joystick", "B1+", 694 },
                    { 10409, 8, "gaming_multiplayer", "B2", 695 },
                    { 10410, 9, "sports_whistle", "A1", 696 },
                    { 10411, 9, "sports_sprint", "A1", 697 },
                    { 10412, 9, "sports_jersey", "A1", 698 },
                    { 10413, 9, "sports_captain", "A2", 699 },
                    { 10414, 9, "sports_arena", "A2", 700 },
                    { 10415, 9, "sports_spectator", "B1", 701 },
                    { 10416, 9, "sports_medal", "B1+", 702 },
                    { 10417, 9, "sports_trophy", "B2", 703 },
                    { 10418, 10, "health_pain", "A1", 704 },
                    { 10419, 10, "health_fever", "A1", 705 },
                    { 10420, 10, "health_hospital", "A1", 706 },
                    { 10421, 10, "health_headache", "A2", 707 },
                    { 10422, 10, "health_medicine", "A2", 708 },
                    { 10423, 10, "health_ambulance", "B1", 709 },
                    { 10424, 10, "health_dizzy", "B1+", 710 },
                    { 10425, 10, "health_bandage", "B2", 711 },
                    { 10426, 11, "shopping_label", "A1", 712 },
                    { 10427, 11, "shopping_coupon", "A1", 713 },
                    { 10428, 11, "shopping_cart", "A1", 714 },
                    { 10429, 11, "shopping_voucher", "A2", 715 },
                    { 10430, 11, "shopping_barcode", "A2", 716 },
                    { 10431, 11, "shopping_cashier", "B1", 717 },
                    { 10432, 11, "shopping_loyalty_card", "B1+", 718 },
                    { 10433, 11, "shopping_checkout", "B2", 719 },
                    { 10434, 13, "nature_peak", "A1", 720 },
                    { 10435, 13, "nature_stream", "A1", 721 },
                    { 10436, 13, "nature_cave", "A1", 722 },
                    { 10437, 13, "nature_ocean", "A2", 723 },
                    { 10438, 13, "nature_coast", "A2", 724 },
                    { 10439, 13, "nature_canyon", "B1", 725 },
                    { 10440, 13, "nature_dune", "B1+", 726 },
                    { 10441, 13, "nature_cliff", "B2", 727 },
                    { 10442, 14, "science_magnet", "A1", 728 },
                    { 10443, 14, "science_orbit", "A1", 729 },
                    { 10444, 14, "science_crystal", "A1", 730 },
                    { 10445, 14, "science_microscope", "A2", 731 },
                    { 10446, 14, "science_observatory", "A2", 732 },
                    { 10447, 14, "science_telescope", "B1", 733 },
                    { 10448, 14, "science_particle", "B1+", 734 },
                    { 10449, 14, "science_friction", "B2", 735 },
                    { 10450, 15, "animals_panda", "A1", 736 },
                    { 10451, 15, "animals_kangaroo", "A1", 737 },
                    { 10452, 15, "animals_koala", "A1", 738 },
                    { 10453, 15, "animals_zebra", "A2", 739 },
                    { 10454, 15, "animals_giraffe", "A2", 740 },
                    { 10455, 15, "animals_tiger", "B1", 741 },
                    { 10456, 15, "animals_fox", "B1+", 742 },
                    { 10457, 15, "animals_turtle", "B2", 743 },
                    { 10458, 1, "food_lunch", "A1", 744 },
                    { 10459, 1, "food_dinner", "A1", 745 },
                    { 10460, 1, "food_soup", "A1", 746 },
                    { 10461, 1, "food_snack", "A2", 747 },
                    { 10462, 1, "food_beverage", "A2", 748 },
                    { 10463, 1, "food_bakery", "B1", 749 },
                    { 10464, 1, "food_appetizer", "B1+", 750 },
                    { 10465, 1, "food_grocery", "B2", 751 },
                    { 10466, 2, "travel_hotel", "A1", 752 },
                    { 10467, 2, "travel_map", "A1", 753 },
                    { 10468, 2, "travel_airport", "A1", 754 },
                    { 10469, 2, "travel_passport", "A2", 755 },
                    { 10470, 2, "travel_luggage", "A2", 756 },
                    { 10471, 2, "travel_tourist", "B1", 757 },
                    { 10472, 2, "travel_ticket", "B1+", 758 },
                    { 10473, 2, "travel_souvenir", "B2", 759 },
                    { 10474, 3, "business_meeting", "A1", 760 },
                    { 10475, 3, "business_salary", "A1", 761 },
                    { 10476, 3, "business_vendor", "A1", 762 },
                    { 10477, 3, "business_coworker", "A2", 763 },
                    { 10478, 3, "business_deadline", "A2", 764 },
                    { 10479, 3, "business_payroll", "B1", 765 },
                    { 10480, 3, "business_invoice", "B1+", 766 },
                    { 10481, 3, "business_budget", "B2", 767 },
                    { 10482, 12, "family_toddler", "A1", 768 },
                    { 10483, 12, "family_godfather", "A1", 769 },
                    { 10484, 12, "family_godmother", "A1", 770 },
                    { 10485, 12, "family_stepmother", "A2", 771 },
                    { 10486, 12, "family_stepfather", "A2", 772 },
                    { 10487, 12, "family_stepbrother", "B1", 773 },
                    { 10488, 12, "family_husband", "B1+", 774 },
                    { 10489, 12, "family_wife", "B2", 775 }
                });

            migrationBuilder.InsertData(
                table: "ConceptTranslations",
                columns: new[] { "ConceptId", "LanguageCode", "AudioUrl", "ExampleSentence", "Term" },
                values: new object[,]
                {
                    { 10370, "de", null, null, "Laptop" },
                    { 10370, "en", null, null, "Laptop" },
                    { 10370, "es", null, null, "Portátil" },
                    { 10370, "fr", null, null, "Ordinateur portable" },
                    { 10370, "it", null, null, "Portatile" },
                    { 10370, "ja", null, null, "ノートパソコン" },
                    { 10370, "ko", null, null, "노트북" },
                    { 10370, "pt", null, null, "Laptop" },
                    { 10370, "tr", null, null, "Dizüstü bilgisayar" },
                    { 10370, "zh", null, null, "笔记本电脑" },
                    { 10371, "de", null, null, "Symbol" },
                    { 10371, "en", null, null, "Icon" },
                    { 10371, "es", null, null, "Icono" },
                    { 10371, "fr", null, null, "Icône" },
                    { 10371, "it", null, null, "Icona" },
                    { 10371, "ja", null, null, "アイコン" },
                    { 10371, "ko", null, null, "아이콘" },
                    { 10371, "pt", null, null, "Ícone" },
                    { 10371, "tr", null, null, "Simge" },
                    { 10371, "zh", null, null, "图标" },
                    { 10372, "de", null, null, "Tablet" },
                    { 10372, "en", null, null, "Tablet" },
                    { 10372, "es", null, null, "Tableta" },
                    { 10372, "fr", null, null, "Tablette" },
                    { 10372, "it", null, null, "Tablet" },
                    { 10372, "ja", null, null, "タブレット" },
                    { 10372, "ko", null, null, "태블릿" },
                    { 10372, "pt", null, null, "Tablet" },
                    { 10372, "tr", null, null, "Tablet" },
                    { 10372, "zh", null, null, "平板电脑" },
                    { 10373, "de", null, null, "Benachrichtigung" },
                    { 10373, "en", null, null, "Notification" },
                    { 10373, "es", null, null, "Notificación" },
                    { 10373, "fr", null, null, "Notification" },
                    { 10373, "it", null, null, "Notifica" },
                    { 10373, "ja", null, null, "通知" },
                    { 10373, "ko", null, null, "알림" },
                    { 10373, "pt", null, null, "Notificação" },
                    { 10373, "tr", null, null, "Bildirim" },
                    { 10373, "zh", null, null, "通知" },
                    { 10374, "de", null, null, "App" },
                    { 10374, "en", null, null, "App" },
                    { 10374, "es", null, null, "Aplicación" },
                    { 10374, "fr", null, null, "Application" },
                    { 10374, "it", null, null, "App" },
                    { 10374, "ja", null, null, "アプリ" },
                    { 10374, "ko", null, null, "앱" },
                    { 10374, "pt", null, null, "Aplicativo" },
                    { 10374, "tr", null, null, "Uygulama" },
                    { 10374, "zh", null, null, "应用程序" },
                    { 10375, "de", null, null, "Cursor" },
                    { 10375, "en", null, null, "Cursor" },
                    { 10375, "es", null, null, "Cursor" },
                    { 10375, "fr", null, null, "Curseur" },
                    { 10375, "it", null, null, "Cursore" },
                    { 10375, "ja", null, null, "カーソル" },
                    { 10375, "ko", null, null, "커서" },
                    { 10375, "pt", null, null, "Cursor" },
                    { 10375, "tr", null, null, "İmleç" },
                    { 10375, "zh", null, null, "光标" },
                    { 10376, "de", null, null, "Maus" },
                    { 10376, "en", null, null, "Mouse" },
                    { 10376, "es", null, null, "Ratón" },
                    { 10376, "fr", null, null, "Souris" },
                    { 10376, "it", null, null, "Mouse" },
                    { 10376, "ja", null, null, "マウス" },
                    { 10376, "ko", null, null, "마우스" },
                    { 10376, "pt", null, null, "Mouse" },
                    { 10376, "tr", null, null, "Fare" },
                    { 10376, "zh", null, null, "鼠标" },
                    { 10377, "de", null, null, "WLAN" },
                    { 10377, "en", null, null, "Wifi" },
                    { 10377, "es", null, null, "Wifi" },
                    { 10377, "fr", null, null, "Wifi" },
                    { 10377, "it", null, null, "Wifi" },
                    { 10377, "ja", null, null, "Wi-Fi" },
                    { 10377, "ko", null, null, "와이파이" },
                    { 10377, "pt", null, null, "Wifi" },
                    { 10377, "tr", null, null, "Wifi" },
                    { 10377, "zh", null, null, "无线网络" },
                    { 10378, "de", null, null, "Bleistift" },
                    { 10378, "en", null, null, "Pencil" },
                    { 10378, "es", null, null, "Lápiz" },
                    { 10378, "fr", null, null, "Crayon" },
                    { 10378, "it", null, null, "Matita" },
                    { 10378, "ja", null, null, "鉛筆" },
                    { 10378, "ko", null, null, "연필" },
                    { 10378, "pt", null, null, "Lápis" },
                    { 10378, "tr", null, null, "Kalem" },
                    { 10378, "zh", null, null, "铅笔" },
                    { 10379, "de", null, null, "Radiergummi" },
                    { 10379, "en", null, null, "Eraser" },
                    { 10379, "es", null, null, "Goma de borrar" },
                    { 10379, "fr", null, null, "Gomme" },
                    { 10379, "it", null, null, "Gomma" },
                    { 10379, "ja", null, null, "消しゴム" },
                    { 10379, "ko", null, null, "지우개" },
                    { 10379, "pt", null, null, "Borracha" },
                    { 10379, "tr", null, null, "Silgi" },
                    { 10379, "zh", null, null, "橡皮擦" },
                    { 10380, "de", null, null, "Schulleiter" },
                    { 10380, "en", null, null, "Principal" },
                    { 10380, "es", null, null, "Director de escuela" },
                    { 10380, "fr", null, null, "Directeur d'école" },
                    { 10380, "it", null, null, "Preside" },
                    { 10380, "ja", null, null, "校長" },
                    { 10380, "ko", null, null, "교장" },
                    { 10380, "pt", null, null, "Diretor de escola" },
                    { 10380, "tr", null, null, "Okul müdürü" },
                    { 10380, "zh", null, null, "校长" },
                    { 10381, "de", null, null, "Hausaufgaben" },
                    { 10381, "en", null, null, "Homework" },
                    { 10381, "es", null, null, "Tarea" },
                    { 10381, "fr", null, null, "Devoirs" },
                    { 10381, "it", null, null, "Compiti" },
                    { 10381, "ja", null, null, "宿題" },
                    { 10381, "ko", null, null, "숙제" },
                    { 10381, "pt", null, null, "Dever de casa" },
                    { 10381, "tr", null, null, "Ev ödevi" },
                    { 10381, "zh", null, null, "作业" },
                    { 10382, "de", null, null, "Bücherregal" },
                    { 10382, "en", null, null, "Bookshelf" },
                    { 10382, "es", null, null, "Estantería" },
                    { 10382, "fr", null, null, "Étagère à livres" },
                    { 10382, "it", null, null, "Libreria" },
                    { 10382, "ja", null, null, "本棚" },
                    { 10382, "ko", null, null, "책장" },
                    { 10382, "pt", null, null, "Estante de livros" },
                    { 10382, "tr", null, null, "Kitaplık" },
                    { 10382, "zh", null, null, "书架" },
                    { 10383, "de", null, null, "Prüfung" },
                    { 10383, "en", null, null, "Exam" },
                    { 10383, "es", null, null, "Examen" },
                    { 10383, "fr", null, null, "Examen" },
                    { 10383, "it", null, null, "Esame" },
                    { 10383, "ja", null, null, "試験" },
                    { 10383, "ko", null, null, "시험" },
                    { 10383, "pt", null, null, "Exame" },
                    { 10383, "tr", null, null, "Sınav" },
                    { 10383, "zh", null, null, "考试" },
                    { 10384, "de", null, null, "Lehrbuch" },
                    { 10384, "en", null, null, "Textbook" },
                    { 10384, "es", null, null, "Libro de texto" },
                    { 10384, "fr", null, null, "Manuel scolaire" },
                    { 10384, "it", null, null, "Libro di testo" },
                    { 10384, "ja", null, null, "教科書" },
                    { 10384, "ko", null, null, "교과서" },
                    { 10384, "pt", null, null, "Livro didático" },
                    { 10384, "tr", null, null, "Ders kitabı" },
                    { 10384, "zh", null, null, "教科书" },
                    { 10385, "de", null, null, "Tafel" },
                    { 10385, "en", null, null, "Blackboard" },
                    { 10385, "es", null, null, "Pizarra" },
                    { 10385, "fr", null, null, "Tableau noir" },
                    { 10385, "it", null, null, "Lavagna" },
                    { 10385, "ja", null, null, "黒板" },
                    { 10385, "ko", null, null, "칠판" },
                    { 10385, "pt", null, null, "Quadro-negro" },
                    { 10385, "tr", null, null, "Kara tahta" },
                    { 10385, "zh", null, null, "黑板" },
                    { 10386, "de", null, null, "Schauspieler" },
                    { 10386, "en", null, null, "Actor" },
                    { 10386, "es", null, null, "Actor" },
                    { 10386, "fr", null, null, "Acteur" },
                    { 10386, "it", null, null, "Attore" },
                    { 10386, "ja", null, null, "俳優" },
                    { 10386, "ko", null, null, "배우" },
                    { 10386, "pt", null, null, "Ator" },
                    { 10386, "tr", null, null, "Aktör" },
                    { 10386, "zh", null, null, "男演员" },
                    { 10387, "de", null, null, "Schauspielerin" },
                    { 10387, "en", null, null, "Actress" },
                    { 10387, "es", null, null, "Actriz" },
                    { 10387, "fr", null, null, "Actrice" },
                    { 10387, "it", null, null, "Attrice" },
                    { 10387, "ja", null, null, "女優" },
                    { 10387, "ko", null, null, "여배우" },
                    { 10387, "pt", null, null, "Atriz" },
                    { 10387, "tr", null, null, "Aktris" },
                    { 10387, "zh", null, null, "女演员" },
                    { 10388, "de", null, null, "Bösewicht" },
                    { 10388, "en", null, null, "Villain" },
                    { 10388, "es", null, null, "Villano" },
                    { 10388, "fr", null, null, "Méchant" },
                    { 10388, "it", null, null, "Cattivo" },
                    { 10388, "ja", null, null, "悪役" },
                    { 10388, "ko", null, null, "악당" },
                    { 10388, "pt", null, null, "Vilão" },
                    { 10388, "tr", null, null, "Kötü karakter" },
                    { 10388, "zh", null, null, "反派" },
                    { 10389, "de", null, null, "Bildschirm" },
                    { 10389, "en", null, null, "Screen" },
                    { 10389, "es", null, null, "Pantalla" },
                    { 10389, "fr", null, null, "Écran" },
                    { 10389, "it", null, null, "Schermo" },
                    { 10389, "ja", null, null, "スクリーン" },
                    { 10389, "ko", null, null, "화면" },
                    { 10389, "pt", null, null, "Tela" },
                    { 10389, "tr", null, null, "Ekran" },
                    { 10389, "zh", null, null, "屏幕" },
                    { 10390, "de", null, null, "Szene" },
                    { 10390, "en", null, null, "Scene" },
                    { 10390, "es", null, null, "Escena" },
                    { 10390, "fr", null, null, "Scène" },
                    { 10390, "it", null, null, "Scena" },
                    { 10390, "ja", null, null, "シーン" },
                    { 10390, "ko", null, null, "장면" },
                    { 10390, "pt", null, null, "Cena" },
                    { 10390, "tr", null, null, "Sahne" },
                    { 10390, "zh", null, null, "场景" },
                    { 10391, "de", null, null, "Untertitel" },
                    { 10391, "en", null, null, "Subtitle" },
                    { 10391, "es", null, null, "Subtítulo" },
                    { 10391, "fr", null, null, "Sous-titre" },
                    { 10391, "it", null, null, "Sottotitolo" },
                    { 10391, "ja", null, null, "字幕" },
                    { 10391, "ko", null, null, "자막" },
                    { 10391, "pt", null, null, "Legenda" },
                    { 10391, "tr", null, null, "Altyazı" },
                    { 10391, "zh", null, null, "字幕" },
                    { 10392, "de", null, null, "Spoiler" },
                    { 10392, "en", null, null, "Spoiler" },
                    { 10392, "es", null, null, "Spoiler" },
                    { 10392, "fr", null, null, "Spoiler" },
                    { 10392, "it", null, null, "Spoiler" },
                    { 10392, "ja", null, null, "ネタバレ" },
                    { 10392, "ko", null, null, "스포일러" },
                    { 10392, "pt", null, null, "Spoiler" },
                    { 10392, "tr", null, null, "Spoiler" },
                    { 10392, "zh", null, null, "剧透" },
                    { 10393, "de", null, null, "Regisseur" },
                    { 10393, "en", null, null, "Director" },
                    { 10393, "es", null, null, "Director" },
                    { 10393, "fr", null, null, "Réalisateur" },
                    { 10393, "it", null, null, "Regista" },
                    { 10393, "ja", null, null, "監督" },
                    { 10393, "ko", null, null, "감독" },
                    { 10393, "pt", null, null, "Diretor" },
                    { 10393, "tr", null, null, "Yönetmen" },
                    { 10393, "zh", null, null, "导演" },
                    { 10394, "de", null, null, "Gitarre" },
                    { 10394, "en", null, null, "Guitar" },
                    { 10394, "es", null, null, "Guitarra" },
                    { 10394, "fr", null, null, "Guitare" },
                    { 10394, "it", null, null, "Chitarra" },
                    { 10394, "ja", null, null, "ギター" },
                    { 10394, "ko", null, null, "기타" },
                    { 10394, "pt", null, null, "Violão" },
                    { 10394, "tr", null, null, "Gitar" },
                    { 10394, "zh", null, null, "吉他" },
                    { 10395, "de", null, null, "Trompete" },
                    { 10395, "en", null, null, "Trumpet" },
                    { 10395, "es", null, null, "Trompeta" },
                    { 10395, "fr", null, null, "Trompette" },
                    { 10395, "it", null, null, "Tromba" },
                    { 10395, "ja", null, null, "トランペット" },
                    { 10395, "ko", null, null, "트럼펫" },
                    { 10395, "pt", null, null, "Trompete" },
                    { 10395, "tr", null, null, "Trompet" },
                    { 10395, "zh", null, null, "小号" },
                    { 10396, "de", null, null, "Duett" },
                    { 10396, "en", null, null, "Duet" },
                    { 10396, "es", null, null, "Dúo" },
                    { 10396, "fr", null, null, "Duo" },
                    { 10396, "it", null, null, "Duetto" },
                    { 10396, "ja", null, null, "デュエット" },
                    { 10396, "ko", null, null, "듀엣" },
                    { 10396, "pt", null, null, "Dueto" },
                    { 10396, "tr", null, null, "Düet" },
                    { 10396, "zh", null, null, "二重唱" },
                    { 10397, "de", null, null, "Konzert" },
                    { 10397, "en", null, null, "Concert" },
                    { 10397, "es", null, null, "Concierto" },
                    { 10397, "fr", null, null, "Concert" },
                    { 10397, "it", null, null, "Concerto" },
                    { 10397, "ja", null, null, "コンサート" },
                    { 10397, "ko", null, null, "콘서트" },
                    { 10397, "pt", null, null, "Concerto" },
                    { 10397, "tr", null, null, "Konser" },
                    { 10397, "zh", null, null, "音乐会" },
                    { 10398, "de", null, null, "Kopfhörer" },
                    { 10398, "en", null, null, "Headphones" },
                    { 10398, "es", null, null, "Auriculares" },
                    { 10398, "fr", null, null, "Écouteurs" },
                    { 10398, "it", null, null, "Cuffie" },
                    { 10398, "ja", null, null, "ヘッドフォン" },
                    { 10398, "ko", null, null, "헤드폰" },
                    { 10398, "pt", null, null, "Fones de ouvido" },
                    { 10398, "tr", null, null, "Kulaklık" },
                    { 10398, "zh", null, null, "耳机" },
                    { 10399, "de", null, null, "Mikrofon" },
                    { 10399, "en", null, null, "Microphone" },
                    { 10399, "es", null, null, "Micrófono" },
                    { 10399, "fr", null, null, "Microphone" },
                    { 10399, "it", null, null, "Microfono" },
                    { 10399, "ja", null, null, "マイク" },
                    { 10399, "ko", null, null, "마이크" },
                    { 10399, "pt", null, null, "Microfone" },
                    { 10399, "tr", null, null, "Mikrofon" },
                    { 10399, "zh", null, null, "麦克风" },
                    { 10400, "de", null, null, "Akkord" },
                    { 10400, "en", null, null, "Chord" },
                    { 10400, "es", null, null, "Acorde" },
                    { 10400, "fr", null, null, "Accord" },
                    { 10400, "it", null, null, "Accordo" },
                    { 10400, "ja", null, null, "コード" },
                    { 10400, "ko", null, null, "코드" },
                    { 10400, "pt", null, null, "Acorde" },
                    { 10400, "tr", null, null, "Akor" },
                    { 10400, "zh", null, null, "和弦" },
                    { 10401, "de", null, null, "Hymne" },
                    { 10401, "en", null, null, "Anthem" },
                    { 10401, "es", null, null, "Himno" },
                    { 10401, "fr", null, null, "Hymne" },
                    { 10401, "it", null, null, "Inno" },
                    { 10401, "ja", null, null, "賛歌" },
                    { 10401, "ko", null, null, "찬가" },
                    { 10401, "pt", null, null, "Hino" },
                    { 10401, "tr", null, null, "Marş" },
                    { 10401, "zh", null, null, "颂歌" },
                    { 10402, "de", null, null, "Combo" },
                    { 10402, "en", null, null, "Combo" },
                    { 10402, "es", null, null, "Combo" },
                    { 10402, "fr", null, null, "Combo" },
                    { 10402, "it", null, null, "Combo" },
                    { 10402, "ja", null, null, "コンボ" },
                    { 10402, "ko", null, null, "콤보" },
                    { 10402, "pt", null, null, "Combo" },
                    { 10402, "tr", null, null, "Kombo" },
                    { 10402, "zh", null, null, "连击" },
                    { 10403, "de", null, null, "Punktzahl" },
                    { 10403, "en", null, null, "Score" },
                    { 10403, "es", null, null, "Puntuación" },
                    { 10403, "fr", null, null, "Score" },
                    { 10403, "it", null, null, "Punteggio" },
                    { 10403, "ja", null, null, "スコア" },
                    { 10403, "ko", null, null, "점수" },
                    { 10403, "pt", null, null, "Pontuação" },
                    { 10403, "tr", null, null, "Skor" },
                    { 10403, "zh", null, null, "分数" },
                    { 10404, "de", null, null, "Speichern" },
                    { 10404, "en", null, null, "Save" },
                    { 10404, "es", null, null, "Guardar" },
                    { 10404, "fr", null, null, "Sauvegarder" },
                    { 10404, "it", null, null, "Salvare" },
                    { 10404, "ja", null, null, "セーブ" },
                    { 10404, "ko", null, null, "저장" },
                    { 10404, "pt", null, null, "Salvar" },
                    { 10404, "tr", null, null, "Kaydetmek" },
                    { 10404, "zh", null, null, "保存" },
                    { 10405, "de", null, null, "Charakter" },
                    { 10405, "en", null, null, "Character" },
                    { 10405, "es", null, null, "Personaje" },
                    { 10405, "fr", null, null, "Personnage" },
                    { 10405, "it", null, null, "Personaggio" },
                    { 10405, "ja", null, null, "キャラクター" },
                    { 10405, "ko", null, null, "캐릭터" },
                    { 10405, "pt", null, null, "Personagem" },
                    { 10405, "tr", null, null, "Karakter" },
                    { 10405, "zh", null, null, "角色" },
                    { 10406, "de", null, null, "Power-up" },
                    { 10406, "en", null, null, "Power-up" },
                    { 10406, "es", null, null, "Power-up" },
                    { 10406, "fr", null, null, "Bonus" },
                    { 10406, "it", null, null, "Power-up" },
                    { 10406, "ja", null, null, "パワーアップ" },
                    { 10406, "ko", null, null, "파워업" },
                    { 10406, "pt", null, null, "Power-up" },
                    { 10406, "tr", null, null, "Güçlendirme" },
                    { 10406, "zh", null, null, "能量提升" },
                    { 10407, "de", null, null, "Avatar" },
                    { 10407, "en", null, null, "Avatar" },
                    { 10407, "es", null, null, "Avatar" },
                    { 10407, "fr", null, null, "Avatar" },
                    { 10407, "it", null, null, "Avatar" },
                    { 10407, "ja", null, null, "アバター" },
                    { 10407, "ko", null, null, "아바타" },
                    { 10407, "pt", null, null, "Avatar" },
                    { 10407, "tr", null, null, "Avatar" },
                    { 10407, "zh", null, null, "头像" },
                    { 10408, "de", null, null, "Joystick" },
                    { 10408, "en", null, null, "Joystick" },
                    { 10408, "es", null, null, "Joystick" },
                    { 10408, "fr", null, null, "Joystick" },
                    { 10408, "it", null, null, "Joystick" },
                    { 10408, "ja", null, null, "ジョイスティック" },
                    { 10408, "ko", null, null, "조이스틱" },
                    { 10408, "pt", null, null, "Joystick" },
                    { 10408, "tr", null, null, "Joystick" },
                    { 10408, "zh", null, null, "摇杆" },
                    { 10409, "de", null, null, "Mehrspieler" },
                    { 10409, "en", null, null, "Multiplayer" },
                    { 10409, "es", null, null, "Multijugador" },
                    { 10409, "fr", null, null, "Multijoueur" },
                    { 10409, "it", null, null, "Multigiocatore" },
                    { 10409, "ja", null, null, "マルチプレイヤー" },
                    { 10409, "ko", null, null, "멀티플레이어" },
                    { 10409, "pt", null, null, "Multijogador" },
                    { 10409, "tr", null, null, "Çok oyunculu" },
                    { 10409, "zh", null, null, "多人游戏" },
                    { 10410, "de", null, null, "Pfeife" },
                    { 10410, "en", null, null, "Whistle" },
                    { 10410, "es", null, null, "Silbato" },
                    { 10410, "fr", null, null, "Sifflet" },
                    { 10410, "it", null, null, "Fischietto" },
                    { 10410, "ja", null, null, "笛" },
                    { 10410, "ko", null, null, "호루라기" },
                    { 10410, "pt", null, null, "Apito" },
                    { 10410, "tr", null, null, "Düdük" },
                    { 10410, "zh", null, null, "哨子" },
                    { 10411, "de", null, null, "Sprint" },
                    { 10411, "en", null, null, "Sprint" },
                    { 10411, "es", null, null, "Esprint" },
                    { 10411, "fr", null, null, "Sprint" },
                    { 10411, "it", null, null, "Scatto" },
                    { 10411, "ja", null, null, "短距離走" },
                    { 10411, "ko", null, null, "단거리 달리기" },
                    { 10411, "pt", null, null, "Sprint" },
                    { 10411, "tr", null, null, "Sprint" },
                    { 10411, "zh", null, null, "冲刺" },
                    { 10412, "de", null, null, "Trikot" },
                    { 10412, "en", null, null, "Jersey" },
                    { 10412, "es", null, null, "Camiseta deportiva" },
                    { 10412, "fr", null, null, "Maillot" },
                    { 10412, "it", null, null, "Maglia" },
                    { 10412, "ja", null, null, "ユニフォーム" },
                    { 10412, "ko", null, null, "유니폼" },
                    { 10412, "pt", null, null, "Camisa de time" },
                    { 10412, "tr", null, null, "Forma" },
                    { 10412, "zh", null, null, "球衣" },
                    { 10413, "de", null, null, "Kapitän" },
                    { 10413, "en", null, null, "Captain" },
                    { 10413, "es", null, null, "Capitán" },
                    { 10413, "fr", null, null, "Capitaine" },
                    { 10413, "it", null, null, "Capitano" },
                    { 10413, "ja", null, null, "キャプテン" },
                    { 10413, "ko", null, null, "주장" },
                    { 10413, "pt", null, null, "Capitão" },
                    { 10413, "tr", null, null, "Kaptan" },
                    { 10413, "zh", null, null, "队长" },
                    { 10414, "de", null, null, "Arena" },
                    { 10414, "en", null, null, "Arena" },
                    { 10414, "es", null, null, "Arena" },
                    { 10414, "fr", null, null, "Arène" },
                    { 10414, "it", null, null, "Arena" },
                    { 10414, "ja", null, null, "アリーナ" },
                    { 10414, "ko", null, null, "경기장" },
                    { 10414, "pt", null, null, "Arena" },
                    { 10414, "tr", null, null, "Arena" },
                    { 10414, "zh", null, null, "竞技场" },
                    { 10415, "de", null, null, "Zuschauer" },
                    { 10415, "en", null, null, "Spectator" },
                    { 10415, "es", null, null, "Espectador" },
                    { 10415, "fr", null, null, "Spectateur" },
                    { 10415, "it", null, null, "Spettatore" },
                    { 10415, "ja", null, null, "観客" },
                    { 10415, "ko", null, null, "관중" },
                    { 10415, "pt", null, null, "Espectador" },
                    { 10415, "tr", null, null, "Seyirci" },
                    { 10415, "zh", null, null, "观众" },
                    { 10416, "de", null, null, "Medaille" },
                    { 10416, "en", null, null, "Medal" },
                    { 10416, "es", null, null, "Medalla" },
                    { 10416, "fr", null, null, "Médaille" },
                    { 10416, "it", null, null, "Medaglia" },
                    { 10416, "ja", null, null, "メダル" },
                    { 10416, "ko", null, null, "메달" },
                    { 10416, "pt", null, null, "Medalha" },
                    { 10416, "tr", null, null, "Madalya" },
                    { 10416, "zh", null, null, "奖牌" },
                    { 10417, "de", null, null, "Trophäe" },
                    { 10417, "en", null, null, "Trophy" },
                    { 10417, "es", null, null, "Trofeo" },
                    { 10417, "fr", null, null, "Trophée" },
                    { 10417, "it", null, null, "Trofeo" },
                    { 10417, "ja", null, null, "トロフィー" },
                    { 10417, "ko", null, null, "트로피" },
                    { 10417, "pt", null, null, "Troféu" },
                    { 10417, "tr", null, null, "Kupa" },
                    { 10417, "zh", null, null, "奖杯" },
                    { 10418, "de", null, null, "Schmerz" },
                    { 10418, "en", null, null, "Pain" },
                    { 10418, "es", null, null, "Dolor" },
                    { 10418, "fr", null, null, "Douleur" },
                    { 10418, "it", null, null, "Dolore" },
                    { 10418, "ja", null, null, "痛み" },
                    { 10418, "ko", null, null, "통증" },
                    { 10418, "pt", null, null, "Dor" },
                    { 10418, "tr", null, null, "Ağrı" },
                    { 10418, "zh", null, null, "疼痛" },
                    { 10419, "de", null, null, "Fieber" },
                    { 10419, "en", null, null, "Fever" },
                    { 10419, "es", null, null, "Fiebre" },
                    { 10419, "fr", null, null, "Fièvre" },
                    { 10419, "it", null, null, "Febbre" },
                    { 10419, "ja", null, null, "熱" },
                    { 10419, "ko", null, null, "열" },
                    { 10419, "pt", null, null, "Febre" },
                    { 10419, "tr", null, null, "Ateş" },
                    { 10419, "zh", null, null, "发烧" },
                    { 10420, "de", null, null, "Krankenhaus" },
                    { 10420, "en", null, null, "Hospital" },
                    { 10420, "es", null, null, "Hospital" },
                    { 10420, "fr", null, null, "Hôpital" },
                    { 10420, "it", null, null, "Ospedale" },
                    { 10420, "ja", null, null, "病院" },
                    { 10420, "ko", null, null, "병원" },
                    { 10420, "pt", null, null, "Hospital" },
                    { 10420, "tr", null, null, "Hastane" },
                    { 10420, "zh", null, null, "医院" },
                    { 10421, "de", null, null, "Kopfschmerzen" },
                    { 10421, "en", null, null, "Headache" },
                    { 10421, "es", null, null, "Dolor de cabeza" },
                    { 10421, "fr", null, null, "Mal de tête" },
                    { 10421, "it", null, null, "Mal di testa" },
                    { 10421, "ja", null, null, "頭痛" },
                    { 10421, "ko", null, null, "두통" },
                    { 10421, "pt", null, null, "Dor de cabeça" },
                    { 10421, "tr", null, null, "Baş ağrısı" },
                    { 10421, "zh", null, null, "头痛" },
                    { 10422, "de", null, null, "Medizin" },
                    { 10422, "en", null, null, "Medicine" },
                    { 10422, "es", null, null, "Medicina" },
                    { 10422, "fr", null, null, "Médicament" },
                    { 10422, "it", null, null, "Medicina" },
                    { 10422, "ja", null, null, "薬" },
                    { 10422, "ko", null, null, "약" },
                    { 10422, "pt", null, null, "Remédio" },
                    { 10422, "tr", null, null, "İlaç" },
                    { 10422, "zh", null, null, "药" },
                    { 10423, "de", null, null, "Krankenwagen" },
                    { 10423, "en", null, null, "Ambulance" },
                    { 10423, "es", null, null, "Ambulancia" },
                    { 10423, "fr", null, null, "Ambulance" },
                    { 10423, "it", null, null, "Ambulanza" },
                    { 10423, "ja", null, null, "救急車" },
                    { 10423, "ko", null, null, "구급차" },
                    { 10423, "pt", null, null, "Ambulância" },
                    { 10423, "tr", null, null, "Ambulans" },
                    { 10423, "zh", null, null, "救护车" },
                    { 10424, "de", null, null, "Schwindelig" },
                    { 10424, "en", null, null, "Dizzy" },
                    { 10424, "es", null, null, "Mareado" },
                    { 10424, "fr", null, null, "Étourdi" },
                    { 10424, "it", null, null, "Stordito" },
                    { 10424, "ja", null, null, "めまいがする" },
                    { 10424, "ko", null, null, "어지러운" },
                    { 10424, "pt", null, null, "Tonto" },
                    { 10424, "tr", null, null, "Baş dönmesi hisseden" },
                    { 10424, "zh", null, null, "头晕" },
                    { 10425, "de", null, null, "Verband" },
                    { 10425, "en", null, null, "Bandage" },
                    { 10425, "es", null, null, "Vendaje" },
                    { 10425, "fr", null, null, "Bandage" },
                    { 10425, "it", null, null, "Benda" },
                    { 10425, "ja", null, null, "包帯" },
                    { 10425, "ko", null, null, "붕대" },
                    { 10425, "pt", null, null, "Bandagem" },
                    { 10425, "tr", null, null, "Bandaj" },
                    { 10425, "zh", null, null, "绷带" },
                    { 10426, "de", null, null, "Etikett" },
                    { 10426, "en", null, null, "Label" },
                    { 10426, "es", null, null, "Etiqueta" },
                    { 10426, "fr", null, null, "Étiquette" },
                    { 10426, "it", null, null, "Etichetta" },
                    { 10426, "ja", null, null, "ラベル" },
                    { 10426, "ko", null, null, "라벨" },
                    { 10426, "pt", null, null, "Etiqueta" },
                    { 10426, "tr", null, null, "Etiket" },
                    { 10426, "zh", null, null, "标签" },
                    { 10427, "de", null, null, "Gutschein" },
                    { 10427, "en", null, null, "Coupon" },
                    { 10427, "es", null, null, "Cupón" },
                    { 10427, "fr", null, null, "Coupon" },
                    { 10427, "it", null, null, "Buono sconto" },
                    { 10427, "ja", null, null, "クーポン" },
                    { 10427, "ko", null, null, "쿠폰" },
                    { 10427, "pt", null, null, "Cupom" },
                    { 10427, "tr", null, null, "Kupon" },
                    { 10427, "zh", null, null, "优惠券" },
                    { 10428, "de", null, null, "Einkaufswagen" },
                    { 10428, "en", null, null, "Cart" },
                    { 10428, "es", null, null, "Carrito" },
                    { 10428, "fr", null, null, "Chariot" },
                    { 10428, "it", null, null, "Carrello" },
                    { 10428, "ja", null, null, "カート" },
                    { 10428, "ko", null, null, "카트" },
                    { 10428, "pt", null, null, "Carrinho" },
                    { 10428, "tr", null, null, "Alışveriş sepeti" },
                    { 10428, "zh", null, null, "购物车" },
                    { 10429, "de", null, null, "Gutscheinschein" },
                    { 10429, "en", null, null, "Voucher" },
                    { 10429, "es", null, null, "Vale" },
                    { 10429, "fr", null, null, "Bon d'achat" },
                    { 10429, "it", null, null, "Buono" },
                    { 10429, "ja", null, null, "引換券" },
                    { 10429, "ko", null, null, "상품권" },
                    { 10429, "pt", null, null, "Vale" },
                    { 10429, "tr", null, null, "Hediye çeki" },
                    { 10429, "zh", null, null, "代金券" },
                    { 10430, "de", null, null, "Strichcode" },
                    { 10430, "en", null, null, "Barcode" },
                    { 10430, "es", null, null, "Código de barras" },
                    { 10430, "fr", null, null, "Code-barres" },
                    { 10430, "it", null, null, "Codice a barre" },
                    { 10430, "ja", null, null, "バーコード" },
                    { 10430, "ko", null, null, "바코드" },
                    { 10430, "pt", null, null, "Código de barras" },
                    { 10430, "tr", null, null, "Barkod" },
                    { 10430, "zh", null, null, "条形码" },
                    { 10431, "de", null, null, "Kassierer" },
                    { 10431, "en", null, null, "Cashier" },
                    { 10431, "es", null, null, "Cajero" },
                    { 10431, "fr", null, null, "Caissier" },
                    { 10431, "it", null, null, "Cassiere" },
                    { 10431, "ja", null, null, "レジ係" },
                    { 10431, "ko", null, null, "계산원" },
                    { 10431, "pt", null, null, "Caixa" },
                    { 10431, "tr", null, null, "Kasiyer" },
                    { 10431, "zh", null, null, "收银员" },
                    { 10432, "de", null, null, "Kundenkarte" },
                    { 10432, "en", null, null, "Loyalty card" },
                    { 10432, "es", null, null, "Tarjeta de fidelidad" },
                    { 10432, "fr", null, null, "Carte de fidélité" },
                    { 10432, "it", null, null, "Carta fedeltà" },
                    { 10432, "ja", null, null, "会員カード" },
                    { 10432, "ko", null, null, "멤버십 카드" },
                    { 10432, "pt", null, null, "Cartão fidelidade" },
                    { 10432, "tr", null, null, "Sadakat kartı" },
                    { 10432, "zh", null, null, "会员卡" },
                    { 10433, "de", null, null, "Kasse" },
                    { 10433, "en", null, null, "Checkout" },
                    { 10433, "es", null, null, "Caja" },
                    { 10433, "fr", null, null, "Caisse" },
                    { 10433, "it", null, null, "Cassa" },
                    { 10433, "ja", null, null, "レジ" },
                    { 10433, "ko", null, null, "계산대" },
                    { 10433, "pt", null, null, "Checkout" },
                    { 10433, "tr", null, null, "Ödeme noktası" },
                    { 10433, "zh", null, null, "结账" },
                    { 10434, "de", null, null, "Gipfel" },
                    { 10434, "en", null, null, "Peak" },
                    { 10434, "es", null, null, "Cima" },
                    { 10434, "fr", null, null, "Sommet" },
                    { 10434, "it", null, null, "Vetta" },
                    { 10434, "ja", null, null, "山頂" },
                    { 10434, "ko", null, null, "정상" },
                    { 10434, "pt", null, null, "Cume" },
                    { 10434, "tr", null, null, "Zirve" },
                    { 10434, "zh", null, null, "山顶" },
                    { 10435, "de", null, null, "Bach" },
                    { 10435, "en", null, null, "Stream" },
                    { 10435, "es", null, null, "Arroyo" },
                    { 10435, "fr", null, null, "Ruisseau" },
                    { 10435, "it", null, null, "Ruscello" },
                    { 10435, "ja", null, null, "小川" },
                    { 10435, "ko", null, null, "개울" },
                    { 10435, "pt", null, null, "Riacho" },
                    { 10435, "tr", null, null, "Dere" },
                    { 10435, "zh", null, null, "小溪" },
                    { 10436, "de", null, null, "Höhle" },
                    { 10436, "en", null, null, "Cave" },
                    { 10436, "es", null, null, "Cueva" },
                    { 10436, "fr", null, null, "Grotte" },
                    { 10436, "it", null, null, "Grotta" },
                    { 10436, "ja", null, null, "洞窟" },
                    { 10436, "ko", null, null, "동굴" },
                    { 10436, "pt", null, null, "Caverna" },
                    { 10436, "tr", null, null, "Mağara" },
                    { 10436, "zh", null, null, "洞穴" },
                    { 10437, "de", null, null, "Ozean" },
                    { 10437, "en", null, null, "Ocean" },
                    { 10437, "es", null, null, "Océano" },
                    { 10437, "fr", null, null, "Océan" },
                    { 10437, "it", null, null, "Oceano" },
                    { 10437, "ja", null, null, "海洋" },
                    { 10437, "ko", null, null, "대양" },
                    { 10437, "pt", null, null, "Oceano" },
                    { 10437, "tr", null, null, "Okyanus" },
                    { 10437, "zh", null, null, "海洋" },
                    { 10438, "de", null, null, "Küste" },
                    { 10438, "en", null, null, "Coast" },
                    { 10438, "es", null, null, "Costa" },
                    { 10438, "fr", null, null, "Côte" },
                    { 10438, "it", null, null, "Costa" },
                    { 10438, "ja", null, null, "海岸" },
                    { 10438, "ko", null, null, "해안" },
                    { 10438, "pt", null, null, "Costa" },
                    { 10438, "tr", null, null, "Kıyı" },
                    { 10438, "zh", null, null, "海岸" },
                    { 10439, "de", null, null, "Schlucht" },
                    { 10439, "en", null, null, "Canyon" },
                    { 10439, "es", null, null, "Cañón" },
                    { 10439, "fr", null, null, "Canyon" },
                    { 10439, "it", null, null, "Canyon" },
                    { 10439, "ja", null, null, "峡谷" },
                    { 10439, "ko", null, null, "협곡" },
                    { 10439, "pt", null, null, "Cânion" },
                    { 10439, "tr", null, null, "Kanyon" },
                    { 10439, "zh", null, null, "峡谷" },
                    { 10440, "de", null, null, "Düne" },
                    { 10440, "en", null, null, "Dune" },
                    { 10440, "es", null, null, "Duna" },
                    { 10440, "fr", null, null, "Dune" },
                    { 10440, "it", null, null, "Duna" },
                    { 10440, "ja", null, null, "砂丘" },
                    { 10440, "ko", null, null, "모래언덕" },
                    { 10440, "pt", null, null, "Duna" },
                    { 10440, "tr", null, null, "Kumul" },
                    { 10440, "zh", null, null, "沙丘" },
                    { 10441, "de", null, null, "Klippe" },
                    { 10441, "en", null, null, "Cliff" },
                    { 10441, "es", null, null, "Acantilado" },
                    { 10441, "fr", null, null, "Falaise" },
                    { 10441, "it", null, null, "Scogliera" },
                    { 10441, "ja", null, null, "崖" },
                    { 10441, "ko", null, null, "절벽" },
                    { 10441, "pt", null, null, "Penhasco" },
                    { 10441, "tr", null, null, "Uçurum" },
                    { 10441, "zh", null, null, "悬崖" },
                    { 10442, "de", null, null, "Magnet" },
                    { 10442, "en", null, null, "Magnet" },
                    { 10442, "es", null, null, "Imán" },
                    { 10442, "fr", null, null, "Aimant" },
                    { 10442, "it", null, null, "Magnete" },
                    { 10442, "ja", null, null, "磁石" },
                    { 10442, "ko", null, null, "자석" },
                    { 10442, "pt", null, null, "Ímã" },
                    { 10442, "tr", null, null, "Mıknatıs" },
                    { 10442, "zh", null, null, "磁铁" },
                    { 10443, "de", null, null, "Umlaufbahn" },
                    { 10443, "en", null, null, "Orbit" },
                    { 10443, "es", null, null, "Órbita" },
                    { 10443, "fr", null, null, "Orbite" },
                    { 10443, "it", null, null, "Orbita" },
                    { 10443, "ja", null, null, "軌道" },
                    { 10443, "ko", null, null, "궤도" },
                    { 10443, "pt", null, null, "Órbita" },
                    { 10443, "tr", null, null, "Yörünge" },
                    { 10443, "zh", null, null, "轨道" },
                    { 10444, "de", null, null, "Kristall" },
                    { 10444, "en", null, null, "Crystal" },
                    { 10444, "es", null, null, "Cristal" },
                    { 10444, "fr", null, null, "Cristal" },
                    { 10444, "it", null, null, "Cristallo" },
                    { 10444, "ja", null, null, "結晶" },
                    { 10444, "ko", null, null, "결정" },
                    { 10444, "pt", null, null, "Cristal" },
                    { 10444, "tr", null, null, "Kristal" },
                    { 10444, "zh", null, null, "晶体" },
                    { 10445, "de", null, null, "Mikroskop" },
                    { 10445, "en", null, null, "Microscope" },
                    { 10445, "es", null, null, "Microscopio" },
                    { 10445, "fr", null, null, "Microscope" },
                    { 10445, "it", null, null, "Microscopio" },
                    { 10445, "ja", null, null, "顕微鏡" },
                    { 10445, "ko", null, null, "현미경" },
                    { 10445, "pt", null, null, "Microscópio" },
                    { 10445, "tr", null, null, "Mikroskop" },
                    { 10445, "zh", null, null, "显微镜" },
                    { 10446, "de", null, null, "Sternwarte" },
                    { 10446, "en", null, null, "Observatory" },
                    { 10446, "es", null, null, "Observatorio" },
                    { 10446, "fr", null, null, "Observatoire" },
                    { 10446, "it", null, null, "Osservatorio" },
                    { 10446, "ja", null, null, "天文台" },
                    { 10446, "ko", null, null, "천문대" },
                    { 10446, "pt", null, null, "Observatório" },
                    { 10446, "tr", null, null, "Gözlemevi" },
                    { 10446, "zh", null, null, "天文台" },
                    { 10447, "de", null, null, "Teleskop" },
                    { 10447, "en", null, null, "Telescope" },
                    { 10447, "es", null, null, "Telescopio" },
                    { 10447, "fr", null, null, "Télescope" },
                    { 10447, "it", null, null, "Telescopio" },
                    { 10447, "ja", null, null, "望遠鏡" },
                    { 10447, "ko", null, null, "망원경" },
                    { 10447, "pt", null, null, "Telescópio" },
                    { 10447, "tr", null, null, "Teleskop" },
                    { 10447, "zh", null, null, "望远镜" },
                    { 10448, "de", null, null, "Teilchen" },
                    { 10448, "en", null, null, "Particle" },
                    { 10448, "es", null, null, "Partícula" },
                    { 10448, "fr", null, null, "Particule" },
                    { 10448, "it", null, null, "Particella" },
                    { 10448, "ja", null, null, "粒子" },
                    { 10448, "ko", null, null, "입자" },
                    { 10448, "pt", null, null, "Partícula" },
                    { 10448, "tr", null, null, "Parçacık" },
                    { 10448, "zh", null, null, "粒子" },
                    { 10449, "de", null, null, "Reibung" },
                    { 10449, "en", null, null, "Friction" },
                    { 10449, "es", null, null, "Fricción" },
                    { 10449, "fr", null, null, "Friction" },
                    { 10449, "it", null, null, "Attrito" },
                    { 10449, "ja", null, null, "摩擦" },
                    { 10449, "ko", null, null, "마찰" },
                    { 10449, "pt", null, null, "Atrito" },
                    { 10449, "tr", null, null, "Sürtünme" },
                    { 10449, "zh", null, null, "摩擦" },
                    { 10450, "de", null, null, "Panda" },
                    { 10450, "en", null, null, "Panda" },
                    { 10450, "es", null, null, "Panda" },
                    { 10450, "fr", null, null, "Panda" },
                    { 10450, "it", null, null, "Panda" },
                    { 10450, "ja", null, null, "パンダ" },
                    { 10450, "ko", null, null, "판다" },
                    { 10450, "pt", null, null, "Panda" },
                    { 10450, "tr", null, null, "Panda" },
                    { 10450, "zh", null, null, "熊猫" },
                    { 10451, "de", null, null, "Känguru" },
                    { 10451, "en", null, null, "Kangaroo" },
                    { 10451, "es", null, null, "Canguro" },
                    { 10451, "fr", null, null, "Kangourou" },
                    { 10451, "it", null, null, "Canguro" },
                    { 10451, "ja", null, null, "カンガルー" },
                    { 10451, "ko", null, null, "캥거루" },
                    { 10451, "pt", null, null, "Canguru" },
                    { 10451, "tr", null, null, "Kanguru" },
                    { 10451, "zh", null, null, "袋鼠" },
                    { 10452, "de", null, null, "Koala" },
                    { 10452, "en", null, null, "Koala" },
                    { 10452, "es", null, null, "Koala" },
                    { 10452, "fr", null, null, "Koala" },
                    { 10452, "it", null, null, "Koala" },
                    { 10452, "ja", null, null, "コアラ" },
                    { 10452, "ko", null, null, "코알라" },
                    { 10452, "pt", null, null, "Coala" },
                    { 10452, "tr", null, null, "Koala" },
                    { 10452, "zh", null, null, "考拉" },
                    { 10453, "de", null, null, "Zebra" },
                    { 10453, "en", null, null, "Zebra" },
                    { 10453, "es", null, null, "Cebra" },
                    { 10453, "fr", null, null, "Zèbre" },
                    { 10453, "it", null, null, "Zebra" },
                    { 10453, "ja", null, null, "シマウマ" },
                    { 10453, "ko", null, null, "얼룩말" },
                    { 10453, "pt", null, null, "Zebra" },
                    { 10453, "tr", null, null, "Zebra" },
                    { 10453, "zh", null, null, "斑马" },
                    { 10454, "de", null, null, "Giraffe" },
                    { 10454, "en", null, null, "Giraffe" },
                    { 10454, "es", null, null, "Jirafa" },
                    { 10454, "fr", null, null, "Girafe" },
                    { 10454, "it", null, null, "Giraffa" },
                    { 10454, "ja", null, null, "キリン" },
                    { 10454, "ko", null, null, "기린" },
                    { 10454, "pt", null, null, "Girafa" },
                    { 10454, "tr", null, null, "Zürafa" },
                    { 10454, "zh", null, null, "长颈鹿" },
                    { 10455, "de", null, null, "Tiger" },
                    { 10455, "en", null, null, "Tiger" },
                    { 10455, "es", null, null, "Tigre" },
                    { 10455, "fr", null, null, "Tigre" },
                    { 10455, "it", null, null, "Tigre" },
                    { 10455, "ja", null, null, "虎" },
                    { 10455, "ko", null, null, "호랑이" },
                    { 10455, "pt", null, null, "Tigre" },
                    { 10455, "tr", null, null, "Kaplan" },
                    { 10455, "zh", null, null, "老虎" },
                    { 10456, "de", null, null, "Fuchs" },
                    { 10456, "en", null, null, "Fox" },
                    { 10456, "es", null, null, "Zorro" },
                    { 10456, "fr", null, null, "Renard" },
                    { 10456, "it", null, null, "Volpe" },
                    { 10456, "ja", null, null, "キツネ" },
                    { 10456, "ko", null, null, "여우" },
                    { 10456, "pt", null, null, "Raposa" },
                    { 10456, "tr", null, null, "Tilki" },
                    { 10456, "zh", null, null, "狐狸" },
                    { 10457, "de", null, null, "Schildkröte" },
                    { 10457, "en", null, null, "Turtle" },
                    { 10457, "es", null, null, "Tortuga" },
                    { 10457, "fr", null, null, "Tortue" },
                    { 10457, "it", null, null, "Tartaruga" },
                    { 10457, "ja", null, null, "亀" },
                    { 10457, "ko", null, null, "거북이" },
                    { 10457, "pt", null, null, "Tartaruga" },
                    { 10457, "tr", null, null, "Kaplumbağa" },
                    { 10457, "zh", null, null, "乌龟" },
                    { 10458, "de", null, null, "Mittagessen" },
                    { 10458, "en", null, null, "Lunch" },
                    { 10458, "es", null, null, "Almuerzo" },
                    { 10458, "fr", null, null, "Déjeuner" },
                    { 10458, "it", null, null, "Pranzo" },
                    { 10458, "ja", null, null, "昼食" },
                    { 10458, "ko", null, null, "점심" },
                    { 10458, "pt", null, null, "Almoço" },
                    { 10458, "tr", null, null, "Öğle yemeği" },
                    { 10458, "zh", null, null, "午餐" },
                    { 10459, "de", null, null, "Abendessen" },
                    { 10459, "en", null, null, "Dinner" },
                    { 10459, "es", null, null, "Cena" },
                    { 10459, "fr", null, null, "Dîner" },
                    { 10459, "it", null, null, "Cena" },
                    { 10459, "ja", null, null, "夕食" },
                    { 10459, "ko", null, null, "저녁 식사" },
                    { 10459, "pt", null, null, "Jantar" },
                    { 10459, "tr", null, null, "Akşam yemeği" },
                    { 10459, "zh", null, null, "晚餐" },
                    { 10460, "de", null, null, "Suppe" },
                    { 10460, "en", null, null, "Soup" },
                    { 10460, "es", null, null, "Sopa" },
                    { 10460, "fr", null, null, "Soupe" },
                    { 10460, "it", null, null, "Zuppa" },
                    { 10460, "ja", null, null, "スープ" },
                    { 10460, "ko", null, null, "수프" },
                    { 10460, "pt", null, null, "Sopa" },
                    { 10460, "tr", null, null, "Çorba" },
                    { 10460, "zh", null, null, "汤" },
                    { 10461, "de", null, null, "Snack" },
                    { 10461, "en", null, null, "Snack" },
                    { 10461, "es", null, null, "Aperitivo" },
                    { 10461, "fr", null, null, "Collation" },
                    { 10461, "it", null, null, "Spuntino" },
                    { 10461, "ja", null, null, "おやつ" },
                    { 10461, "ko", null, null, "간식" },
                    { 10461, "pt", null, null, "Lanche" },
                    { 10461, "tr", null, null, "Atıştırmalık" },
                    { 10461, "zh", null, null, "零食" },
                    { 10462, "de", null, null, "Getränk" },
                    { 10462, "en", null, null, "Beverage" },
                    { 10462, "es", null, null, "Bebida" },
                    { 10462, "fr", null, null, "Boisson" },
                    { 10462, "it", null, null, "Bevanda" },
                    { 10462, "ja", null, null, "飲み物" },
                    { 10462, "ko", null, null, "음료" },
                    { 10462, "pt", null, null, "Bebida" },
                    { 10462, "tr", null, null, "İçecek" },
                    { 10462, "zh", null, null, "饮料" },
                    { 10463, "de", null, null, "Bäckerei" },
                    { 10463, "en", null, null, "Bakery" },
                    { 10463, "es", null, null, "Panadería" },
                    { 10463, "fr", null, null, "Boulangerie" },
                    { 10463, "it", null, null, "Panetteria" },
                    { 10463, "ja", null, null, "パン屋" },
                    { 10463, "ko", null, null, "빵집" },
                    { 10463, "pt", null, null, "Padaria" },
                    { 10463, "tr", null, null, "Fırın" },
                    { 10463, "zh", null, null, "面包店" },
                    { 10464, "de", null, null, "Vorspeise" },
                    { 10464, "en", null, null, "Appetizer" },
                    { 10464, "es", null, null, "Entrante" },
                    { 10464, "fr", null, null, "Entrée" },
                    { 10464, "it", null, null, "Antipasto" },
                    { 10464, "ja", null, null, "前菜" },
                    { 10464, "ko", null, null, "애피타이저" },
                    { 10464, "pt", null, null, "Entrada" },
                    { 10464, "tr", null, null, "Meze" },
                    { 10464, "zh", null, null, "开胃菜" },
                    { 10465, "de", null, null, "Lebensmittel" },
                    { 10465, "en", null, null, "Grocery" },
                    { 10465, "es", null, null, "Comestibles" },
                    { 10465, "fr", null, null, "Épicerie" },
                    { 10465, "it", null, null, "Generi alimentari" },
                    { 10465, "ja", null, null, "食料品" },
                    { 10465, "ko", null, null, "식료품" },
                    { 10465, "pt", null, null, "Mercearia" },
                    { 10465, "tr", null, null, "Bakkaliye" },
                    { 10465, "zh", null, null, "食品杂货" },
                    { 10466, "de", null, null, "Hotel" },
                    { 10466, "en", null, null, "Hotel" },
                    { 10466, "es", null, null, "Hotel" },
                    { 10466, "fr", null, null, "Hôtel" },
                    { 10466, "it", null, null, "Hotel" },
                    { 10466, "ja", null, null, "ホテル" },
                    { 10466, "ko", null, null, "호텔" },
                    { 10466, "pt", null, null, "Hotel" },
                    { 10466, "tr", null, null, "Otel" },
                    { 10466, "zh", null, null, "酒店" },
                    { 10467, "de", null, null, "Karte" },
                    { 10467, "en", null, null, "Map" },
                    { 10467, "es", null, null, "Mapa" },
                    { 10467, "fr", null, null, "Carte" },
                    { 10467, "it", null, null, "Mappa" },
                    { 10467, "ja", null, null, "地図" },
                    { 10467, "ko", null, null, "지도" },
                    { 10467, "pt", null, null, "Mapa" },
                    { 10467, "tr", null, null, "Harita" },
                    { 10467, "zh", null, null, "地图" },
                    { 10468, "de", null, null, "Flughafen" },
                    { 10468, "en", null, null, "Airport" },
                    { 10468, "es", null, null, "Aeropuerto" },
                    { 10468, "fr", null, null, "Aéroport" },
                    { 10468, "it", null, null, "Aeroporto" },
                    { 10468, "ja", null, null, "空港" },
                    { 10468, "ko", null, null, "공항" },
                    { 10468, "pt", null, null, "Aeroporto" },
                    { 10468, "tr", null, null, "Havalimanı" },
                    { 10468, "zh", null, null, "机场" },
                    { 10469, "de", null, null, "Reisepass" },
                    { 10469, "en", null, null, "Passport" },
                    { 10469, "es", null, null, "Pasaporte" },
                    { 10469, "fr", null, null, "Passeport" },
                    { 10469, "it", null, null, "Passaporto" },
                    { 10469, "ja", null, null, "パスポート" },
                    { 10469, "ko", null, null, "여권" },
                    { 10469, "pt", null, null, "Passaporte" },
                    { 10469, "tr", null, null, "Pasaport" },
                    { 10469, "zh", null, null, "护照" },
                    { 10470, "de", null, null, "Gepäck" },
                    { 10470, "en", null, null, "Luggage" },
                    { 10470, "es", null, null, "Equipaje" },
                    { 10470, "fr", null, null, "Bagages" },
                    { 10470, "it", null, null, "Bagaglio" },
                    { 10470, "ja", null, null, "荷物" },
                    { 10470, "ko", null, null, "짐" },
                    { 10470, "pt", null, null, "Bagagem" },
                    { 10470, "tr", null, null, "Bagaj" },
                    { 10470, "zh", null, null, "行李" },
                    { 10471, "de", null, null, "Tourist" },
                    { 10471, "en", null, null, "Tourist" },
                    { 10471, "es", null, null, "Turista" },
                    { 10471, "fr", null, null, "Touriste" },
                    { 10471, "it", null, null, "Turista" },
                    { 10471, "ja", null, null, "観光客" },
                    { 10471, "ko", null, null, "관광객" },
                    { 10471, "pt", null, null, "Turista" },
                    { 10471, "tr", null, null, "Turist" },
                    { 10471, "zh", null, null, "游客" },
                    { 10472, "de", null, null, "Ticket" },
                    { 10472, "en", null, null, "Ticket" },
                    { 10472, "es", null, null, "Billete" },
                    { 10472, "fr", null, null, "Billet" },
                    { 10472, "it", null, null, "Biglietto" },
                    { 10472, "ja", null, null, "チケット" },
                    { 10472, "ko", null, null, "티켓" },
                    { 10472, "pt", null, null, "Bilhete" },
                    { 10472, "tr", null, null, "Bilet" },
                    { 10472, "zh", null, null, "票" },
                    { 10473, "de", null, null, "Andenken" },
                    { 10473, "en", null, null, "Souvenir" },
                    { 10473, "es", null, null, "Recuerdo" },
                    { 10473, "fr", null, null, "Souvenir" },
                    { 10473, "it", null, null, "Souvenir" },
                    { 10473, "ja", null, null, "お土産" },
                    { 10473, "ko", null, null, "기념품" },
                    { 10473, "pt", null, null, "Lembrança" },
                    { 10473, "tr", null, null, "Hediyelik eşya" },
                    { 10473, "zh", null, null, "纪念品" },
                    { 10474, "de", null, null, "Besprechung" },
                    { 10474, "en", null, null, "Meeting" },
                    { 10474, "es", null, null, "Reunión" },
                    { 10474, "fr", null, null, "Réunion" },
                    { 10474, "it", null, null, "Riunione" },
                    { 10474, "ja", null, null, "会議" },
                    { 10474, "ko", null, null, "회의" },
                    { 10474, "pt", null, null, "Reunião" },
                    { 10474, "tr", null, null, "Toplantı" },
                    { 10474, "zh", null, null, "会议" },
                    { 10475, "de", null, null, "Gehalt" },
                    { 10475, "en", null, null, "Salary" },
                    { 10475, "es", null, null, "Salario" },
                    { 10475, "fr", null, null, "Salaire" },
                    { 10475, "it", null, null, "Stipendio" },
                    { 10475, "ja", null, null, "給料" },
                    { 10475, "ko", null, null, "급여" },
                    { 10475, "pt", null, null, "Salário" },
                    { 10475, "tr", null, null, "Maaş" },
                    { 10475, "zh", null, null, "工资" },
                    { 10476, "de", null, null, "Verkäufer" },
                    { 10476, "en", null, null, "Vendor" },
                    { 10476, "es", null, null, "Vendedor" },
                    { 10476, "fr", null, null, "Marchand" },
                    { 10476, "it", null, null, "Venditore" },
                    { 10476, "ja", null, null, "販売業者" },
                    { 10476, "ko", null, null, "판매업체" },
                    { 10476, "pt", null, null, "Vendedor" },
                    { 10476, "tr", null, null, "Satıcı" },
                    { 10476, "zh", null, null, "商家" },
                    { 10477, "de", null, null, "Arbeitskollege" },
                    { 10477, "en", null, null, "Coworker" },
                    { 10477, "es", null, null, "Compañero de trabajo" },
                    { 10477, "fr", null, null, "Collègue de travail" },
                    { 10477, "it", null, null, "Collega di lavoro" },
                    { 10477, "ja", null, null, "同僚" },
                    { 10477, "ko", null, null, "직장 동료" },
                    { 10477, "pt", null, null, "Colega de trabalho" },
                    { 10477, "tr", null, null, "İş arkadaşı" },
                    { 10477, "zh", null, null, "同事" },
                    { 10478, "de", null, null, "Frist" },
                    { 10478, "en", null, null, "Deadline" },
                    { 10478, "es", null, null, "Fecha límite" },
                    { 10478, "fr", null, null, "Date limite" },
                    { 10478, "it", null, null, "Scadenza" },
                    { 10478, "ja", null, null, "締め切り" },
                    { 10478, "ko", null, null, "마감일" },
                    { 10478, "pt", null, null, "Prazo" },
                    { 10478, "tr", null, null, "Son teslim tarihi" },
                    { 10478, "zh", null, null, "截止日期" },
                    { 10479, "de", null, null, "Gehaltsabrechnung" },
                    { 10479, "en", null, null, "Payroll" },
                    { 10479, "es", null, null, "Nómina" },
                    { 10479, "fr", null, null, "Paie" },
                    { 10479, "it", null, null, "Libro paga" },
                    { 10479, "ja", null, null, "給与計算" },
                    { 10479, "ko", null, null, "급여 명부" },
                    { 10479, "pt", null, null, "Folha de pagamento" },
                    { 10479, "tr", null, null, "Bordro" },
                    { 10479, "zh", null, null, "工资单" },
                    { 10480, "de", null, null, "Rechnung" },
                    { 10480, "en", null, null, "Invoice" },
                    { 10480, "es", null, null, "Factura" },
                    { 10480, "fr", null, null, "Facture" },
                    { 10480, "it", null, null, "Fattura" },
                    { 10480, "ja", null, null, "請求書" },
                    { 10480, "ko", null, null, "청구서" },
                    { 10480, "pt", null, null, "Fatura" },
                    { 10480, "tr", null, null, "Fatura" },
                    { 10480, "zh", null, null, "发票" },
                    { 10481, "de", null, null, "Budget" },
                    { 10481, "en", null, null, "Budget" },
                    { 10481, "es", null, null, "Presupuesto" },
                    { 10481, "fr", null, null, "Budget" },
                    { 10481, "it", null, null, "Bilancio" },
                    { 10481, "ja", null, null, "予算" },
                    { 10481, "ko", null, null, "예산" },
                    { 10481, "pt", null, null, "Orçamento" },
                    { 10481, "tr", null, null, "Bütçe" },
                    { 10481, "zh", null, null, "预算" },
                    { 10482, "de", null, null, "Kleinkind" },
                    { 10482, "en", null, null, "Toddler" },
                    { 10482, "es", null, null, "Niño pequeño" },
                    { 10482, "fr", null, null, "Tout-petit" },
                    { 10482, "it", null, null, "Bambino piccolo" },
                    { 10482, "ja", null, null, "幼児" },
                    { 10482, "ko", null, null, "유아" },
                    { 10482, "pt", null, null, "Criança pequena" },
                    { 10482, "tr", null, null, "Yeni yürüyen çocuk" },
                    { 10482, "zh", null, null, "幼儿" },
                    { 10483, "de", null, null, "Pate" },
                    { 10483, "en", null, null, "Godfather" },
                    { 10483, "es", null, null, "Padrino" },
                    { 10483, "fr", null, null, "Parrain" },
                    { 10483, "it", null, null, "Padrino" },
                    { 10483, "ja", null, null, "名付け親（男性）" },
                    { 10483, "ko", null, null, "대부" },
                    { 10483, "pt", null, null, "Padrinho" },
                    { 10483, "tr", null, null, "Vaftiz babası" },
                    { 10483, "zh", null, null, "教父" },
                    { 10484, "de", null, null, "Patin" },
                    { 10484, "en", null, null, "Godmother" },
                    { 10484, "es", null, null, "Madrina" },
                    { 10484, "fr", null, null, "Marraine" },
                    { 10484, "it", null, null, "Madrina" },
                    { 10484, "ja", null, null, "名付け親（女性）" },
                    { 10484, "ko", null, null, "대모" },
                    { 10484, "pt", null, null, "Madrinha" },
                    { 10484, "tr", null, null, "Vaftiz annesi" },
                    { 10484, "zh", null, null, "教母" },
                    { 10485, "de", null, null, "Stiefmutter" },
                    { 10485, "en", null, null, "Stepmother" },
                    { 10485, "es", null, null, "Madrastra" },
                    { 10485, "fr", null, null, "Belle-mère" },
                    { 10485, "it", null, null, "Matrigna" },
                    { 10485, "ja", null, null, "継母" },
                    { 10485, "ko", null, null, "새어머니" },
                    { 10485, "pt", null, null, "Madrasta" },
                    { 10485, "tr", null, null, "Üvey anne" },
                    { 10485, "zh", null, null, "继母" },
                    { 10486, "de", null, null, "Stiefvater" },
                    { 10486, "en", null, null, "Stepfather" },
                    { 10486, "es", null, null, "Padrastro" },
                    { 10486, "fr", null, null, "Beau-père" },
                    { 10486, "it", null, null, "Patrigno" },
                    { 10486, "ja", null, null, "継父" },
                    { 10486, "ko", null, null, "새아버지" },
                    { 10486, "pt", null, null, "Padrasto" },
                    { 10486, "tr", null, null, "Üvey baba" },
                    { 10486, "zh", null, null, "继父" },
                    { 10487, "de", null, null, "Stiefbruder" },
                    { 10487, "en", null, null, "Stepbrother" },
                    { 10487, "es", null, null, "Hermanastro" },
                    { 10487, "fr", null, null, "Demi-frère" },
                    { 10487, "it", null, null, "Fratellastro" },
                    { 10487, "ja", null, null, "異父（母）兄弟" },
                    { 10487, "ko", null, null, "이복형제" },
                    { 10487, "pt", null, null, "Meio-irmão" },
                    { 10487, "tr", null, null, "Üvey erkek kardeş" },
                    { 10487, "zh", null, null, "继兄弟" },
                    { 10488, "de", null, null, "Ehemann" },
                    { 10488, "en", null, null, "Husband" },
                    { 10488, "es", null, null, "Esposo" },
                    { 10488, "fr", null, null, "Mari" },
                    { 10488, "it", null, null, "Marito" },
                    { 10488, "ja", null, null, "夫" },
                    { 10488, "ko", null, null, "남편" },
                    { 10488, "pt", null, null, "Marido" },
                    { 10488, "tr", null, null, "Koca" },
                    { 10488, "zh", null, null, "丈夫" },
                    { 10489, "de", null, null, "Ehefrau" },
                    { 10489, "en", null, null, "Wife" },
                    { 10489, "es", null, null, "Esposa" },
                    { 10489, "fr", null, null, "Épouse" },
                    { 10489, "it", null, null, "Moglie" },
                    { 10489, "ja", null, null, "妻" },
                    { 10489, "ko", null, null, "아내" },
                    { 10489, "pt", null, null, "Esposa" },
                    { 10489, "tr", null, null, "Eş" },
                    { 10489, "zh", null, null, "妻子" }
                });

            migrationBuilder.InsertData(
                table: "DeckTemplateConcepts",
                columns: new[] { "ConceptId", "DeckTemplateId", "CefrLevel", "Ordinal" },
                values: new object[,]
                {
                    { 10370, 1, "A1", 37 },
                    { 10371, 1, "A1", 38 },
                    { 10372, 1, "A1", 39 },
                    { 10373, 1, "A2", 40 },
                    { 10374, 1, "A2", 41 },
                    { 10375, 1, "B1", 42 },
                    { 10376, 1, "B1+", 43 },
                    { 10377, 1, "B2", 44 },
                    { 10378, 2, "A1", 37 },
                    { 10379, 2, "A1", 38 },
                    { 10380, 2, "A1", 39 },
                    { 10381, 2, "A2", 40 },
                    { 10382, 2, "A2", 41 },
                    { 10383, 2, "B1", 42 },
                    { 10384, 2, "B1+", 43 },
                    { 10385, 2, "B2", 44 },
                    { 10386, 3, "A1", 37 },
                    { 10387, 3, "A1", 38 },
                    { 10388, 3, "A1", 39 },
                    { 10389, 3, "A2", 40 },
                    { 10390, 3, "A2", 41 },
                    { 10391, 3, "B1", 42 },
                    { 10392, 3, "B1+", 43 },
                    { 10393, 3, "B2", 44 },
                    { 10394, 4, "A1", 37 },
                    { 10395, 4, "A1", 38 },
                    { 10396, 4, "A1", 39 },
                    { 10397, 4, "A2", 40 },
                    { 10398, 4, "A2", 41 },
                    { 10399, 4, "B1", 42 },
                    { 10400, 4, "B1+", 43 },
                    { 10401, 4, "B2", 44 },
                    { 10402, 5, "A1", 37 },
                    { 10403, 5, "A1", 38 },
                    { 10404, 5, "A1", 39 },
                    { 10405, 5, "A2", 40 },
                    { 10406, 5, "A2", 41 },
                    { 10407, 5, "B1", 42 },
                    { 10408, 5, "B1+", 43 },
                    { 10409, 5, "B2", 44 },
                    { 10410, 6, "A1", 37 },
                    { 10411, 6, "A1", 38 },
                    { 10412, 6, "A1", 39 },
                    { 10413, 6, "A2", 40 },
                    { 10414, 6, "A2", 41 },
                    { 10415, 6, "B1", 42 },
                    { 10416, 6, "B1+", 43 },
                    { 10417, 6, "B2", 44 },
                    { 10418, 7, "A1", 37 },
                    { 10419, 7, "A1", 38 },
                    { 10420, 7, "A1", 39 },
                    { 10421, 7, "A2", 40 },
                    { 10422, 7, "A2", 41 },
                    { 10423, 7, "B1", 42 },
                    { 10424, 7, "B1+", 43 },
                    { 10425, 7, "B2", 44 },
                    { 10426, 8, "A1", 37 },
                    { 10427, 8, "A1", 38 },
                    { 10428, 8, "A1", 39 },
                    { 10429, 8, "A2", 40 },
                    { 10430, 8, "A2", 41 },
                    { 10431, 8, "B1", 42 },
                    { 10432, 8, "B1+", 43 },
                    { 10433, 8, "B2", 44 },
                    { 10434, 9, "A1", 37 },
                    { 10435, 9, "A1", 38 },
                    { 10436, 9, "A1", 39 },
                    { 10437, 9, "A2", 40 },
                    { 10438, 9, "A2", 41 },
                    { 10439, 9, "B1", 42 },
                    { 10440, 9, "B1+", 43 },
                    { 10441, 9, "B2", 44 },
                    { 10442, 10, "A1", 37 },
                    { 10443, 10, "A1", 38 },
                    { 10444, 10, "A1", 39 },
                    { 10445, 10, "A2", 40 },
                    { 10446, 10, "A2", 41 },
                    { 10447, 10, "B1", 42 },
                    { 10448, 10, "B1+", 43 },
                    { 10449, 10, "B2", 44 },
                    { 10450, 11, "A1", 37 },
                    { 10451, 11, "A1", 38 },
                    { 10452, 11, "A1", 39 },
                    { 10453, 11, "A2", 40 },
                    { 10454, 11, "A2", 41 },
                    { 10455, 11, "B1", 42 },
                    { 10456, 11, "B1+", 43 },
                    { 10457, 11, "B2", 44 },
                    { 10458, 12, "A1", 37 },
                    { 10459, 12, "A1", 38 },
                    { 10460, 12, "A1", 39 },
                    { 10461, 12, "A2", 40 },
                    { 10462, 12, "A2", 41 },
                    { 10463, 12, "B1", 42 },
                    { 10464, 12, "B1+", 43 },
                    { 10465, 12, "B2", 44 },
                    { 10466, 13, "A1", 37 },
                    { 10467, 13, "A1", 38 },
                    { 10468, 13, "A1", 39 },
                    { 10469, 13, "A2", 40 },
                    { 10470, 13, "A2", 41 },
                    { 10471, 13, "B1", 42 },
                    { 10472, 13, "B1+", 43 },
                    { 10473, 13, "B2", 44 },
                    { 10474, 14, "A1", 37 },
                    { 10475, 14, "A1", 38 },
                    { 10476, 14, "A1", 39 },
                    { 10477, 14, "A2", 40 },
                    { 10478, 14, "A2", 41 },
                    { 10479, 14, "B1", 42 },
                    { 10480, 14, "B1+", 43 },
                    { 10481, 14, "B2", 44 },
                    { 10482, 15, "A1", 37 },
                    { 10483, 15, "A1", 38 },
                    { 10484, 15, "A1", 39 },
                    { 10485, 15, "A2", 40 },
                    { 10486, 15, "A2", 41 },
                    { 10487, 15, "B1", 42 },
                    { 10488, 15, "B1+", 43 },
                    { 10489, 15, "B2", 44 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10370, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10370, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10370, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10370, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10370, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10370, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10370, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10370, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10370, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10370, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10371, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10371, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10371, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10371, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10371, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10371, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10371, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10371, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10371, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10371, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10372, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10372, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10372, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10372, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10372, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10372, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10372, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10372, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10372, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10372, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10373, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10373, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10373, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10373, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10373, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10373, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10373, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10373, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10373, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10373, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10374, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10374, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10374, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10374, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10374, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10374, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10374, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10374, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10374, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10374, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10375, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10375, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10375, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10375, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10375, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10375, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10375, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10375, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10375, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10375, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10376, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10376, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10376, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10376, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10376, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10376, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10376, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10376, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10376, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10376, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10377, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10377, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10377, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10377, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10377, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10377, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10377, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10377, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10377, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10377, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10378, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10378, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10378, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10378, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10378, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10378, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10378, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10378, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10378, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10378, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10379, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10379, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10379, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10379, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10379, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10379, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10379, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10379, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10379, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10379, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10380, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10380, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10380, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10380, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10380, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10380, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10380, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10380, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10380, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10380, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10381, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10381, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10381, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10381, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10381, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10381, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10381, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10381, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10381, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10381, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10382, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10382, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10382, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10382, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10382, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10382, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10382, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10382, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10382, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10382, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10383, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10383, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10383, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10383, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10383, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10383, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10383, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10383, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10383, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10383, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10384, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10384, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10384, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10384, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10384, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10384, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10384, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10384, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10384, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10384, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10385, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10385, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10385, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10385, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10385, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10385, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10385, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10385, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10385, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10385, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10386, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10386, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10386, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10386, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10386, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10386, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10386, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10386, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10386, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10386, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10387, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10387, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10387, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10387, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10387, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10387, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10387, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10387, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10387, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10387, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10388, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10388, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10388, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10388, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10388, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10388, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10388, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10388, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10388, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10388, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10389, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10389, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10389, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10389, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10389, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10389, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10389, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10389, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10389, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10389, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10390, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10390, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10390, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10390, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10390, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10390, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10390, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10390, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10390, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10390, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10391, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10391, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10391, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10391, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10391, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10391, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10391, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10391, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10391, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10391, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10392, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10392, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10392, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10392, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10392, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10392, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10392, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10392, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10392, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10392, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10393, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10393, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10393, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10393, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10393, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10393, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10393, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10393, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10393, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10393, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10394, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10394, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10394, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10394, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10394, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10394, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10394, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10394, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10394, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10394, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10395, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10395, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10395, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10395, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10395, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10395, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10395, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10395, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10395, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10395, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10396, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10396, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10396, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10396, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10396, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10396, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10396, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10396, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10396, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10396, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10397, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10397, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10397, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10397, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10397, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10397, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10397, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10397, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10397, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10397, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10398, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10398, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10398, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10398, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10398, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10398, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10398, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10398, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10398, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10398, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10399, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10399, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10399, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10399, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10399, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10399, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10399, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10399, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10399, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10399, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10400, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10400, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10400, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10400, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10400, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10400, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10400, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10400, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10400, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10400, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10401, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10401, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10401, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10401, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10401, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10401, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10401, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10401, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10401, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10401, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10402, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10402, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10402, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10402, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10402, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10402, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10402, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10402, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10402, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10402, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10403, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10403, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10403, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10403, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10403, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10403, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10403, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10403, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10403, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10403, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10404, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10404, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10404, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10404, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10404, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10404, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10404, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10404, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10404, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10404, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10405, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10405, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10405, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10405, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10405, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10405, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10405, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10405, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10405, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10405, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10406, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10406, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10406, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10406, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10406, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10406, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10406, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10406, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10406, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10406, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10407, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10407, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10407, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10407, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10407, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10407, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10407, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10407, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10407, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10407, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10408, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10408, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10408, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10408, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10408, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10408, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10408, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10408, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10408, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10408, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10409, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10409, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10409, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10409, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10409, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10409, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10409, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10409, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10409, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10409, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10410, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10410, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10410, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10410, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10410, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10410, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10410, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10410, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10410, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10410, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10411, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10411, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10411, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10411, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10411, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10411, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10411, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10411, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10411, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10411, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10412, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10412, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10412, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10412, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10412, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10412, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10412, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10412, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10412, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10412, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10413, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10413, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10413, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10413, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10413, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10413, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10413, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10413, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10413, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10413, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10414, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10414, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10414, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10414, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10414, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10414, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10414, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10414, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10414, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10414, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10415, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10415, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10415, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10415, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10415, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10415, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10415, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10415, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10415, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10415, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10416, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10416, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10416, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10416, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10416, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10416, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10416, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10416, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10416, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10416, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10417, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10417, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10417, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10417, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10417, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10417, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10417, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10417, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10417, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10417, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10418, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10418, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10418, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10418, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10418, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10418, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10418, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10418, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10418, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10418, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10419, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10419, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10419, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10419, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10419, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10419, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10419, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10419, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10419, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10419, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10420, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10420, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10420, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10420, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10420, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10420, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10420, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10420, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10420, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10420, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10421, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10421, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10421, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10421, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10421, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10421, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10421, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10421, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10421, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10421, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10422, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10422, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10422, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10422, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10422, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10422, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10422, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10422, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10422, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10422, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10423, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10423, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10423, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10423, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10423, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10423, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10423, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10423, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10423, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10423, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10424, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10424, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10424, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10424, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10424, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10424, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10424, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10424, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10424, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10424, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10425, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10425, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10425, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10425, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10425, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10425, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10425, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10425, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10425, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10425, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10426, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10426, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10426, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10426, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10426, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10426, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10426, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10426, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10426, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10426, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10427, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10427, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10427, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10427, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10427, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10427, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10427, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10427, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10427, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10427, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10428, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10428, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10428, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10428, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10428, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10428, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10428, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10428, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10428, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10428, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10429, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10429, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10429, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10429, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10429, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10429, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10429, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10429, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10429, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10429, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10430, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10430, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10430, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10430, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10430, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10430, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10430, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10430, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10430, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10430, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10431, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10431, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10431, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10431, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10431, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10431, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10431, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10431, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10431, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10431, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10432, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10432, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10432, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10432, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10432, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10432, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10432, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10432, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10432, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10432, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10433, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10433, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10433, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10433, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10433, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10433, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10433, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10433, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10433, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10433, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10434, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10434, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10434, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10434, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10434, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10434, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10434, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10434, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10434, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10434, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10435, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10435, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10435, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10435, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10435, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10435, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10435, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10435, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10435, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10435, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10436, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10436, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10436, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10436, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10436, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10436, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10436, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10436, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10436, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10436, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10437, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10437, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10437, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10437, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10437, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10437, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10437, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10437, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10437, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10437, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10438, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10438, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10438, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10438, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10438, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10438, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10438, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10438, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10438, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10438, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10439, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10439, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10439, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10439, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10439, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10439, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10439, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10439, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10439, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10439, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10440, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10440, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10440, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10440, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10440, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10440, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10440, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10440, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10440, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10440, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10441, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10441, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10441, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10441, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10441, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10441, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10441, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10441, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10441, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10441, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10442, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10442, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10442, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10442, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10442, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10442, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10442, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10442, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10442, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10442, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10443, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10443, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10443, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10443, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10443, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10443, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10443, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10443, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10443, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10443, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10444, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10444, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10444, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10444, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10444, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10444, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10444, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10444, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10444, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10444, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10445, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10445, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10445, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10445, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10445, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10445, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10445, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10445, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10445, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10445, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10446, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10446, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10446, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10446, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10446, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10446, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10446, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10446, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10446, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10446, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10447, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10447, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10447, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10447, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10447, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10447, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10447, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10447, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10447, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10447, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10448, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10448, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10448, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10448, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10448, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10448, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10448, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10448, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10448, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10448, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10449, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10449, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10449, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10449, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10449, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10449, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10449, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10449, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10449, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10449, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10450, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10450, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10450, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10450, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10450, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10450, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10450, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10450, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10450, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10450, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10451, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10451, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10451, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10451, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10451, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10451, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10451, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10451, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10451, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10451, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10452, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10452, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10452, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10452, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10452, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10452, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10452, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10452, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10452, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10452, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10453, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10453, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10453, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10453, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10453, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10453, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10453, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10453, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10453, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10453, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10454, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10454, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10454, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10454, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10454, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10454, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10454, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10454, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10454, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10454, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10455, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10455, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10455, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10455, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10455, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10455, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10455, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10455, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10455, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10455, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10456, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10456, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10456, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10456, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10456, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10456, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10456, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10456, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10456, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10456, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10457, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10457, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10457, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10457, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10457, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10457, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10457, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10457, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10457, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10457, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10458, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10458, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10458, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10458, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10458, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10458, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10458, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10458, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10458, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10458, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10459, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10459, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10459, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10459, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10459, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10459, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10459, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10459, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10459, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10459, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10460, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10460, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10460, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10460, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10460, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10460, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10460, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10460, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10460, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10460, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10461, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10461, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10461, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10461, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10461, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10461, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10461, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10461, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10461, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10461, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10462, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10462, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10462, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10462, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10462, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10462, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10462, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10462, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10462, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10462, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10463, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10463, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10463, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10463, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10463, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10463, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10463, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10463, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10463, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10463, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10464, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10464, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10464, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10464, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10464, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10464, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10464, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10464, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10464, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10464, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10465, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10465, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10465, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10465, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10465, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10465, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10465, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10465, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10465, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10465, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10466, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10466, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10466, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10466, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10466, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10466, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10466, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10466, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10466, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10466, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10467, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10467, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10467, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10467, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10467, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10467, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10467, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10467, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10467, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10467, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10468, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10468, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10468, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10468, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10468, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10468, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10468, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10468, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10468, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10468, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10469, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10469, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10469, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10469, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10469, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10469, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10469, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10469, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10469, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10469, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10470, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10470, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10470, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10470, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10470, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10470, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10470, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10470, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10470, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10470, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10471, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10471, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10471, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10471, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10471, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10471, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10471, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10471, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10471, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10471, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10472, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10472, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10472, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10472, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10472, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10472, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10472, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10472, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10472, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10472, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10473, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10473, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10473, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10473, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10473, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10473, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10473, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10473, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10473, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10473, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10474, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10474, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10474, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10474, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10474, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10474, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10474, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10474, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10474, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10474, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10475, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10475, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10475, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10475, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10475, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10475, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10475, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10475, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10475, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10475, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10476, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10476, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10476, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10476, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10476, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10476, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10476, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10476, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10476, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10476, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10477, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10477, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10477, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10477, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10477, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10477, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10477, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10477, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10477, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10477, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10478, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10478, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10478, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10478, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10478, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10478, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10478, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10478, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10478, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10478, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10479, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10479, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10479, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10479, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10479, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10479, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10479, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10479, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10479, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10479, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10480, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10480, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10480, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10480, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10480, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10480, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10480, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10480, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10480, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10480, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10481, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10481, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10481, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10481, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10481, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10481, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10481, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10481, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10481, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10481, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10482, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10482, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10482, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10482, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10482, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10482, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10482, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10482, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10482, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10482, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10483, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10483, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10483, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10483, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10483, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10483, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10483, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10483, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10483, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10483, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10484, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10484, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10484, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10484, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10484, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10484, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10484, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10484, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10484, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10484, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10485, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10485, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10485, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10485, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10485, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10485, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10485, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10485, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10485, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10485, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10486, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10486, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10486, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10486, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10486, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10486, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10486, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10486, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10486, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10486, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10487, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10487, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10487, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10487, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10487, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10487, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10487, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10487, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10487, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10487, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10488, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10488, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10488, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10488, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10488, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10488, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10488, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10488, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10488, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10488, "zh" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10489, "de" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10489, "en" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10489, "es" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10489, "fr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10489, "it" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10489, "ja" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10489, "ko" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10489, "pt" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10489, "tr" });

            migrationBuilder.DeleteData(
                table: "ConceptTranslations",
                keyColumns: new[] { "ConceptId", "LanguageCode" },
                keyValues: new object[] { 10489, "zh" });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10370, 1 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10371, 1 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10372, 1 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10373, 1 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10374, 1 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10375, 1 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10376, 1 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10377, 1 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10378, 2 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10379, 2 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10380, 2 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10381, 2 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10382, 2 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10383, 2 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10384, 2 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10385, 2 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10386, 3 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10387, 3 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10388, 3 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10389, 3 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10390, 3 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10391, 3 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10392, 3 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10393, 3 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10394, 4 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10395, 4 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10396, 4 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10397, 4 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10398, 4 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10399, 4 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10400, 4 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10401, 4 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10402, 5 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10403, 5 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10404, 5 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10405, 5 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10406, 5 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10407, 5 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10408, 5 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10409, 5 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10410, 6 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10411, 6 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10412, 6 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10413, 6 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10414, 6 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10415, 6 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10416, 6 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10417, 6 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10418, 7 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10419, 7 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10420, 7 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10421, 7 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10422, 7 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10423, 7 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10424, 7 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10425, 7 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10426, 8 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10427, 8 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10428, 8 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10429, 8 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10430, 8 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10431, 8 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10432, 8 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10433, 8 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10434, 9 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10435, 9 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10436, 9 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10437, 9 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10438, 9 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10439, 9 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10440, 9 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10441, 9 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10442, 10 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10443, 10 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10444, 10 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10445, 10 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10446, 10 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10447, 10 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10448, 10 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10449, 10 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10450, 11 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10451, 11 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10452, 11 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10453, 11 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10454, 11 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10455, 11 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10456, 11 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10457, 11 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10458, 12 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10459, 12 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10460, 12 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10461, 12 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10462, 12 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10463, 12 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10464, 12 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10465, 12 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10466, 13 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10467, 13 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10468, 13 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10469, 13 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10470, 13 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10471, 13 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10472, 13 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10473, 13 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10474, 14 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10475, 14 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10476, 14 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10477, 14 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10478, 14 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10479, 14 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10480, 14 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10481, 14 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10482, 15 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10483, 15 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10484, 15 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10485, 15 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10486, 15 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10487, 15 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10488, 15 });

            migrationBuilder.DeleteData(
                table: "DeckTemplateConcepts",
                keyColumns: new[] { "ConceptId", "DeckTemplateId" },
                keyValues: new object[] { 10489, 15 });

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10370);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10371);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10372);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10373);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10374);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10375);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10376);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10377);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10378);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10379);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10380);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10381);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10382);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10383);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10384);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10385);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10386);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10387);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10388);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10389);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10390);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10391);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10392);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10393);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10394);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10395);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10396);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10397);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10398);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10399);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10400);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10401);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10402);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10403);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10404);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10405);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10406);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10407);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10408);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10409);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10410);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10411);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10412);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10413);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10414);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10415);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10416);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10417);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10418);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10419);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10420);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10421);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10422);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10423);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10424);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10425);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10426);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10427);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10428);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10429);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10430);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10431);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10432);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10433);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10434);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10435);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10436);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10437);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10438);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10439);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10440);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10441);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10442);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10443);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10444);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10445);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10446);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10447);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10448);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10449);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10450);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10451);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10452);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10453);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10454);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10455);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10456);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10457);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10458);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10459);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10460);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10461);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10462);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10463);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10464);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10465);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10466);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10467);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10468);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10469);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10470);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10471);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10472);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10473);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10474);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10475);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10476);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10477);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10478);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10479);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10480);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10481);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10482);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10483);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10484);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10485);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10486);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10487);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10488);

            migrationBuilder.DeleteData(
                table: "Concepts",
                keyColumn: "Id",
                keyValue: 10489);
        }
    }
}
