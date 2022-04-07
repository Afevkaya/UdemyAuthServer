namespace UdemyAuthServer.Core.DTOs
{

    // Kullanıcı tarafına döneceğimiz Token'ların genel yapı(model)sını oluşturur.
    // ClientTokenDto class üyelik işlemleri gerektirmeyen API'ler de kullanılır.
    // ClientTokenDto class propertyleri AccessToken ve AccessToken ömrüdür.

    // ClientTokenDto class
    public class ClientTokenDto
    {
        public string AccessToken { get; set; }
        public DateTime AccessTokenExpiration { get; set; }

    }
}
