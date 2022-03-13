using System;

namespace TruckControl.API.Application.Services.Validations
{
    public class ValidateFabricationYear
    {
        public ValidateFabricationYear()
        {
        }

        public bool IsValid(int fabricationYear)
        {
            var currentYear = DateTime.UtcNow.Year;
            if (fabricationYear == currentYear) return true;
            return false;
        }
    }
}