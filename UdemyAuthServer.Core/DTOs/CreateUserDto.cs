namespace UdemyAuthServer.Core.DTOs
{
    // Bir user kayıt edileceği zaman client tarafında istenilecek datalar.
    // User bu dataları girdikten sonra sisteme kayıt edilmiş olacak.
    // Bu sayede token almak isteyebilecek.

    public class CreateUserDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

    }
}
