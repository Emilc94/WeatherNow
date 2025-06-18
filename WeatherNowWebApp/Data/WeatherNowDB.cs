using Microsoft.EntityFrameworkCore;
using WeatherNowWebApp.Models;

namespace WeatherNowWebApp.Data
{
    public class WeatherNowDB : DbContext
    {
        public WeatherNowDB(DbContextOptions<WeatherNowDB> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Eventuell annen modellkonfigurasjon kan legges her
            base.OnModelCreating(modelBuilder);
        }

        // DbSets for entiteter
        public DbSet<User> Users { get; set; }
        public DbSet<Sensor> Sensors { get; set; }
        public DbSet<MEASUREMENT> Measurements { get; set; }
        public DbSet<UserData> UserData { get; set; }
        public DbSet<Location> Locations { get; set; }
    }
}
