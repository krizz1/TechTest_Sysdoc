using System;
using Microsoft.EntityFrameworkCore;
using TestApi.Entities;
using TestApi.Entities.Enums;
using Action = TestApi.Entities.Action;

namespace TestApi
{
   public class AppDbContext : DbContext
    {
        
        public DbSet<Project> Projects { get; set; }
        public DbSet<Action> Actions { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            //Database.EnsureCreated();
            //Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
            {
                optionsBuilder.EnableSensitiveDataLogging();
            }   
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder _modelBuilder)
        {
            _modelBuilder.Entity<Project>()
                .HasData(
                    new Project()
                    {
                        Name = "Unify",
                        Id = 1,
                        Description = "", 
                        ProgressStatus = ProgressStatus.ACTIVE
                    },
                    new Project()
                    {
                        Name = "ERP",
                        Id = 2,
                        Description = "", 
                        ProgressStatus = ProgressStatus.ACTIVE
                    }
                );
            
            _modelBuilder.Entity<Action>()
                .HasData(
                    new Action()
                    {
                        Name = "Deliver packages",
                        Id = 1,
                        Description = "New set of documentation has been packed and need to be delivered", 
                        ProgressStatus = ProgressStatus.COMPLETED, 
                        RagStatus = RagStatus.GREEN
                    },
                    new Action()
                    {
                        Name = "Implement new process",
                        Id = 2,
                        Description = "Train team for the newly defined process of delivering a project", 
                        ProgressStatus = ProgressStatus.ACTIVE,
                        RagStatus = RagStatus.AMBER
                    },
                    new Action()
                    {
                        Name = "Get new equipment",
                        Id = 3,
                        Description = "Acquire new equipment in the office to further help employees with their work", 
                        ProgressStatus = ProgressStatus.NOT_STARTED,
                        RagStatus = RagStatus.RED
                    },
                    new Action()
                    {
                        Name = "Re-assess old equipment",
                        Id = 4,
                        Description = "Go over old equipment to see what equipment is out of order", 
                        ProgressStatus = ProgressStatus.NOT_STARTED, 
                        RagStatus = RagStatus.RED
                    }
                );
        }

    }
}