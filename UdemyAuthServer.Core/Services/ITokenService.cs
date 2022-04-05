using UdemyAuthServer.Core.Configuration;
using UdemyAuthServer.Core.DTOs;
using UdemyAuthServer.Core.Models;

namespace UdemyAuthServer.Core.Services
{
    // Token üreten service interface
    // Hem üyelik işlemi gerektiren apiler için token üretiyor hem de gerektirmeyen apiler için token üretiyor.
    // Bu token service dış dünyaya açılmayacak. İçeride kullanılacak.

    // ITokenService interface
    public interface ITokenService
    {
        TokenDto CreateToken(UserApp userApp);
        ClientTokenDto CreateTokenByClient(Client client);

    }
}
