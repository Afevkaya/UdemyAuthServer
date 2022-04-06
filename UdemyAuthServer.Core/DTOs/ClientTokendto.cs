namespace UdemyAuthServer.Core.DTOs
{
    // ClientTokenDto class
    
    // Bu class herhangi bir üyelik işlemi istemeyen ama yine de Token kullanmak isteyen API'ler için kullanılır. 
    public class ClientTokenDto
    {
        public string AccessToken { get; set; }
        public DateTime AccessTokenExpiration { get; set; }

    }
}
