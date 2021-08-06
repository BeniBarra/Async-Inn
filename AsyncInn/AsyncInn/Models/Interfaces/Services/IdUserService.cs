using AsyncInn.Models.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces.Services
{
    public class IdUserService : IUser
    {
        private UserManager<ApplicationUser> _userManager;
        private JwtTokenService _tokenService;

        public IdUserService(UserManager<ApplicationUser> manager, JwtTokenService jwtTokenService)
        {
            _userManager = manager;
            _tokenService = jwtTokenService;
        }

        public async Task<UserDTO> Login(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);

            if (await _userManager.CheckPasswordAsync(user, password))
            {
                return new UserDTO
                {
                    Id = user.Id,
                    Username = user.UserName,
                    Token = await _tokenService.GetToken(user, System.TimeSpan.FromMinutes(15))
                };
            }
            return null;
        }

        public async Task<UserDTO> Register(RegisterUserDTO data, ModelStateDictionary modelState)
        {
            var user = new ApplicationUser
            {
                UserName = data.Username,
                Email = data.Email,
                PhoneNumber = data.PhoneNumber
            };

            var result = await _userManager.CreateAsync(user, data.Password);

            if (result.Succeeded)
            {
                // Because we have a "Good" user, let's add them to their proper role
                await _userManager.AddToRolesAsync(user, data.Roles);
                return new UserDTO
                {
                    Id = user.Id,
                    Username = user.UserName,
                    Token = await _tokenService.GetToken(user, System.TimeSpan.FromMinutes(15)),
                    Roles = await _userManager.GetRolesAsync(user)
                };
            }

            foreach (var error in result.Errors)
            {
                var errorKey =
                    error.Code.Contains("Password") ? nameof(data.Password) :
                    error.Code.Contains("Email") ? nameof(data.Email) :
                    error.Code.Contains("UserName") ? nameof(data.Username) :
                    "";

                modelState.AddModelError(errorKey, error.Description);
            }
            
            return null;
        }

        public async Task<UserDTO> GetUserAsync(ClaimsPrincipal principal)
        {
            var user = await _userManager.GetUserAsync(principal);
            return new UserDTO
            {
                Id = user.Id,
                Username = user.UserName
            };
        }
    }
}
