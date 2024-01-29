using Coldrun.Database.Entities;
using MediatR;

namespace Coldrun.Queries.Trucks.GetTruck
{
    public class GetTruckQuery : IRequest<Truck>
    {
        public string Code { get; set; }
    }
}
