using Coldrun.Commands.Trucks.CreateTruck;
using Coldrun.Commands.Trucks.DeleteTruck;
using Coldrun.Commands.Trucks.UpdateTruck;
using FluentValidation.TestHelper;
using Xunit;

namespace Coldrun.UnitTests.Truck
{
    public class ValidatorsTests
    {
        private readonly CreateTruckCommandValidator _createTruckCommandValidator;
        private readonly UpdateTruckCommandValidator _updateTruckCommandValidator;
        private readonly DeleteTruckCommandValidator _deleteTruckCommandValidator;


        public ValidatorsTests()
        {
            _createTruckCommandValidator = new CreateTruckCommandValidator();
            _updateTruckCommandValidator = new UpdateTruckCommandValidator();
            _deleteTruckCommandValidator = new DeleteTruckCommandValidator();
        }

        [Fact]
        public void CreateTruck_CodeWithSpecialCharacters_ShouldFail()
        {
            //Arrange
            var command = new CreateTruckCommand()
            {
                Code = "code!!",
                Name = "test",
                Description = "test",
            };

            //Act
            var validationResult = _createTruckCommandValidator.TestValidate(command);

            //Assert
            validationResult.ShouldHaveValidationErrorFor(x => x.Code).Only();
            validationResult.ShouldNotHaveValidationErrorFor(x => x.Name);
            validationResult.ShouldNotHaveValidationErrorFor(x => x.Description);
        }

        [Fact]
        public void CreateTruck_ValidModel_ShouldSuccess()
        {
            //Arrange
            var command = new CreateTruckCommand()
            {
                Code = "code",
                Name = "test",
                Description = "test",
            };

            //Act
            var validationResult = _createTruckCommandValidator.TestValidate(command);

            //Assert
            validationResult.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void CreateTruck_EmptyName_ShouldFail()
        {
            //Arrange
            var command = new CreateTruckCommand()
            {
                Code = "code",
                Name = "",
                Description = "test",
            };

            //Act
            var validationResult = _createTruckCommandValidator.TestValidate(command);

            //Assert
            validationResult.ShouldNotHaveValidationErrorFor(x => x.Code);
            validationResult.ShouldHaveValidationErrorFor(x => x.Name).Only();
            validationResult.ShouldNotHaveValidationErrorFor(x => x.Description);
        }

        [Fact]
        public void DeleteTruck_Exists_ShouldSuccess()
        {
            //Arrange
            var command = new DeleteTruckCommand()
            {
                Code = "code1",
            };

            //Act
            var validationResult = _deleteTruckCommandValidator.TestValidate(command);

            //Assert
            validationResult.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void DeleteTruck_NotExists_ShouldFail()
        {
            //Arrange
            var command = new DeleteTruckCommand()
            {
                Code = "code1!",
            };

            //Act
            var validationResult = _deleteTruckCommandValidator.TestValidate(command);

            //Assert
            validationResult.ShouldHaveValidationErrorFor(x => x.Code);
        }

        [Fact]
        public void UpdateTruck_NotExists_ShouldFail()
        {
            //Arrange
            var command = new UpdateTruckCommand()
            {
                Code = "code1!",
                Name = "test",
                Status = Database.Enums.TruckStatus.OutOfService,
                Description = "test",
            };

            //Act
            var validationResult = _updateTruckCommandValidator.TestValidate(command);

            //Assser
            validationResult.ShouldHaveValidationErrorFor(x => x.Code).Only();
            validationResult.ShouldNotHaveValidationErrorFor(x => x.Name);
            validationResult.ShouldNotHaveValidationErrorFor(x => x.Status);
            validationResult.ShouldNotHaveValidationErrorFor(x => x.Description);
        }

        [Fact]
        public void UpdateTruck_Exists_ShouldSuccess()
        {
            //Arrange
            var command = new UpdateTruckCommand()
            {
                Code = "code1",
                Name = "test",
                Status = Database.Enums.TruckStatus.OutOfService,
                Description = "test",
            };

            //Act
            var validationResult = _updateTruckCommandValidator.TestValidate(command);

            //Assser
            validationResult.ShouldNotHaveAnyValidationErrors();
        }
    }
}
