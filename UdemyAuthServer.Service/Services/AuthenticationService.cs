using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SharedLibrary.Dtos;
using UdemyAuthServer.Core.Configuration;
using UdemyAuthServer.Core.DTOs;
using UdemyAuthServer.Core.Models;
using UdemyAuthServer.Core.Repositories;
using UdemyAuthServer.Core.Services;
using UdemyAuthServer.Core.UnitOfWorks;

namespace UdemyAuthServer.Service.Services
{
    // API ile iletisime gececek olan service class
    // User veya client sisteme giris yapmak istediginde bu service calisacak.
    // TokenService class da bu service icerisinde kulanilir.
    // Ayrica is kurallarinin konulacagi class.

    // AuthenticationService class
    public class AuthenticationService : IAuthenticationService
    {
        // Authentice islemleri icin gerekli propertyler
        private readonly List<Client> _clients;
        private readonly ITokenService _tokenService;
        private readonly UserManager<UserApp> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<UserRefreshToken> _genericRepository;


        public AuthenticationService(IOptions<List<Client>> optionsClient,ITokenService tokenService, 
            UserManager<UserApp> userManager, IUnitOfWork unitOfWork, IGenericRepository<UserRefreshToken> genericRepository)
        {
            _clients = optionsClient.Value;
            _tokenService = tokenService;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _genericRepository = genericRepository;
        }

        // User sisteme login olduğunda çalışacak metod.
        // Business rules koyulur.
        // Login işleminden sonra user'a token dönüyoruz.
        public async Task<CustomResponseDto<TokenDto>> CreateTokenAsync(LoginDto loginDto)
        {
            if (loginDto == null)
            {
                throw new ArgumentNullException(nameof(loginDto));
            }

            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null)
            {
                return CustomResponseDto<TokenDto>.Fail(400, "Email or Password wrong", true);
            }
            if (!await _userManager.CheckPasswordAsync(user,loginDto.Password))
            {
                return CustomResponseDto<TokenDto>.Fail(400, "Email or Password wrong", true);
            }

            var token = _tokenService.CreateToken(user);
            var userRefreshToken = await _genericRepository.Where(x => x.UserId == user.Id).SingleOrDefaultAsync();

            if(userRefreshToken == null)
            {
                await _genericRepository.AddAsync(new UserRefreshToken { UserId = user.Id, Code = token.RefreshToken, Expiration = token.ResfreshTokenExpiration });
            }
            else
            {
                userRefreshToken.Code = token.RefreshToken;
                userRefreshToken.Expiration = token.ResfreshTokenExpiration;
            }

            await _unitOfWork.CommitAsync();
            return CustomResponseDto<TokenDto>.Success(200, token);
        }

        // Client(Identity işlemi gerektirmeyen API de user) sisteme giriş yaptığında çalışacak metod
        // Business rules koyulur.
        // Bu metod client tarafına ClinetToken döndürür.
        public CustomResponseDto<ClientTokenDto> CreateTokenByClient(ClientLoginDto clientLoginDto)
        {
            var client = _clients.SingleOrDefault(x => x.Id == clientLoginDto.ClientId && x.Secret == clientLoginDto.ClientSecret);
            if(client == null)
            {
                return CustomResponseDto<ClientTokenDto>.Fail(404, "ClientId or ClientSecret wrong", true);
            }
            var token = _tokenService.CreateTokenByClient(client);
            return CustomResponseDto<ClientTokenDto>.Success(200, token);
        }

        // User sisteme elindeki refresh token ile giriş yapmak isterse çalışacak metod.
        // Business rules koyulur.
        // Geriye bir toke döndürür.
        public async Task<CustomResponseDto<TokenDto>> CreateTokenByRefreshToken(string refreshToken)
        {
            var existRefreshToken = await _genericRepository.Where(x => x.Code == refreshToken).SingleOrDefaultAsync();
            if(existRefreshToken == null)
            {
                return CustomResponseDto<TokenDto>.Fail(404, "Refresh Token Not Found", true);
            }
            var user = await _userManager.FindByIdAsync(existRefreshToken.UserId);
            if(user == null)
            {
                return CustomResponseDto<TokenDto>.Fail(404, "User Id Not Found", true);
            }

            var tokenDto = _tokenService.CreateToken(user);
            existRefreshToken.Code = tokenDto.RefreshToken;
            existRefreshToken.Expiration = tokenDto.ResfreshTokenExpiration;

            await _unitOfWork.CommitAsync();
            return CustomResponseDto<TokenDto>.Success(200, tokenDto);
        }

        // User sistemden çıkmak istediğinde çalışacak metod.
        // Db'deki resfresh token'ı siler.
        // Business rules koyulur.
        public async Task<CustomResponseDto<NoContentDto>> RevokeRefreshToken(string refreshToken)
        {
            var existRefreshToken = await _genericRepository.Where(x=>x.Code == refreshToken).SingleOrDefaultAsync();
            if (existRefreshToken == null)
            {
                return CustomResponseDto<NoContentDto>.Fail(404, "Refresh Toke Not Found", true);
            }
            _genericRepository.Remove(existRefreshToken);
            await _unitOfWork.CommitAsync();
            return CustomResponseDto<NoContentDto>.Success(204);
        }
    }
}
