using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlternativeEnergy.Sources.Infrastructure.EF.Migrations
{
    /// <inheritdoc />
    public partial class RenamedRegionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserEnergyChoices_Region_RegionId",
                schema: "sources",
                table: "UserEnergyChoices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Region",
                schema: "sources",
                table: "Region");

            migrationBuilder.RenameTable(
                name: "Region",
                schema: "sources",
                newName: "Regions",
                newSchema: "sources");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Regions",
                schema: "sources",
                table: "Regions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserEnergyChoices_Regions_RegionId",
                schema: "sources",
                table: "UserEnergyChoices",
                column: "RegionId",
                principalSchema: "sources",
                principalTable: "Regions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserEnergyChoices_Regions_RegionId",
                schema: "sources",
                table: "UserEnergyChoices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Regions",
                schema: "sources",
                table: "Regions");

            migrationBuilder.RenameTable(
                name: "Regions",
                schema: "sources",
                newName: "Region",
                newSchema: "sources");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Region",
                schema: "sources",
                table: "Region",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserEnergyChoices_Region_RegionId",
                schema: "sources",
                table: "UserEnergyChoices",
                column: "RegionId",
                principalSchema: "sources",
                principalTable: "Region",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
