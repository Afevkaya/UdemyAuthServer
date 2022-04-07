using SharedLibrary.Dtos;
using UdemyAuthServer.Core.DTOs;

namespace UdemyAuthServer.Core.Services
{
    // Kullanıcıya ait işlemlerin genel hatlarını belirlediğimiz interface class
    // Bu interface API ile iletişime geçecek interface
    // User'a ait repo işlemleri yazılmamaktadır.
    // Çünkü Identity API içinde repo ile ilgili metodlar bulunmaktadır.

    // IUserService interface
    public interface IUserService
    {
        Task<CustomResponseDto<UserAppDto>> CreateUserAsync(CreateUserDto createUserDto);
        Task<CustomResponseDto<UserAppDto>> GetUserByNameAsync(string userName);
    }
}
