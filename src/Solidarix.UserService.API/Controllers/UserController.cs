using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Solidarix.UserService.Domain.Entities;

namespace Solidarix.UserService.API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class UserController : Controller
    {
        private readonly IStringLocalizer<UserController> _localizer;
        //private readonly IUserRepository _userRepository;
        //private readonly ITokenService _tokenService;

        public UserController(
            IStringLocalizer<UserController> localizer,
            IUserRepository userRepository,
            ITokenService tokenService)
        {
            _localizer = localizer;
            _userRepository = userRepository;
            _tokenService = tokenService;
        }
        // POST api/v1/user/signup
        [HttpPost("signup")]
        public IActionResult Signup(SignupDto dto)
        {
            try
            {
                var user = new User(dto.Email, dto.PasswordHash, dto.FullName);
                _userRepository.Add(user);

                return Ok(new { message = _localizer["Signup_Success"] });
            }
            catch (DomainException ex)
            {
                var message = _localizer[ex.ErrorCode];
                return BadRequest(new { error = message });
            }
        }

        // POST api/v1/user/login
        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            var user = _userRepository.GetByEmail(dto.Email);
            if (user == null || user.PasswordHash != dto.PasswordHash)
                return Unauthorized(new { error = _localizer["Error_InvalidCredentials"] });

            var token = _tokenService.GenerateToken(user);
            return Ok(new { token });
        }

        // POST api/v1/user/refresh
        [HttpPost("refresh")]
        public IActionResult Refresh(RefreshDto dto)
        {
            var newToken = _tokenService.RefreshToken(dto.Token);
            if (newToken == null)
                return Unauthorized(new { error = _localizer["Error_InvalidToken"] });

            return Ok(new { token = newToken });
        }
        public IActionResult Index()
        {
            return View();
        }
    }

    // DTOs
    public record SignupDto(string Email, string PasswordHash, string FullName);
    public record LoginDto(string Email, string PasswordHash);
    public record RefreshDto(string Token);
}
