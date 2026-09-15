using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ATIP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ConfigureChild : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Children_DiscoveryDate",
                table: "Children",
                column: "DiscoveryDate");

            migrationBuilder.CreateIndex(
                name: "IX_Children_LastName",
                table: "Children",
                column: "LastName");

            migrationBuilder.CreateIndex(
                name: "IX_Children_Status",
                table: "Children",
                column: "Status");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Children_DiscoveryDate",
                table: "Children");

            migrationBuilder.DropIndex(
                name: "IX_Children_LastName",
                table: "Children");

            migrationBuilder.DropIndex(
                name: "IX_Children_Status",
                table: "Children");
        }
    }
}
