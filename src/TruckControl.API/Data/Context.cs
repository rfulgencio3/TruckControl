using Microsoft.EntityFrameworkCore;
using TruckControl.API.Domain.Entities;

namespace TruckControl.API.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Truck> Trucks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Truck>(e => { e.HasKey(t => t.Id); });
        }
    }
}