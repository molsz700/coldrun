using Coldrun.Database;
using FluentValidation;

namespace Coldrun.Commands.Trucks.DeleteTruck
{
    public sealed class DeleteTruckCommandValidator : AbstractValidator<DeleteTruckCommand>
    {
        public DeleteTruckCommandValidator()
        {
            RuleFor(x => x.Code).NotEmpty().Must(Exists).WithMessage("Code not found!");
        }

        private bool Exists(string code)
        {
            using(var databaseContext = new DatabaseContext())
            {
                return databaseContext.Trucks.Any(x => x.Code == code);
            }
            
        }
    }
}
