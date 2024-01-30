using Coldrun.Database;
using FluentValidation;

namespace Coldrun.Commands.Trucks.DeleteTruck
{
    public class DeleteTruckCommandValidator : AbstractValidator<DeleteTruckCommand>
    {
        private readonly DatabaseContext _databaseContext;

        public DeleteTruckCommandValidator(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;

            RuleFor(x => x.Code).NotEmpty().Must(Exists).WithMessage("Code not found!");
        }

        private bool Exists(string code)
        {
            return _databaseContext.Trucks.Any(x => x.Code == code);
        }
    }
}
