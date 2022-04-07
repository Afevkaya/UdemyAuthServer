namespace UdemyAuthServer.Core.DTOs
{

    // Üyelik işlemleri gerektirmeyen durumlarda clienttean istenilecek bilgileri bulunduran dto class

    // ClientLoginDto class
    public class ClientLoginDto
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }

    }
}
