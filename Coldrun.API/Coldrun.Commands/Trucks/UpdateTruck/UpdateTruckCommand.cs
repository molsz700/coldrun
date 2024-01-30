using Coldrun.Database.Enums;
using MediatR;

namespace Coldrun.Commands.Trucks.UpdateTruck
{
    public class UpdateTruckCommand : IRequest<Unit>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public TruckStatus TruckStatus { get; set; }
        public string? Description { get; set; }
    }
}
