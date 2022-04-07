namespace UdemyAuthServer.Core.Models
{

    // UserRefreshToken class'ı property'leri
    // UserId
    // İçinde bulundurduğu kodu
    // RefreshToken'ın ömrü

    // UserResfreshToken Entity class
    public class UserRefreshToken
    {
        public string UserId { get; set; }
        public string Code { get; set; }
        public DateTime Expiration { get; set; }
    }
}
