namespace UdemyAuthServer.Core.DTOs
{

    // Login işlemi gerektirmeyen api'lerde Token almak için gereken parametreler.


    // ClientLoginDto class
    public class ClientLoginDto
    {

        public string ClientId { get; set; }
        public string ClientSecret { get; set; }

    }
}
