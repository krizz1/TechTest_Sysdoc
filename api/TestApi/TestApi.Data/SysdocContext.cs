using Microsoft.EntityFrameworkCore;
using TestApi.Data.Models;

namespace TestApi.Data
{
    public class SysdocContext: DbContext
    {
        public SysdocContext(DbContextOptions<SysdocContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProjectActionConfiguration());

            SeedDb.Seed(modelBuilder);
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Action> Actions { get; set; }
    }
}
