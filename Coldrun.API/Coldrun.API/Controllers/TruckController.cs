using Coldrun.Commands.Trucks.CreateTruck;
using Coldrun.Commands.Trucks.DeleteTruck;
using Coldrun.Commands.Trucks.UpdateTruck;
using Coldrun.Database;
using Coldrun.Database.Entities;
using Coldrun.Queries.Trucks.GetTruck;
using Coldrun.Queries.Trucks.GetTrucksFiltered;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Coldrun.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TruckController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly DatabaseContext _databaseContext;

        public TruckController(IMediator mediator, DatabaseContext databaseContext)
        {
            _mediator = mediator;
            _databaseContext = databaseContext;
        }

        [HttpPost]
        public async Task<ActionResult> CreateTruck([FromBody] CreateTruckCommand request)
        {
            var validator = new CreateTruckCommandValidator(_databaseContext);
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
            var validator = new UpdateTruckCommandValidator(_databaseContext);
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

            var validator = new DeleteTruckCommandValidator(_databaseContext);
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
