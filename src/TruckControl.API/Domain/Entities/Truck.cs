using TruckControl.API.Domain.Entities.Enums;

namespace TruckControl.API.Domain.Entities
{
    public class Truck
    {
        public Truck()
        {
        }
        public int Id { get; set; }
        public string Details { get; set; }
        public TruckModel TruckModel { get; set; }
        public int FabricationYear { get; set; }
        public int ModelYear { get; set; }

        public void Update(string details, TruckModel truckModel, int fabricationYear, int modelYear)
        {
            Details = details ?? string.Empty;
            TruckModel = truckModel;
            FabricationYear = fabricationYear;
            ModelYear = modelYear;
        }


    }
}