using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fase1.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddCadastradoEm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CadastradoEm",
                table: "Regiao",
                type: "DATETIME",
                nullable: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CadastradoEm",
                table: "Contato",
                type: "DATETIME",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CadastradoEm",
                table: "Regiao");

            migrationBuilder.DropColumn(
                name: "CadastradoEm",
                table: "Contato");
        }
    }
}
