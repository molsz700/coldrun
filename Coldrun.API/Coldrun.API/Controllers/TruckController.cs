using Coldrun.Commands.Trucks.CreateTruck;
using Coldrun.Commands.Trucks.DeleteTruck;
using Coldrun.Commands.Trucks.UpdateTruck;
using Coldrun.Database;
using Coldrun.Queries.Trucks.GetTruck;
using Coldrun.Queries.Trucks.GetTrucksFiltered;
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
        public async Task<ActionResult> CreateTruck([FromBody] CreateTruckCommand request)
        {
            var validator = new CreateTruckCommandValidator();
            var validationResult = validator.Validate(request);

            if (validationResult.IsValid)
            {
                await _mediator.Send(request);
            }
            else
            {
                return BadRequest(validationResult.Errors);
            }

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
        public async Task<IActionResult> GetTrucksFiltered([FromQuery] GetTrucksFilteredQuery request)
        {
            var result = await _mediator.Send(request);

            return Ok(result);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateTruck([FromBody] UpdateTruckCommand request)
        {
            var validator = new UpdateTruckCommandValidator();
            var validationResult = validator.Validate(request);

            if (validationResult.IsValid)
            {
                await _mediator.Send(request);
            }
            else
            {
                return BadRequest(validationResult.Errors);
            }

            return Ok();
        }

        [HttpDelete("{code}")]
        public async Task<IActionResult> DeleteTruck(string code)
        {
            var request = new DeleteTruckCommand()
            {
                Code = code
            };

            var validator = new DeleteTruckCommandValidator();
            var validationResult = validator.Validate(request);

            if (validationResult.IsValid)
            {
                await _mediator.Send(request);
            }
            else
            {
                return BadRequest(validationResult.Errors);
            }

            return Ok();
        }

    }
}
