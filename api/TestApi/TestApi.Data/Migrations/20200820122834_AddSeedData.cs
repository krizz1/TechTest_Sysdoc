using Microsoft.EntityFrameworkCore.Migrations;

namespace TestApi.Data.Migrations
{
    public partial class AddSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Actions",
                columns: new[] { "Id", "Description", "Name", "ProgressStatus", "RagStatus" },
                values: new object[,]
                {
                    { 1, "New set of documentation has been packed and need to be delivered", "Deliver packages", 2, 2 },
                    { 2, "Train team for the newly defined process of delivering a project", "Implement new process", 1, 1 },
                    { 3, "Acquire new equipment in the office to further help employees with their work", "Get new equipment", 0, 0 },
                    { 4, "Go over old equipment to see what equipment is out of order", "Re-assess old equipment", 0, 0 }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Description", "Name", "ProgressStatus" },
                values: new object[,]
                {
                    { 1, "", "Unify", 1 },
                    { 2, "", "ERP", 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Actions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Actions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Actions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Actions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
