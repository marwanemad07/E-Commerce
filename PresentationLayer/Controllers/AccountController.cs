namespace E_Commerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> SignIn(LoginUserDto loginDto)
        {
            var resultDto = await _accountService.SignInAsync(loginDto);
            if (resultDto.Data == null)
            {
                if (resultDto.StatusCode == 404)
                {
                    return NotFound(new ApiResponse(resultDto.StatusCode));
                }
                return Unauthorized(new ApiResponse(resultDto.StatusCode));
            }
            return Ok(resultDto.Data);
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            var resultDto = await _accountService.CreateUserAsync(registerDto);
            if (resultDto.Data == null)
            {
                return BadRequest(new ApiResponse(resultDto.StatusCode));
            }
            return Ok(resultDto.Data);
        }

        [HttpGet("user")]
        [Authorize]
        public async Task<ActionResult<RestDto<UserDto>>> GetCurrentUser()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            if (email != null)
            {
                var resultDto = await _accountService.GetUserDtoAsyn(email);
                if (resultDto.Data == null)
                {
                    return NotFound(new ApiResponse(resultDto.StatusCode));
                }
                return Ok(resultDto);
            }
            return BadRequest(new ApiResponse(400, "Token hasn't an email"));
        }

        [HttpGet("emailexists")]
        [Authorize]
        public async Task<ActionResult<RestDto<UserDto>>> CheckEmailExists(string email)
        {
            var resultDto = await _accountService.CheckEmailExists(email);
            if (resultDto.Data == false)
            {
                return NotFound(new ApiResponse(resultDto.StatusCode));
            }
            return Ok(resultDto);
        }

        [HttpPost("changepassword")]
        [Authorize]
        public async Task<ActionResult<RestDto<UserDto>>> ChangePassword(ChangePasswordDto changePasswordDto)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            if (email != null)
            {
                var resultDto = await _accountService.ChangePasswordAsync(email, changePasswordDto);
                if (resultDto.Data == null)
                {
                    return BadRequest(new ApiResponse(resultDto.StatusCode));
                }
                return Ok(resultDto);
            }
            return BadRequest(new ApiResponse(400, "Token hasn't an email"));
        }

        [HttpGet("profile")]
        [Authorize]
        public async Task<ActionResult<RestDto<UserProfileDto>>> GetUserProfile()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            if (email != null)
            {
                var resultDto = await _accountService.GetUserProfileDtoAsync(email);
                if (resultDto.Data == null)
                {
                    return NotFound(new ApiResponse(resultDto.StatusCode));
                }
                return Ok(resultDto);
            }
            return BadRequest(new ApiResponse(400, "Token hasn't an email"));
        }

        [HttpPut("updateprofile")]
        [Authorize]
        public async Task<ActionResult<RestDto<UserProfileDto>>> UpdateProfile(UserProfileDto userDto)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            if (email != null)
            {
                var resultDto = await _accountService.UpdateProfileAsync(email, userDto);
                if (resultDto.Data == null)
                {
                    return BadRequest(new ApiResponse(resultDto.StatusCode));
                }
                return Ok(resultDto);
            }
            return BadRequest(new ApiResponse(400, "Token hasn't an email"));
        }
    }
}
