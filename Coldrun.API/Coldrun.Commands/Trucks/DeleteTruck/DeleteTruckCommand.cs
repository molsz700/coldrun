using MediatR;

namespace Coldrun.Commands.Trucks.DeleteTruck
{
    public class DeleteTruckCommand : IRequest<Unit>
    {
        public string Code { get; set; }
    }
}
