using Microsoft.EntityFrameworkCore;
using RutasBackend.Models;
using RutasBackend.Models.Bd;

namespace RutasBackend.Data
{
    public partial class BdContext : DbContext
    {
        public BdContext()
        {
        }

        public BdContext(DbContextOptions<BdContext> options) : base(options)
        {
        }

        partial void OnModelBuilding(ModelBuilder builder);

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            this.OnModelBuilding(builder);

           
        }

        public DbSet<OfficialEntity> OfficialEntities { get; set; }
        public DbSet<OfficialEntityUser> OfficialEntityUsers { get; set; }

        public DbSet<CitizenUser> CitizenUsers { get; set; }
        public DbSet<CompanionSegment> CompanionSegments { get; set; }
        public DbSet<Journey> Journeys { get; set; }
        public DbSet<PanicAlert> PanicAlerts { get; set; }
        public DbSet<ReportPin> ReportPins { get; set; }
        public DbSet<SafeHaven> SafeHavens { get; set; }


        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {  
            configurationBuilder.Conventions.Add(_ => new BlankTriggerAddingConvention());
        }
    }
}