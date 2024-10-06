using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlternativeEnergy.Identity.Infrastructure.EF.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRefreshTokenIdField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Token",
                schema: "identity",
                table: "RefreshTokens",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "identity",
                table: "RefreshTokens",
                newName: "Token");
        }
    }
}
