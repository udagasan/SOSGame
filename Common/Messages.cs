using System;

namespace Common
{
    [Serializable]
    public class Messages
    {
        public static string successMessage { get; set; } = "SOS";
        public static string ReSelectedError { get; set; } = "Boş yerleri tercih ediniz";
        public static string GameOver { get; set; } = "Oyun Bitti.";
        public static string UserNameCanNotBeEWmpty { get; set; } = "Kullanıcı adı boş olamaz";
        public static string Saved { get; set; } = "Kaydedildi";
        public static string SaveAndPlay { get; set; } = "Kaydet ve Oyna";
        public static string SavedAndGameBeginning { get; set; } = "Kaydedildi ve oyun başlıyor";
        public static string Computer { get; set; } = "Bilgisayar";
        public static string PlayerOrder { get; set; } = "Oyun Sırası";
        public static string EnterWholePlayers { get; set; } = "Bütün oyuncuların bilgilerini giriniz.";
        public static string EnterFirstPlayerName { get; set; } = "Birinci oyuncu adını giriniz";
        public static string EnterSecondPlayerName { get; set; } = "İkinci oyuncu adını giriniz";
        public static string EnterThirdPlayerName { get; set; } = "Üçüncü oyuncu adını giriniz";
        public static string EnterFourthlayerName { get; set; } = "Dördüncü oyuncu adını giriniz";
        public static string GamePlay { get; set; } = "Oyun Başlasın";
        public static string NextPlayer { get; set; } = "Sıradaki oyuncu:";
        public static string EnterPlayerName { get; set; } = "Adınız giriniz";
        public static string XXX { get; set; } = "OS Oyununa Hoş Geldinizzzz";
        public static string PleaseSelectGameSize { get; set; } = "Lütfen oyun boyutunu seçiniz";
        public static string AreYouSureExitGame { get; set; } = "Çıkmak istediğinize emin misiniz";
        public static string AreYouSureTheExitThisGame { get; set; } = "Bu oyundan çıkmak istediğinize emin misiniz?";
    }
}
