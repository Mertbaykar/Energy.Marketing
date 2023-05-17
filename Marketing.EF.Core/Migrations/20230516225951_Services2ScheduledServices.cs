using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Marketing.EF.Core.Migrations
{
    public partial class Services2ScheduledServices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Services",
                table: "Services");

            migrationBuilder.RenameTable(
                name: "Services",
                newName: "ScheduledServices");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScheduledServices",
                table: "ScheduledServices",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ScheduledServices",
                table: "ScheduledServices");

            migrationBuilder.RenameTable(
                name: "ScheduledServices",
                newName: "Services");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Services",
                table: "Services",
                column: "Id");
        }
    }
}
