namespace UdemyAuthServer.Core.DTOs
{
    // Kullanıcı tarafına döneceğimiz Token'ların genel yapı(model)sını oluşturur.
    // Bu token yapısı Üyelik işlemleri gerektiren API'lerde dönen token yapısıdır.
    // TokenDto class propertyleri AccessToken, RefreshToken ve bunların kullanım süreleridir.

    // TokenDto class
    public class TokenDto
    {
        public string AccessToken { get; set; }
        public DateTime AccessTokenExpiration { get; set; }
        public string RefreshToken { get; set; }
        public DateTime ResfreshTokenExpiration { get; set; }
    }
}
