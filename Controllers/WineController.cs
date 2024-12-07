using Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Services;
using Data.Repository;
using Services.DTOs;

namespace VineriaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WineController : ControllerBase
    {
        private readonly IWineService _wineService;

        public WineController(IWineService wineService)
        {
            _wineService = wineService;
        }

       

        [HttpGet]
        public IActionResult GetWines()
        {
            try
            {
                var wines = _wineService.GetAllWines();
                return Ok(wines);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener los vinos: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult RegisterWine([FromBody] WineDTO wineDto)
        {
            _wineService.RegisterWine(wineDto);
            return Ok("Wine registered successfully");
        }

        [HttpGet("variety/{variety}")]
        public IActionResult GetWinesByVariety(string variety)
        {
            var wines = _wineService.GetWineByVariety(variety);
            if (!wines.Any()) return NotFound("No se encontraron vinos para la variedad indicada");
            return Ok(wines);
        }

        [HttpGet("stock/{name}")]
        public IActionResult GetStockByName(string name)
        {
            var wine = _wineService.GetWineByName(name);
            if (wine == null) return NotFound("No se pudo encontrar ningún vino con el nombre indicado");
            return Ok(new { wine.Name, wine.Stock });
        }

        [HttpPut("update-stock")]
        public IActionResult UpdateStock([FromQuery] string name, [FromQuery] int newStock)
        {
            _wineService.UpdateStock(name, newStock);
            return Ok("Stock updated successfully");
        }




    }
}
