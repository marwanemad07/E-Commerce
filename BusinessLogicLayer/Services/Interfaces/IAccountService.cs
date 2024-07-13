using E_Commerce.BLL.DTOs;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace E_Commerce.BLL.Services.Interfaces
{
    public interface IAccountService
    {
        public Task<RestDto<UserDto?>> SignInAsync(LoginUserDto loginDto);
        public Task<RestDto<UserDto?>> CreateUserAsync(RegisterDto registerDto);
        public Task<RestDto<UserDto?>> GetUserDtoAsyn(string email);
        public Task<RestDto<bool>> CheckEmailExists(string email);
        public Task<RestDto<UserDto?>> ChangePasswordAsync(string email, ChangePasswordDto changePasswordDto);
        public Task<RestDto<UserProfileDto?>> GetUserProfileDtoAsync(string email);
        public Task<RestDto<UserProfileDto?>> UpdateProfileAsync(string email, UserProfileDto userDt);
    }
}
