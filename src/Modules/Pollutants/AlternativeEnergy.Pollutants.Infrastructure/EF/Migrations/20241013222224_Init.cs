using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlternativeEnergy.Pollutants.Infrastructure.EF.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "pollutants");

            migrationBuilder.CreateTable(
                name: "Regions",
                schema: "pollutants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transport",
                schema: "pollutants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FuelType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CarbonPerUnit = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transport", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarbonEmissions",
                schema: "pollutants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmissionsPerUnit = table.Column<float>(type: "real", nullable: false),
                    SourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarbonEmissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarbonEmissions_Regions_RegionId",
                        column: x => x.RegionId,
                        principalSchema: "pollutants",
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wastes",
                schema: "pollutants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Produced = table.Column<float>(type: "real", nullable: false),
                    WasteType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CollectionTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wastes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wastes_Regions_RegionId",
                        column: x => x.RegionId,
                        principalSchema: "pollutants",
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WaterEmissions",
                schema: "pollutants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Used = table.Column<float>(type: "real", nullable: false),
                    ConsumptionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaterEmissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WaterEmissions_Regions_RegionId",
                        column: x => x.RegionId,
                        principalSchema: "pollutants",
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransportEmissions",
                schema: "pollutants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConsumedFuel = table.Column<float>(type: "real", nullable: false),
                    Distance = table.Column<float>(type: "real", nullable: false),
                    UsageDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransportId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransportId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransportEmissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransportEmissions_Transport_TransportId",
                        column: x => x.TransportId,
                        principalSchema: "pollutants",
                        principalTable: "Transport",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TransportEmissions_Transport_TransportId1",
                        column: x => x.TransportId1,
                        principalSchema: "pollutants",
                        principalTable: "Transport",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarbonEmissions_RegionId",
                schema: "pollutants",
                table: "CarbonEmissions",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportEmissions_TransportId",
                schema: "pollutants",
                table: "TransportEmissions",
                column: "TransportId");

            migrationBuilder.CreateIndex(
                name: "IX_TransportEmissions_TransportId1",
                schema: "pollutants",
                table: "TransportEmissions",
                column: "TransportId1");

            migrationBuilder.CreateIndex(
                name: "IX_Wastes_RegionId",
                schema: "pollutants",
                table: "Wastes",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_WaterEmissions_RegionId",
                schema: "pollutants",
                table: "WaterEmissions",
                column: "RegionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarbonEmissions",
                schema: "pollutants");

            migrationBuilder.DropTable(
                name: "TransportEmissions",
                schema: "pollutants");

            migrationBuilder.DropTable(
                name: "Wastes",
                schema: "pollutants");

            migrationBuilder.DropTable(
                name: "WaterEmissions",
                schema: "pollutants");

            migrationBuilder.DropTable(
                name: "Transport",
                schema: "pollutants");

            migrationBuilder.DropTable(
                name: "Regions",
                schema: "pollutants");
        }
    }
}
