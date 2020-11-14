using Microsoft.EntityFrameworkCore;
using TestApi.Data.Models;

namespace TestApi.Data.Seed
{
    public static class SeedProjects
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().HasData(
                NewProject(1, "Unify", ProgressStatus.ACTIVE),
                NewProject(2, "ERP", ProgressStatus.ACTIVE)
                );
        }

        private static Project NewProject(int id, string name, ProgressStatus progressStatus) =>
            new Project()
            {
                Id = id,
                Name = name,
                Description = string.Empty,
                ProgressStatus = progressStatus
            };
    }
}
