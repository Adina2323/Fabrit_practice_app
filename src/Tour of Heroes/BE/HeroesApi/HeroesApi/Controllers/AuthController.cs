using BusinessLogicLayer.AuthService;
using BusinessLogicLayer.Email;
using BusinessLogicLayer.Token;
using BusinessLogicLayer.Users;
using DataAcessLayer.Mappings.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HeroesApi.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;
        private readonly IEmailService _emailService;

        public AuthController(IAuthService authService, ITokenService tokenService, IUserService userService, IEmailService emailService)
        {
            _authService = authService;
            _tokenService = tokenService;
            _userService = userService;
            _emailService = emailService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginDTO userLogin)
        {
            var user = await _authService.AuthenticateUserAsync(userLogin);

            if (user == null)
            {
                return Unauthorized();
            }

            var token = _tokenService.GenerateJSONWebToken(userLogin.Email);

            return Ok(token);
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterDTO register)
        {
            if (await _userService.GetUserByEmailAsync(register.Email) != null)
            {
                return Conflict("Email already registered");
            }
            string url = $"https://localhost/api/users/{register.Email}";

            var inviteMail = new InviteMailDTO
            {
                EmailTo = register.Email,
                ReceiverName = register.Name,
                Body = "New invitation" +
                "<p>Hello \n You have been invited to our private site.</p>" +
                "<p>To log in, use this super secret password:'Pa$$word'</p>" +
                "<p>See you<a href= 'http://localhost:4200' > here </ a ></p> ",
                Subject = "Welcome to Heroes App!",
            };

            //await _emailService.SendEmailAsync(inviteMail);
            await _userService.AddUserAsync(register);
            var token = _tokenService.GenerateJSONWebToken(register.Email);

            return Ok(token);
        }
    }
}
