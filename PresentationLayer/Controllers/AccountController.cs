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
            if(resultDto.Data == null)
            {
                if(resultDto.StatusCode == 404)
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
            if(resultDto.Data == null)
            {
                return BadRequest(new ApiResponse(resultDto.StatusCode));
            }
            return Ok(resultDto.Data);
        }
    }
}
