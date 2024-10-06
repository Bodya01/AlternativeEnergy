using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlternativeEnergy.Regions.Infrastructure.EF.Migrations
{
    /// <inheritdoc />
    public partial class InitialRegionsMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "regions");

            migrationBuilder.CreateTable(
                name: "Regions",
                schema: "regions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Version = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Regions",
                schema: "regions");
        }
    }
}
