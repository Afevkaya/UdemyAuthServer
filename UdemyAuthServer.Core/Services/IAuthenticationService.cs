using SharedLibrary.Dtos;
using UdemyAuthServer.Core.DTOs;

namespace UdemyAuthServer.Core.Services
{

    // Login işlemi gerçekleştikten sonra veya client yeni bir token istedikten sonra kullanıcıya token dönecek interface
    // Client'a bir bilgi döneceğimiz için temel yapımızı kullanıyoruz.

    // IAuthenticationService interface
    public interface IAuthenticationService
    {
        Task<CustomResponseDto<TokenDto>> CreateTokenAsync(LoginDto loginDto);
        Task<CustomResponseDto<TokenDto>> CreateTokenByRefreshToken(string refreshToken);
        Task<CustomResponseDto<NoContentDto>> RevokeRefreshToken(string refreshToken);
        CustomResponseDto<ClientTokenDto> CreateTokenByClient(ClientLoginDto clientLoginDto);

    }
}
