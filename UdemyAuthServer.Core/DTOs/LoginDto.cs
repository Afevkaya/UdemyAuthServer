namespace UdemyAuthServer.Core.DTOs
{
    // Bir login işlemi gerçekleşirken kullanıcıdan istenecek veriler.
    // Eğer database deki ile eşleşirsen kullanıcıya Token dönecek.


    // LoginDto class
    public class LoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
