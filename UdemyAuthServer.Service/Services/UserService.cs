using Microsoft.AspNetCore.Identity;
using SharedLibrary.Dtos;
using UdemyAuthServer.Core.DTOs;
using UdemyAuthServer.Core.Models;
using UdemyAuthServer.Core.Services;
using UdemyAuthServer.Service.Mapping;

namespace UdemyAuthServer.Service.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<UserApp> _userManager;

        public UserService(UserManager<UserApp> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CustomResponseDto<UserAppDto>> CreateUserAsync(CreateUserDto createUserDto)
        {
            if (createUserDto == null)
            {
                throw new ArgumentNullException(nameof(createUserDto));
            }

            var user = new UserApp {Email = createUserDto.Email, UserName = createUserDto.UserName};
            var result = await _userManager.CreateAsync(user, createUserDto.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description).ToList();
                return CustomResponseDto<UserAppDto>.Fail(400, new ErrorDto(errors, true));
            }

            return CustomResponseDto<UserAppDto>.Success(200, ObjectMapper.Mapper.Map<UserAppDto>(user));
        }

        public async Task<CustomResponseDto<UserAppDto>> GetUserByNameAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                return CustomResponseDto<UserAppDto>.Fail(404,"User Not Found",true);
            }
            return CustomResponseDto<UserAppDto>.Success(200,ObjectMapper.Mapper.Map<UserAppDto>(user));
        }
    }
}
