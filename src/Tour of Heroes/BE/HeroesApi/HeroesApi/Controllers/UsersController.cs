using AutoMapper;
using BusinessLogicLayer.Users;
using DataAcessLayer.Mappings.DTOs;
using DataAcessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Drawing;
using System.Security.Cryptography;
using BusinessLogicLayer.Token;
using BusinessLogicLayer.Email;
using Microsoft.Win32;
using BusinessLogicLayer;

namespace HeroesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        private readonly IEmailService _emailService;
        private readonly IHeroService _heroService;

        public UsersController(
            IUserService userService, 
            IMapper mapper,
            ITokenService tokenService,
            IEmailService emailService,
            IHeroService heroService)
        {
            _userService = userService;
            _mapper = mapper;
            _tokenService = tokenService;
            _emailService = emailService;
            _heroService = heroService;
        }

        [HttpGet("email")]
        [Authorize(Policy = "RequireLoggedIn")]
        public ActionResult<string> GetEmailOfCurrentUser()
        {
            var email = HttpContext.User.Claims.First(c => c.Type == "Email").Value;
            return Ok(email);
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetUsersAsync()
        {
            var users = await _userService.GetUsersAsync();

            if (users == null)
            {
                return Ok(new List<User>());
            }
            return Ok(users);
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> GetUserAsync(string email)
        {
            if (await _userService.GetUsersAsync() == null)
            {
                return NotFound();
            }
            var user = await _userService.GetUserByEmailAsync(email);

            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPut("update-password")]
        [Authorize(Policy = "RequireLoggedIn")]
        public async Task<IActionResult> PutNewPassword(PasswordUpdateDTO userUpdate)
        {
            if (await _userService.GetUserByEmailAsync(userUpdate.Email) == null)
            {
                return Conflict("Account binded to this email not found!");
            }
            var user = await _userService.GetUserByEmailAsync(userUpdate.Email);

            return Ok(await _userService.UpdatePassword(user, userUpdate.Password));
        }

        [HttpPut("update-user")]
        [Authorize(Policy = "RequireLoggedIn")]
        public async Task<IActionResult> UpdateUser([FromBody] UserUpdateDTO user)
        {
            try
            {
                var currentUserEmail = User.FindFirst(ClaimTypes.Email)?.Value;
                await _userService.UpdateUser(user, currentUserEmail);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        [HttpDelete("delete-user")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteUserAsync(string email)
        {
            try
            {
                await _userService.DeleteUserAsync(email);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
            return Ok();

        }

        [HttpPost("send-invite")]
        [AllowAnonymous]
        public async Task<IActionResult> SendEmail(string email, string name)
        {
            try
            {
                var inviteMail = new InviteMailDTO
                {
                    EmailTo = email,
                    ReceiverName = name,
                    Body = "New invitation" +
                   "<p>Hello \n You have been invited to our site.</p>" +
                   "<p>See you<a href= 'http://localhost:4200' > here </ a ></p> ",
                    Subject = "Welcome to Heroes App!",
                };
                await _emailService.SendEmailAsync(inviteMail);
                return Ok();
            }
            catch
            {
                throw;
            }
            return NotFound();
        }

        [HttpPut("choose-hero")]
        //[Authorize(Policy = "RequireLoggedIn")]
        public async Task ChooseHeroAsync([FromBody]ChooseHeroDTO chooseHeroDTO)
        {
            await _heroService.AssignHerotoUser(chooseHeroDTO.Email, chooseHeroDTO.HeroId);
        }

        [HttpGet("user-picture")]
        public async Task<IActionResult> GetHerofUser(string email)
        {
            var user = await _userService.GetUserByEmailAsync(email);
            if (user == null)
            {
                return Ok(user);
            }
            var hero = await _heroService.GetHeroByIdAsync((long)user.HeroId);
            var heroShow = new HeroDisplayDto
            {
                Name = hero.Name,
                Picture =await  _heroService.GetPictureOfHero(hero.Id)
            };
            return Ok(heroShow);
            
        }

    }
}
