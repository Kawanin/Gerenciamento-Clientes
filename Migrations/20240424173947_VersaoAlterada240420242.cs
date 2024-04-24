using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace Gerenciamento_Clientes.Migrations
{
    /// <inheritdoc />
    public partial class VersaoAlterada240420242 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChamadoManutencao_Equipes_EquipeManutencaoID",
                table: "ChamadoManutencao");

            migrationBuilder.DropForeignKey(
                name: "FK_Lider_Equipes_EquipeID",
                table: "Lider");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lider",
                table: "Lider");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Equipes",
                table: "Equipes");

            migrationBuilder.RenameTable(
                name: "Lider",
                newName: "LiderEquipe");

            migrationBuilder.RenameTable(
                name: "Equipes",
                newName: "EquipeManutencao");

            migrationBuilder.RenameIndex(
                name: "IX_Lider_EquipeID",
                table: "LiderEquipe",
                newName: "IX_LiderEquipe_EquipeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LiderEquipe",
                table: "LiderEquipe",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EquipeManutencao",
                table: "EquipeManutencao",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "Manutencoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    chamado = table.Column<string>(type: "longtext", nullable: false),
                    DataAbertura = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataConclusao = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Status = table.Column<string>(type: "longtext", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manutencoes", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_ChamadoManutencao_EquipeManutencao_EquipeManutencaoID",
                table: "ChamadoManutencao",
                column: "EquipeManutencaoID",
                principalTable: "EquipeManutencao",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_LiderEquipe_EquipeManutencao_EquipeID",
                table: "LiderEquipe",
                column: "EquipeID",
                principalTable: "EquipeManutencao",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChamadoManutencao_EquipeManutencao_EquipeManutencaoID",
                table: "ChamadoManutencao");

            migrationBuilder.DropForeignKey(
                name: "FK_LiderEquipe_EquipeManutencao_EquipeID",
                table: "LiderEquipe");

            migrationBuilder.DropTable(
                name: "Manutencoes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LiderEquipe",
                table: "LiderEquipe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EquipeManutencao",
                table: "EquipeManutencao");

            migrationBuilder.RenameTable(
                name: "LiderEquipe",
                newName: "Lider");

            migrationBuilder.RenameTable(
                name: "EquipeManutencao",
                newName: "Equipes");

            migrationBuilder.RenameIndex(
                name: "IX_LiderEquipe_EquipeID",
                table: "Lider",
                newName: "IX_Lider_EquipeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lider",
                table: "Lider",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Equipes",
                table: "Equipes",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ChamadoManutencao_Equipes_EquipeManutencaoID",
                table: "ChamadoManutencao",
                column: "EquipeManutencaoID",
                principalTable: "Equipes",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Lider_Equipes_EquipeID",
                table: "Lider",
                column: "EquipeID",
                principalTable: "Equipes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
