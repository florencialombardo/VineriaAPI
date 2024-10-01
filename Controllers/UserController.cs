using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VineriaAPI.Models;
using VineriaAPI.Repository;

namespace VineriaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly WineRepository _repository;

        public UserController(WineRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult AddUser(User user)
        {
            _repository.AddUser(user);
            return Ok(user);
        }
    }

}
