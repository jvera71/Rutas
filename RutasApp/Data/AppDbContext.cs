using Microsoft.EntityFrameworkCore;
using RutasApp.Models;

namespace RutasApp.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<EmergencyContact> EmergencyContacts { get; set; }
        public DbSet<LocalUserProfile> LocalUserProfiles { get; set; }
        public DbSet<AppConfiguration> AppConfigurations { get; set; }

        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                try
                {
                    // Typical SQLite connection string for MAUI apps
                    string dbPath = System.IO.Path.Combine(FileSystem.AppDataDirectory, "rutasapp.db");
                    optionsBuilder.UseSqlite($"Filename={dbPath}");
                }
                catch (Exception)
                {
                    // Fallback for design-time
                    optionsBuilder.UseSqlite("Data Source=rutasapp.db");
                }
            }
        }
    }
}
