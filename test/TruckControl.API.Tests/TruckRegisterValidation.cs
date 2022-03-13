using System;
using TruckControl.API.Application.Services.Validations;
using TruckControl.API.Utils.Exceptions;
using Xunit;

namespace TruckControl.API.Tests
{
    public class TruckRegisterValidation
    {
        [Fact]
        public void ValidateFabricationYear_CorrectYear_MustReturnTrue()
        {
            //Arrange
            var incorrectYear = DateTime.UtcNow.Year;

            //Act
            bool validation = new ValidateFabricationYear().IsValid(incorrectYear);

            //Assert
            Assert.Equal(validation, true);
        }
        [Fact]
        public void ValidateFabricationYear_IncorrectYear_MustReturnFalse()
        {
            //Arrange
            var incorrectYear = DateTime.UtcNow.Year - 1;

            //Act
            bool validation = new ValidateFabricationYear().IsValid(incorrectYear);

            //Assert
            Assert.Equal(validation, false);
        }
        public void TruckRegister_FabricationYearValidation_MustReturnException()
        {
        }
    }
}
