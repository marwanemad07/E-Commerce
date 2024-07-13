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

        public async Task<RestDto<UserDto?>> GetUserDtoAsyn(string email)
        {
            var restDto = new RestDto<UserDto?>();
            var user = await _accountRepository.GetUserByEmailAsync(email);
            if (user == null)
            {
                restDto.StatusCode = 404;
                return restDto;
            }
            restDto.Data = _mapper.Map<AppUser, UserDto>(user);
            restDto.StatusCode = 200;
            return restDto;
        }

        public async Task<RestDto<bool>> CheckEmailExists(string email)
        {
            var restDto = new RestDto<bool>();
            var user = await _accountRepository.GetUserByEmailAsync(email);
            if(user == null)
            {
                restDto.StatusCode = 404;
                restDto.Data = false;
                return restDto;
            }
            restDto.StatusCode = 200;
            restDto.Data = true;
            return restDto;
        }

        public async Task<RestDto<UserProfileDto?>> GetUserProfileDtoAsync(string email)
        {
            var restDto = new RestDto<UserProfileDto?>();
            var user = await _accountRepository.GetUserByEmailAsync(email);
            if (user == null)
            {
                restDto.StatusCode = 404;
                return restDto;
            }
            restDto.Data = _mapper.Map<AppUser, UserProfileDto>(user);
            restDto.StatusCode = 200;
            return restDto;

        }

        public async Task<RestDto<UserProfileDto?>> UpdateProfileAsync(string email, UserProfileDto userProfileDto)
        {
            var restDto = new RestDto<UserProfileDto?>();
            var user = await _accountRepository.GetUserByEmailAsync(email);
            if (user == null)
            {
                restDto.StatusCode = 404;
                return restDto;
            }
            user = _mapper.Map<UserProfileDto, AppUser>(userProfileDto, user);
            var result = await _accountRepository.UpdateUserAsync(user);
            if (result.Succeeded)
            {
                restDto.Data = _mapper.Map<AppUser, UserProfileDto>(user);
                restDto.StatusCode = 200;
                return restDto;
            }
            restDto.StatusCode = 400;
            return restDto;
        }

        public async Task<RestDto<UserDto?>> ChangePasswordAsync(string email, ChangePasswordDto changePasswordDto)
        {

            var resulDto = new RestDto<UserDto?>();
            var user = await _accountRepository.GetUserByEmailAsync(email);
            if (user == null)
            {
                resulDto.StatusCode = 404;
                return resulDto;
            }
            var result = await _accountRepository.ChangePasswordAsync(user,
                changePasswordDto.OldPassword,
                changePasswordDto.NewPassword);
            if (result.Succeeded)
            {
                user = await _accountRepository.GetUserByEmailAsync(email);
                resulDto.Data = _mapper.Map<AppUser, UserDto>(user!);
                resulDto.StatusCode = 200;
                return resulDto;
            }
            resulDto.StatusCode = 400;
            return resulDto;
        }
    }
}
