using System;

namespace TruckControl.API.Application.Services.Validations
{
    internal class ValidateModelYear
    {
        public ValidateModelYear()
        {
        }
        internal bool IsValid(int modelYear)
        {
            var currentYear = DateTime.UtcNow.Year;
            var nextYear = currentYear + 1;
            if (modelYear == currentYear || modelYear == nextYear) return true;
            return false;
        }



    }
}
