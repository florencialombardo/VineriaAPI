using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Services;

namespace VineriaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CataController : ControllerBase
    {
        private readonly ICataService _cataService;

        public CataController(ICataService cataService)
        {
            _cataService = cataService;
        }

        [HttpGet("future")]
        public IActionResult GetFutureCatas()
        {
            var catas = _cataService.GetCatasFuturas();
            if (!catas.Any()) return NotFound("No future catas found");
            return Ok(catas);
        }

        [HttpPost("{cataId}/add-guests")]
        public IActionResult AddGuestsToCata(int cataId, [FromBody] List<User> guestIds)
        {
            _cataService.AddGuestsToCata(cataId, guestIds);
            return Ok("Guests added to the cata successfully");
        }
    }
}
