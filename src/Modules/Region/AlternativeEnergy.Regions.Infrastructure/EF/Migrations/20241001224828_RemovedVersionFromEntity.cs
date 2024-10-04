using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlternativeEnergy.Regions.Infrastructure.EF.Migrations
{
    /// <inheritdoc />
    public partial class RemovedVersionFromEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Version",
                schema: "regions",
                table: "Regions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Version",
                schema: "regions",
                table: "Regions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
