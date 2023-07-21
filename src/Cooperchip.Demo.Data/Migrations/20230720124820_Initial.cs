using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cooperchip.Demo.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EstadoPaciente",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descicao = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoPaciente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EstadoPacienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataInternacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    CPF = table.Column<string>(type: "varchar(11)", fixedLength: true, maxLength: 11, nullable: true),
                    TipoPaciente = table.Column<int>(type: "int", nullable: false),
                    Sexo = table.Column<int>(type: "int", nullable: false),
                    Rg = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    RgOrgao = table.Column<string>(type: "varchar(90)", nullable: true),
                    RgDataEmissao = table.Column<string>(type: "varchar(90)", nullable: true),
                    Motivo = table.Column<string>(type: "varchar(90)", maxLength: 90, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Paciente_EstadoPaciente_EstadoPacienteId",
                        column: x => x.EstadoPacienteId,
                        principalTable: "EstadoPaciente",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_EstadoPacienteId",
                table: "Paciente",
                column: "EstadoPacienteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Paciente");

            migrationBuilder.DropTable(
                name: "EstadoPaciente");
        }
    }
}
