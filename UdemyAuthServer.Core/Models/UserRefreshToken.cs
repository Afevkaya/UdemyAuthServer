namespace UdemyAuthServer.Core.Models
{
    // UserResfreshToken Entity
    // UserRefreshToken class'ı içerisinde
    // Ait olduğu kullanıcının Id'si
    // İçinde bulundurduğu kodu
    // Ve RefreshToken'ın ömrü bulunmaktadır.
    public class UserRefreshToken
    {
        public string UserId { get; set; }
        public string Code { get; set; }
        public DateTime Expiration { get; set; }
    }
}
