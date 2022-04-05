namespace UdemyAuthServer.Core.DTOs
{

    // User kayıt edildikten sonra user tarafına dönecek Dto class

    // UserAppDto class
    public class UserAppDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string City { get; set; }

    }
}
