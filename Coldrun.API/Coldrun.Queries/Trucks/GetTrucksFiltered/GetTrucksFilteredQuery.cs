using Coldrun.Database.Entities;
using Coldrun.Database.Enums;
using MediatR;

namespace Coldrun.Queries.Trucks.GetTrucksFiltered
{
    public class GetTrucksFilteredQuery : IRequest<List<Truck>>
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public TruckStatus Status { get; set; }
        public string? Description { get; set; }
    }
}
