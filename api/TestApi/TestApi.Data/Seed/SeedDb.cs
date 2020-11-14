using Microsoft.EntityFrameworkCore;
using TestApi.Data.Seed;

namespace TestApi.Data
{
    public static class SeedDb
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            SeedActons.Seed(modelBuilder);
            SeedProjects.Seed(modelBuilder);
        }
    }
}
