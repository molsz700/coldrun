using Coldrun.Database;
using Coldrun.Database.Entities;
using MediatR;

namespace Coldrun.Commands.Trucks.UpdateTruck
{
    public class UpdateTruckCommandHandler : IRequestHandler<UpdateTruckCommand, Unit>
    {
        private readonly DatabaseContext _databaseContext;

        public UpdateTruckCommandHandler(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public Task<Unit> Handle(UpdateTruckCommand request, CancellationToken cancellationToken)
        {
            if(_databaseContext.Trucks.Find(request.Code) is Truck found)
            {
                var updatedTruck = new Truck()
                {
                    Code = found.Code,
                    Name = request.Name,
                    Description = request.Description,
                    Status = request.Status
                };

                _databaseContext.Entry(found).CurrentValues.SetValues(updatedTruck);
                _databaseContext.SaveChanges();
            }

            return Task.FromResult(Unit.Value);
        }
    }
}
