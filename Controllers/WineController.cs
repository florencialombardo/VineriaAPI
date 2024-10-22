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
        private readonly WineService _wineService;

        public WineController(WineService wineService)
        {
            _wineService = wineService;
        }

        [HttpPost]
        public IActionResult AddWine(Wine wine)
        {
            _wineService.AddWine(wine);
            return Ok(wine);
        }

        [HttpGet]
        public IActionResult GetWines()
        {
            var wines = _wineService.GetAllWines();
            return Ok(wines);
        }

        [HttpGet("{id}")]
        public IActionResult GetWine(int id)
        {
            var wine = _wineService.GetWineById(id);
            if (wine == null) return NotFound();
            return Ok(wine);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateWineStock(int id, [FromBody] int newStock)
        {
            await _wineService.UpdateWineStock(id, newStock);
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<Wine>>> GetAllWines()
        {
            var wines = await _wineService.GetAllWines();
            return wines.Select(w => new Wine
            {
                Name = w.Name,
                Variety = w.Variety,
                Year = w.Year,
                Region = w.Region,
                Stock = w.Stock
            }).ToList();
        }

        [HttpPost]
        public async Task<ActionResult> AddWine(Wine wineDto)
        {
            var wine = new Wine
            {
                Name = wineDto.Name,
                Variety = wineDto.Variety,
                Year = wineDto.Year,
                Region = wineDto.Region,
                Stock = wineDto.Stock
            };
            await _wineService.AddWine(wine);
            return CreatedAtAction(nameof(GetAllWines), new { id = wine.Id }, wineDto);
        }


    }
}
