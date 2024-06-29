using E_Commerce.DAL.Models.Identity;
using System.Reflection.Metadata.Ecma335;

namespace E_Commerce.BLL.Services.Implemntations
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public AccountService(IAccountRepository accountRepository,
            IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }
        public async Task<RestDto<UserDto?>> SignInAsync(LoginUserDto loginDto)
        {
            RestDto<UserDto?> restDto = new();
            var user = await _accountRepository.GetUserByEmailAsync(loginDto.Email);
            if (user == null)
            {
                restDto.StatusCode = 404;
                return restDto;
            }
            var result = await _accountRepository.SignInAsync(user, loginDto.Password);
            if (result.Succeeded)
            {
                var dto = _mapper.Map<AppUser, UserDto>(user);
                restDto.StatusCode = 200;
                restDto.Data = dto;
                return restDto;
            }
            restDto.StatusCode = 401;
            return restDto;
        }

        public async Task<RestDto<UserDto?>> CreateUserAsync(RegisterDto registerDto)
        {
            RestDto<UserDto?> restDto = new();
            var user = _mapper.Map<RegisterDto, AppUser>(registerDto);
            var result = await _accountRepository.CreateUserAsync(user, registerDto.Password);
            if (result.Succeeded)
            {
                var dto = _mapper.Map<AppUser, UserDto>(user);
                restDto.StatusCode = 200;
                restDto.Data = dto;
                return restDto;
            }
            restDto.StatusCode = 400;
            return restDto;
        }
    }
}
