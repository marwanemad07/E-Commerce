namespace E_Commerce.BLL.Services.Interfaces
{
    public interface IAccountService
    {
        public Task<RestDto<UserDto?>> SignInAsync(LoginUserDto loginDto);
        public Task<RestDto<UserDto?>> CreateUserAsync(RegisterDto registerDto);
    }
}
