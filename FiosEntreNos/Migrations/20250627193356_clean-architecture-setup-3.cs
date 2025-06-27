using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FiosEntreNos.Migrations
{
    /// <inheritdoc />
    public partial class cleanarchitecturesetup3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Weidth",
                table: "product",
                newName: "Width");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Width",
                table: "product",
                newName: "Weidth");
        }
    }
}
