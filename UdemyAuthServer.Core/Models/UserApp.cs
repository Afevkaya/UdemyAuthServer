using Microsoft.AspNetCore.Identity;

namespace UdemyAuthServer.Core.Models
{
    // User Entity
    public class UserApp : IdentityUser
    {
        public string City { get; set; }
    }
}
