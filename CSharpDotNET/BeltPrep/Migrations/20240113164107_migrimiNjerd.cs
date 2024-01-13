using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeltPrep.Migrations
{
    public partial class migrimiNjerd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AktivitetiId",
                table: "Events",
                newName: "EventId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "Events",
                newName: "AktivitetiId");
        }
    }
}
