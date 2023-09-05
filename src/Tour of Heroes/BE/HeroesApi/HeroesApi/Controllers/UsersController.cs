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

        public UsersController(
            IUserService userService, 
            IMapper mapper,
            ITokenService tokenService,
            IEmailService emailService )
        {
            _userService = userService;
            _mapper = mapper;
            _tokenService = tokenService;
            _emailService = emailService;
        }
        //[HttpGet]
        //[Authorize]
        //public ActionResult<string> GetEmailOfCurrentUser() 
        //{
        //    var email = HttpContext.User.Claims.First(c => c.Type == "Email").Value;
        //    return Ok(email);
        //}

        [HttpGet]
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

        [HttpPut("update-user/{id}")]
        [Authorize(Policy = "RequireLoggedIn")]
        public async Task<IActionResult> UpdateUser(
            UserUpdateDTO user,
            long id)
        {
            try
            {
                await _userService.UpdateUser(user, id);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }
    }
}
