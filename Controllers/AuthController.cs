using Data;
using Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Services.DTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace VineriaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserDTO loginDto)
        {
            // Validación básica de los datos de entrada
            if (loginDto == null || string.IsNullOrEmpty(loginDto.Mail) || string.IsNullOrEmpty(loginDto.Password))
            {
                return BadRequest("Los datos de inicio de sesión no son válidos.");
            }

            User? user = _userService.AuthenticateUser(loginDto.Mail, loginDto.Password);
            if (user == null)
            {
                return Unauthorized("Usuario o contraseña incorrectos.");
            }

            // Crear los claims (información del usuario)
            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, user.Mail),
            new Claim(JwtRegisteredClaimNames.GivenName, user.Mail)
        };

            // Crear el token
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("TuLlaveSecretaSuperSegura123!"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _configuration["Authentication:Issuer"],
                audience: _configuration["Authentication:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(new { Token = tokenString });
        }

    }
}
