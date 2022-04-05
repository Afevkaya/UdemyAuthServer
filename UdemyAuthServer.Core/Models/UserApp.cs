using Microsoft.AspNetCore.Identity;

namespace UdemyAuthServer.Core.Models
{
    // User Entity
    // IdentityUser class'ını implement etmektedir.
    // IdentityUser class'ı içerisinde user'a ait birçok property bulunmaktadır.
    // Ayrıca Identity API içerisinde işimize yarayacak birçok metod bulunmaktadır.
    // Fazladan bir property eklemek istersek oluşturduğumuz UserApp class'ı içinde tanımlayabiliriz.
    public class UserApp : IdentityUser
    {
        public string City { get; set; }
    }
}
