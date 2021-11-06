using Microsoft.EntityFrameworkCore.Migrations;

namespace BoxTI.Challenge.CovidTracking.Data.Migrations
{
    public partial class alter_name_table_updates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Covid_Countries_CountryId",
                table: "Covid");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Covid",
                table: "Covid");

            migrationBuilder.DropIndex(
                name: "IX_Covid_CountryId",
                table: "Covid");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Countries",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Covid");

            migrationBuilder.RenameTable(
                name: "Countries",
                newName: "Regions");

            migrationBuilder.AddColumn<int>(
                name: "RegionId",
                table: "Covid",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Covid",
                table: "Covid",
                columns: new[] { "Id", "RegionId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Regions",
                table: "Regions",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Covid_RegionId",
                table: "Covid",
                column: "RegionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Covid_Regions_RegionId",
                table: "Covid",
                column: "RegionId",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Covid_Regions_RegionId",
                table: "Covid");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Covid",
                table: "Covid");

            migrationBuilder.DropIndex(
                name: "IX_Covid_RegionId",
                table: "Covid");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Regions",
                table: "Regions");

            migrationBuilder.DropColumn(
                name: "RegionId",
                table: "Covid");

            migrationBuilder.RenameTable(
                name: "Regions",
                newName: "Countries");

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Covid",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Covid",
                table: "Covid",
                columns: new[] { "Id", "CountryId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Countries",
                table: "Countries",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Covid_CountryId",
                table: "Covid",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Covid_Countries_CountryId",
                table: "Covid",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
