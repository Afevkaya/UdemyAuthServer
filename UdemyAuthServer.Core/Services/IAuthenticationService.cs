using SharedLibrary.Dtos;
using UdemyAuthServer.Core.DTOs;

namespace UdemyAuthServer.Core.Services
{

    // Kullanıcı ile iletişime geçecek olan interface
    // Kullanıcı sisteme authentication olacağı zaman çalışacak olan class'ın gene yapısını belirlediğimiz interface
    // Bu interface, kullanıcı sisteme authentice olduktan sonra toke dönecek. Bu işlemi de ITokenService yapacak. ITokenService kendi içimizde kullanıyoruz.
    // Bu interface'in metodları
    // CreateTokenAsync --> Kullanıcı login olduktan sonra token dönecek metod.
    // CreateTokenByRefreshToken --> Kullanıcının AccessToken'ının süresi bittiğinde resfresh token ile token dönecek metod.
    // RevokeRefreshToken --> Kullanıcı logout olduktan sonra refresh token'ı silecek metod.
    // CreateTokenByClient --> Üyelik sistemi gerektirmeyen API'lerde token dönecek metod.


    // IAuthenticationService interface
    public interface IAuthenticationService
    {
        Task<CustomResponseDto<TokenDto>> CreateTokenAsync(LoginDto loginDto);
        Task<CustomResponseDto<TokenDto>> CreateTokenByRefreshToken(string refreshToken);
        Task<CustomResponseDto<NoContentDto>> RevokeRefreshToken(string refreshToken);
        CustomResponseDto<ClientTokenDto> CreateTokenByClient(ClientLoginDto clientLoginDto);

    }
}
