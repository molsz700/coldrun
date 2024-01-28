using Coldrun.Database.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Coldrun.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TruckController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateTruck([FromBody] Truck truck)
        {
            return Ok();
        }

        [HttpGet("{code}")]
        public IActionResult GetTruck(string code)
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult GetTrucksFiltered([FromQuery] Truck truck)
        {
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateTruck([FromBody] Truck truck)
        {
            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteTruck(string code)
        {
            return Ok();
        }
        
    }
}
