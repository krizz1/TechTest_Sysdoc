using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestApi.Data.Models;

namespace TestApi.Data
{
    public class ProjectActionConfiguration : IEntityTypeConfiguration<ProjectAction>
    {
        public void Configure(EntityTypeBuilder<ProjectAction> builder)
        {
            builder
               .HasKey(k => new { k.ProjectId, k.ActionId});

            builder
                .HasOne(p => p.Project)
                .WithMany(b => b.ProjectActions)
                .HasForeignKey(s => s.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(p => p.Action)
                .WithMany(b => b.ProjectActions)
                .HasForeignKey(s => s.ActionId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
