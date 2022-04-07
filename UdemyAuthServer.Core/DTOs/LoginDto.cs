namespace UdemyAuthServer.Core.DTOs
{
    // Kullancı sisteme giriş yaparken kullanıcıdan istenilecek bilgileri bulunduran dto class.

    // LoginDto class
    public class LoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
