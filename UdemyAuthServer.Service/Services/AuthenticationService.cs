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
    public class AuthenticationService : IAuthenticationService
    {
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

        public Task<CustomResponseDto<ClientTokenDto>> CreateTokenByClient(ClientLoginDto clientLoginDto)
        {
            throw new NotImplementedException();
        }

        public Task<CustomResponseDto<TokenDto>> CreateTokenByRefreshToken(string refreshToken)
        {
            throw new NotImplementedException();
        }

        public Task<CustomResponseDto<NoContentDto>> RevokeRefreshToken(string refreshToken)
        {
            throw new NotImplementedException();
        }
    }
}
