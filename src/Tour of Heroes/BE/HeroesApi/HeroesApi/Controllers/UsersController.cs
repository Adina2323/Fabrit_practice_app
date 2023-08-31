using AutoMapper;
using BusinessLogicLayer.Users;
using DataAcessLayer.Mappings.DTOs;
using DataAcessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HeroesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsersAsync()
        {
            var users = await _userService.GetUsersAsync();

            if (users == null)
            {
                return Ok(new List<User>()); 
            }

           // return Ok(users.Select(user => _mapper.Map<UserUpdateDTO>(user)));
           return Ok(users);
        }

        [HttpGet("{email}")]
        public async Task<ActionResult<User>> GetUserAsync(string email)
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

            var userdto = new UserUpdateDTO()
            {
                Email = null,
                Name = null,
                UserName = null,
            };

            //return _mapper.Map(user,userdto);
            return user;
        }

        [HttpPost("add-user")]
        public async Task<ActionResult<User>> PostUserAsync(string email, string password, string username, string name)
        {
            if (await _userService.GetUsersAsync() == null)
            {
                return Problem("Entity set 'DataContext.Users'  is null.");
            }

            if (await _userService.GetUserByEmailAsync(email) != null)
            {
                return Conflict("Email already redistered");
            }
            return await _userService.AddUserAsync(email, password, username, name);

        }

        [HttpPut("update-password")]
        public async Task<ActionResult<int>> PutNewPassword(string email, string newPassword)
        {
            if (await _userService.GetUserByEmailAsync(email) == null)
            {
                return Conflict("Account binded to this email not found!");
            }
            var user = await _userService.GetUserByEmailAsync(email);

            return await _userService.UpdatePassword(user, newPassword);
        }

        [HttpPut("{id}/update-user")]
        public async Task<ActionResult> UpdateUser(UserUpdateDTO user, long id)
        {
            try
            {
                await _userService.UpdateUser(user,id);
            }
            catch (DbUpdateConcurrencyException)
            {
                
                throw;
            }

            return NoContent();
        }

    }
}
