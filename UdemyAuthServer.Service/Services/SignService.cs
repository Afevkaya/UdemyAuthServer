using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace UdemyAuthServer.Service.Services
{
    // Access Token ile geri dönecek key'i symmetric şekilde imzalayıp(şifreleme) şifreli bir şekilde döndürme.

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
