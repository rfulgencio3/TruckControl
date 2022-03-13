using System.Collections.Generic;
using System.Linq;
using TruckControl.API.Domain.Entities;

namespace TruckControl.API.Data.Repositories
{
    public class TruckRegisterRepository : ITruckRegisterRepository
    {
        private readonly Context _context;
        public TruckRegisterRepository(Context context)
        {
            _context = context;
        }
        public void Add(Truck truck)
        {
            _context.Add(truck);
            _context.SaveChanges();
        }

        public void Delete(Truck truck)
        {
            _context.Remove(truck);
            _context.SaveChanges();
        }

        public List<Truck> GetAll()
        {
            return _context.Trucks.ToList();
        }

        public Truck GetById(int id)
        {
            return _context.Trucks.SingleOrDefault(t => t.Id == id);
        }

        public void Update(Truck truck)
        {
            _context.Trucks.Update(truck);
            _context.SaveChanges();
        }
    }
}
