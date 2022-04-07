namespace UdemyAuthServer.Core.DTOs
{
    // Kullanıcıyı database kaydetmek için kullanıcıdan alacağımız bilgileri bulunduran dto class

    // CreateUserDto
    public class CreateUserDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

    }
}
