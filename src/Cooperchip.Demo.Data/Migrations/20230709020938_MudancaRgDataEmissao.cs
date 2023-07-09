using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cooperchip.Demo.Data.Migrations
{
    /// <inheritdoc />
    public partial class MudancaRgDataEmissao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EgDataEmissao",
                table: "Paciente",
                newName: "RgDataEmissao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RgDataEmissao",
                table: "Paciente",
                newName: "EgDataEmissao");
        }
    }
}
