using UdemyAuthServer.Core.Configuration;
using UdemyAuthServer.Core.DTOs;
using UdemyAuthServer.Core.Models;

namespace UdemyAuthServer.Core.Services
{
    
    // Token üretecek class'ın genel yapısını oluşturduğumuz interface
    // Bu service hem üyelik işlemi gerektiren API'ler için hem de gerektirmeyen API'ler için token üretir.
    // Kullanıcı ile direk iletişime geçmeyen bir service'dir.

    // ITokenService interface
    public interface ITokenService
    {
        TokenDto CreateToken(UserApp userApp);
        ClientTokenDto CreateTokenByClient(Client client);

    }
}
