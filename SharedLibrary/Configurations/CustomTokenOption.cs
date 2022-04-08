namespace SharedLibrary.Configurations
{
    // appsettings.json dosyası içerisinde Token'a ait key-value tipinde kritik bilgiler bulunur.
    // Bu bilgilere proje içerisinde erişmek için oluşturulan class.
    // Bu bilgileri bu class'a atayabilmek için option pattern uygulamamız gerekli.
    // Option Pattern'ı da bütün projemizin ayağa kaltığı dosya olan program.cs dosyası içerisinde uyguluyoruz.


    // CustomTokenOption class
    public class CustomTokenOption
    {
        public List<string> Audience { get; set; }
        public string Issuer { get; set; }
        public int AccessTokenExpiration { get; set; }
        public int RefreshTokeExpiration { get; set; }
        public string SecurityKey { get; set; }

    }
}
