using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VineriaAPI.Models;
using VineriaAPI.Repository;

namespace VineriaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WineController : ControllerBase
    {
        private readonly WineRepository _repository;

        public WineController(WineRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult AddWine(Wine wine)
        {
            _repository.AddWine(wine);
            return Ok(wine);
        }

        [HttpGet]
        public IActionResult GetWines()
        {
            var wines = _repository.GetWines();
            return Ok(wines);
        }

        [HttpGet("{name}")]
        public IActionResult GetWine(string name)
        {
            var wine = _repository.GetWineByName(name);
            if (wine == null) return NotFound();
            return Ok(wine);
        }
    }
}
