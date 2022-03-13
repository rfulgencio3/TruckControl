using System.Collections.Generic;
using TruckControl.API.Domain.Entities;

namespace TruckControl.API.Data.Repositories
{
    public interface ITruckRegisterRepository
    {
        List<Truck> GetAll();
        Truck GetById(int id);
        void Add(Truck truck);
        void Update(Truck truck);
        void Delete(Truck truck);
    }
}