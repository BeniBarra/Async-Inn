using AsyncInn.Models.DTO;
using AsyncInn.Models.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUser _userService;

        public UsersController(IUser service)
        {
            _userService = service;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<UserDTO>> Register(RegisterUserDTO data)
        {
            var user = await _userService.Register(data, this.ModelState);

            if(ModelState.IsValid)
            {
                return user;
            }

            return BadRequest(new ValidationProblemDetails(ModelState));
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO data)
        {
            var user = await _userService.Login(data.Username, data.Password);

            if (user == null)
            {
                return Unauthorized();
            }
            return user;
        }

        [Authorize(Roles = "administrator")]
        [HttpGet("me")]
        public async Task<ActionResult<UserDTO>> Me()
        {
            // Following the [Authorize] phase, this.User will be ... you.
            // Put a breakpoint here and inspect to see what's passed to our getUser method
            return await _userService.GetUserAsync(this.User);
        }
    }
}
