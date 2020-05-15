using System.Reflection;
using DanfossHomeTrackingService.Domain;
using Microsoft.EntityFrameworkCore;

namespace DanfossHomeTrackingService.Persistance.Ef
{
    public class DanfossDbContext : DbContext
    {
        public DanfossDbContext(DbContextOptions<DanfossDbContext> options)
            : base(options)
        {

        }

        public DbSet<Home> Homes { get; set; }
        public DbSet<Sensor> Sensors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}