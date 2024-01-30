using Coldrun.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Coldrun.Commands.Trucks.DeleteTruck
{
    public class DeleteTruckCommandHandler : IRequestHandler<DeleteTruckCommand, Unit>
    {
        private readonly DatabaseContext _databaseContext;

        public DeleteTruckCommandHandler(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public Task<Unit> Handle(DeleteTruckCommand request, CancellationToken cancellationToken)
        {
            _databaseContext.Trucks.Where(x => x.Code == request.Code).ExecuteDelete();

            return Task.FromResult(Unit.Value);
        }
    }
}
