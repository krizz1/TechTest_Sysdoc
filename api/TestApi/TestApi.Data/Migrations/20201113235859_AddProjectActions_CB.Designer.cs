﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestApi.Data;

namespace TestApi.Data.Migrations
{
    [DbContext(typeof(SysdocContext))]
    [Migration("20201113235859_AddProjectActions_CB")]
    partial class AddProjectActions_CB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TestApi.Data.Models.Action", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProgressStatus")
                        .HasColumnType("int");

                    b.Property<int>("RagStatus")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Actions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "New set of documentation has been packed and need to be delivered",
                            Name = "Deliver packages",
                            ProgressStatus = 2,
                            RagStatus = 2
                        },
                        new
                        {
                            Id = 2,
                            Description = "Train team for the newly defined process of delivering a project",
                            Name = "Implement new process",
                            ProgressStatus = 1,
                            RagStatus = 1
                        },
                        new
                        {
                            Id = 3,
                            Description = "Acquire new equipment in the office to further help employees with their work",
                            Name = "Get new equipment",
                            ProgressStatus = 0,
                            RagStatus = 0
                        },
                        new
                        {
                            Id = 4,
                            Description = "Go over old equipment to see what equipment is out of order",
                            Name = "Re-assess old equipment",
                            ProgressStatus = 0,
                            RagStatus = 0
                        });
                });

            modelBuilder.Entity("TestApi.Data.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProgressStatus")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "",
                            Name = "Unify",
                            ProgressStatus = 1
                        },
                        new
                        {
                            Id = 2,
                            Description = "",
                            Name = "ERP",
                            ProgressStatus = 1
                        });
                });

            modelBuilder.Entity("TestApi.Data.Models.ProjectAction", b =>
                {
                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("ActionId")
                        .HasColumnType("int");

                    b.HasKey("ProjectId", "ActionId");

                    b.HasIndex("ActionId");

                    b.ToTable("ProjectAction");
                });

            modelBuilder.Entity("TestApi.Data.Models.ProjectAction", b =>
                {
                    b.HasOne("TestApi.Data.Models.Action", "Action")
                        .WithMany("ProjectActions")
                        .HasForeignKey("ActionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("TestApi.Data.Models.Project", "Project")
                        .WithMany("ProjectActions")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
