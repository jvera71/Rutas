using Microsoft.EntityFrameworkCore;
using RutasBackend.Models;

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

        public DbSet<RutasBackend.Models.Bd.OfficialEntity> OfficialEntities { get; set; }
        public DbSet<RutasBackend.Models.Bd.OfficialEntityUser> OfficialEntityUsers { get; set; }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {  
            configurationBuilder.Conventions.Add(_ => new BlankTriggerAddingConvention());
        }
    }
}