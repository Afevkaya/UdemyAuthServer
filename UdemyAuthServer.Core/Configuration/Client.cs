namespace UdemyAuthServer.Core.Configuration
{
    public class Client
    {
        public string Id { get; set; }
        public string Sercret { get; set; }
        public List<string> Audiences { get; set; }

    }
}
