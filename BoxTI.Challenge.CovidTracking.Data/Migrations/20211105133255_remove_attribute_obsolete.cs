using Microsoft.EntityFrameworkCore.Migrations;

namespace BoxTI.Challenge.CovidTracking.Data.Migrations
{
    public partial class remove_attribute_obsolete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Vaccinated",
                table: "Covid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Vaccinated",
                table: "Covid",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
