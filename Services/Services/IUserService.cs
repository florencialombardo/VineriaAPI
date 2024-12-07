using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Entities;
using Services.DTOs;

namespace Services.Services
{
    public interface IUserService
    {
        User? AuthenticateUser(string username, string password);

        void RegisterUser(UserDTO user);
    }
}
