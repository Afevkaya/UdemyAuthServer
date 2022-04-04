namespace UdemyAuthServer.Core.DTOs
{
    public class ClientTokenDto
    {
        public string RefreshToken { get; set; }
        public DateTime ResfreshTokenExpiration { get; set; }

    }
}
