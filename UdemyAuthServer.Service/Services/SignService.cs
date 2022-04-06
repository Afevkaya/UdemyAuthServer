using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace UdemyAuthServer.Service.Services
{
    // Token içerisindeki secretkey'i şifreleyip geri döndüren class.

    // Static SignService class
    internal static class SignService
    {
        // Simetrik şifreleme metodu
        public static SecurityKey GetSymmetricSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
    }
}
