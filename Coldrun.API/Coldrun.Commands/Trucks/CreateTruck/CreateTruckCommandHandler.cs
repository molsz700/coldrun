using Coldrun.Database;
using Coldrun.Database.Entities;
using Coldrun.Database.Enums;
using MediatR;

namespace Coldrun.Commands.Trucks.CreateTruck
{
    public class CreateTruckCommandHandler : IRequestHandler<CreateTruckCommand, Unit>
    {
        private readonly DatabaseContext _databaseContext;

        public CreateTruckCommandHandler(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public Task<Unit> Handle(CreateTruckCommand request, CancellationToken cancellationToken)
        {
            var truck = new Truck()
            {
                Code = request.Code,
                Name = request.Name,
                Status = TruckStatus.OutOfService,
                Description = request.Description,
            };

            _databaseContext.Trucks.Add(truck);
            _databaseContext.SaveChanges();

            return Task.FromResult(Unit.Value);
        }
    }
}
