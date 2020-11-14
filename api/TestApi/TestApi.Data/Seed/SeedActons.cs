using Microsoft.EntityFrameworkCore;
using TestApi.Data.Models;

namespace TestApi.Data.Seed
{
    public static class SeedActons
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Action>().HasData(
                NewAction(1, "Deliver packages", "New set of documentation has been packed and need to be delivered", ProgressStatus.COMPLETED, RagStatus.GREEN),
                NewAction(2, "Implement new process", "Train team for the newly defined process of delivering a project", ProgressStatus.ACTIVE, RagStatus.AMBER),
                NewAction(3, "Get new equipment", "Acquire new equipment in the office to further help employees with their work", ProgressStatus.NOT_STARTED, RagStatus.RED),
                NewAction(4, "Re-assess old equipment", "Go over old equipment to see what equipment is out of order", ProgressStatus.NOT_STARTED, RagStatus.RED)
                );
        }

        private static Action NewAction(int id, string name, string description, ProgressStatus progressStatus, RagStatus ragStatus) =>
            new Action()
            {
                Id = id,
                Name = name,
                Description = description,
                ProgressStatus = progressStatus,
                RagStatus = ragStatus
            };
    }
}
