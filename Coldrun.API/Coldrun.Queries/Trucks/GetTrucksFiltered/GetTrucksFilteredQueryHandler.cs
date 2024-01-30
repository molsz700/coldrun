using Coldrun.Database;
using Coldrun.Database.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Coldrun.Queries.Trucks.GetTrucksFiltered
{
    public class GetTrucksFilteredQueryHandler : IRequestHandler<GetTrucksFilteredQuery, List<Truck>>
    {
        private readonly DatabaseContext _databaseContext;

        public GetTrucksFilteredQueryHandler(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<List<Truck>> Handle(GetTrucksFilteredQuery request, CancellationToken token)
        {
            var result = await _databaseContext.Trucks
                .Where(x => x.Code.StartsWith(request.Code ?? "") && x.Name.StartsWith(request.Name ?? "") 
                        && x.Description.StartsWith(request.Description ?? "")).ToListAsync();

            if(request.Status != 0)
            {
                result = result.Where(x => x.Status == request.Status).ToList();
            }

            return result;
        }
    }
}
