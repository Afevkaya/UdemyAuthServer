namespace UdemyAuthServer.Core.DTOs
{

    // Kullanıcı database kayıt edildikten sonra kullanıcıya dönecek bilgileri bulunduran dto class

    // UserAppDto class
    public class UserAppDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string City { get; set; }

    }
}
