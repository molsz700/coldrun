using Coldrun.Database.Enums;
using MediatR;

namespace Coldrun.Commands.Trucks.CreateTruck
{
    public class CreateTruckCommand : IRequest<Unit>
    {
        public string Code { get; set; }
        public string Name { get; set; } 
        public string? Description { get; set; }
    }
}
