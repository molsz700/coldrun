using Coldrun.Database.Entities;
using Coldrun.Queries.Trucks.GetTruck;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Coldrun.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TruckController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TruckController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public IActionResult CreateTruck([FromBody] Truck truck)
        {
            return Ok();
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> GetTruck(string code)
        {
            var request = new GetTruckQuery()
            {
                Code = code
            };

            var result = await _mediator.Send(request);  
            
            return Ok(result);
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
