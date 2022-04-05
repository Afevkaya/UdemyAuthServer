using SharedLibrary.Dtos;
using UdemyAuthServer.Core.DTOs;

namespace UdemyAuthServer.Core.Services
{
    // Bu işlem bir database işlemi olmasına rağmen repo tarafında yazdığımız bir kod yok.
    // Bunun nedeni Identity API içinde bizim için hazır olan metodlar bulunmaktadır.


    // IUserService interface
    public interface IUserService
    {
        Task<CustomResponseDto<UserAppDto>> CreateUserAsync(CreateUserDto createUserDto);
        Task<CustomResponseDto<UserAppDto>> GetUserByNameAsync(string userName);
    }
}
