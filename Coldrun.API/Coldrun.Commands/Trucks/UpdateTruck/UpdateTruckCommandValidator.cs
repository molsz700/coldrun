using Coldrun.Database;
using Coldrun.Database.Enums;
using FluentValidation;

namespace Coldrun.Commands.Trucks.UpdateTruck
{
    public class UpdateTruckCommandValidator : AbstractValidator<UpdateTruckCommand>
    {
        public UpdateTruckCommandValidator()
        {
            RuleFor(x => x.Code).Must(ExistsInDatabase).WithMessage("Code not found");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name must not be empty!");
            RuleFor(x => x.TruckStatus).Must((obj, status) => IsValidStatusUpdate(obj.Code, status)).WithMessage("Wrong status");
        }

        private bool ExistsInDatabase(string code)
        {
            using(var databaseContext = new DatabaseContext())
            {
                return databaseContext.Trucks.Any(x => x.Code == code);
            }            
        }

        private bool IsValidStatusUpdate(string code, TruckStatus newStatus)
        {
            var result = true;

            using(var databaseContext = new DatabaseContext())
            {
                var entity = databaseContext.Trucks.FirstOrDefault(x => x.Code == code);
                if (entity != null)
                {
                    if (!(entity.Status == TruckStatus.OutOfService || newStatus == TruckStatus.OutOfService))
                    {
                        switch (entity.Status)
                        {
                            case TruckStatus.Loading: if (newStatus != TruckStatus.ToJob) result = false; break;
                            case TruckStatus.ToJob: if (newStatus != TruckStatus.AtJob) result = false; break;
                            case TruckStatus.AtJob: if (newStatus != TruckStatus.Returning) result = false; break;
                            case TruckStatus.Returning: if (newStatus != TruckStatus.Loading) result = false; break;
                        }
                    }
                }
            }

            return result;
        }

    }
}

