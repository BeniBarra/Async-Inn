using AsyncInn.Models.DTO;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncInn.Models.Interfaces
{
    public interface IUser
    {
        public Task<UserDTO> Register(RegisterUserDTO data, ModelStateDictionary modelState);
        public Task<UserDTO> Login(string username, string password);
    }
}
