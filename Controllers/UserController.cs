using Data.Entities;
using Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.DTOs;
using Services.Services;

namespace VineriaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult RegisterUser([FromBody] UserDTO userDto)
        {
            _userService.RegisterUser(userDto);
            return Ok("User registered successfully");
        }

        [HttpGet("{mail}")]
        public IActionResult GetUser(string mail)
        {
            var user = _userService.GetUserByMail(mail);
            if (user == null) return NotFound("User not found");
            return Ok(user);
        }


    }

}
