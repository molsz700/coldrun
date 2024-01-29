using Coldrun.Database;
using Coldrun.Database.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Coldrun.Queries.Trucks.GetTruck
{
    public class GetTruckQueryHandler : IRequestHandler<GetTruckQuery, Truck>
    {
        private readonly DatabaseContext _databaseContext;

        public GetTruckQueryHandler(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<Truck> Handle(GetTruckQuery request, CancellationToken token)
        {
            return await _databaseContext.Trucks.FirstOrDefaultAsync(x => x.Code == request.Code);
        }  
    }
}
