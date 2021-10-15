using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Projeto1.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Cidade",
                table: "Cidade");

            migrationBuilder.RenameTable(
                name: "Cidade",
                newName: "cidade");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "cidade",
                type: "varchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                table: "cidade",
                type: "varchar(60)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cidade",
                table: "cidade",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "cliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Data_Nascimento = table.Column<DateTime>(type: "Data_Nascimento", nullable: false, defaultValueSql: "getdate()"),
                    CidadeId = table.Column<int>(type: "int", nullable: false),
                    Cep = table.Column<string>(type: "varchar(10)", nullable: false),
                    Logradouro = table.Column<string>(type: "varchar(100)", nullable: true),
                    Bairro = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cliente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cliente_cidade_CidadeId",
                        column: x => x.CidadeId,
                        principalTable: "cidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cliente_CidadeId",
                table: "cliente",
                column: "CidadeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cliente");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cidade",
                table: "cidade");

            migrationBuilder.RenameTable(
                name: "cidade",
                newName: "Cidade");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Cidade",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)");

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                table: "Cidade",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(60)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cidade",
                table: "Cidade",
                column: "Id");
        }
    }
}
