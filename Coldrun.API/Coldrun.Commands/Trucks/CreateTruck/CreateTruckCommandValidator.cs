using Coldrun.Database;
using FluentValidation;

namespace Coldrun.Commands.Trucks.CreateTruck
{
    public sealed class CreateTruckCommandValidator : AbstractValidator<CreateTruckCommand>
    {
        private readonly DatabaseContext _databaseContext;

        public CreateTruckCommandValidator(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;

            RuleFor(x => x.Code).NotEmpty().Must(IsUniqueCode).WithMessage("Code must be unique!");
            RuleFor(x => x.Code).Must(IsAlphanumerical).WithMessage("Code must be alphanumerical!");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name must not be empty!");
        }

        private bool IsUniqueCode(string code)
        {
            return !_databaseContext.Trucks.Any(x => x.Code == code);
        }

        private bool IsAlphanumerical(string code)
        {
            return code.All(char.IsLetterOrDigit);
        }
    }
}
