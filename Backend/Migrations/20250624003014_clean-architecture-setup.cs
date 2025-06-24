using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class cleanarchitecturesetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Preco",
                table: "produto",
                newName: "Width");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "produto",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Largura",
                table: "produto",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "DataInclusao",
                table: "produto",
                newName: "DateIncluded");

            migrationBuilder.RenameColumn(
                name: "DataAlteracao",
                table: "produto",
                newName: "DateChange");

            migrationBuilder.RenameColumn(
                name: "Ativo",
                table: "produto",
                newName: "Active");

            migrationBuilder.RenameColumn(
                name: "Altura",
                table: "produto",
                newName: "Height");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Width",
                table: "produto",
                newName: "Preco");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "produto",
                newName: "Largura");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "produto",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "Height",
                table: "produto",
                newName: "Altura");

            migrationBuilder.RenameColumn(
                name: "DateIncluded",
                table: "produto",
                newName: "DataInclusao");

            migrationBuilder.RenameColumn(
                name: "DateChange",
                table: "produto",
                newName: "DataAlteracao");

            migrationBuilder.RenameColumn(
                name: "Active",
                table: "produto",
                newName: "Ativo");
        }
    }
}
