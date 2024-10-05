using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlternativeEnergy.Sources.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedRegionsToSourcesModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "sources");

            migrationBuilder.CreateTable(
                name: "Region",
                schema: "sources",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sources",
                schema: "sources",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EnergyType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CO2Emissions = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserEnergyChoices",
                schema: "sources",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Consumption = table.Column<float>(type: "real", nullable: false),
                    ConsumptionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserEnergyChoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserEnergyChoices_Region_RegionId",
                        column: x => x.RegionId,
                        principalSchema: "sources",
                        principalTable: "Region",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserEnergyChoices_Sources_SourceId",
                        column: x => x.SourceId,
                        principalSchema: "sources",
                        principalTable: "Sources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserEnergyChoices_RegionId",
                schema: "sources",
                table: "UserEnergyChoices",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserEnergyChoices_SourceId",
                schema: "sources",
                table: "UserEnergyChoices",
                column: "SourceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserEnergyChoices",
                schema: "sources");

            migrationBuilder.DropTable(
                name: "Region",
                schema: "sources");

            migrationBuilder.DropTable(
                name: "Sources",
                schema: "sources");
        }
    }
}
