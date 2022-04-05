namespace UdemyAuthServer.Core.DTOs
{
    // Token üreten server logIn işlemi gerçekleştikten sonra client'a döneceği property'leri tanımladık
    // Bu propertyler
    // AccessToken --> login işlemlerinde kullanılan token ve onun süresi    
    // RefreshToken --> AccessToken'in süresi dolduğunda Token üreten server'dan yeni Access ve Refresh Token sağlayan token ve onun süresi
    // Server tarafında RefreshToken ve onun süresi db'ye kayıt edilir.
    
    // TokenDto class
    public class TokenDto
    {
        public string AccessToken { get; set; }
        public DateTime AccessTokenExpiration { get; set; }
        public string RefreshToken { get; set; }
        public DateTime ResfreshTokenExpiration { get; set; }
    }
}
