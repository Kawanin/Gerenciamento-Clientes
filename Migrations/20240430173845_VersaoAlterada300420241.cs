using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace Gerenciamento_Clientes.Migrations
{
    /// <inheritdoc />
    public partial class VersaoAlterada300420241 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChamadoManutencao_Empreiteiros_EmpreiteiroID",
                table: "ChamadoManutencao");

            migrationBuilder.DropForeignKey(
                name: "FK_ChamadoManutencao_EquipeManutencao_EquipeManutencaoID",
                table: "ChamadoManutencao");

            migrationBuilder.DropForeignKey(
                name: "FK_LiderEquipe_EquipeManutencao_EquipeID",
                table: "LiderEquipe");

            migrationBuilder.DropTable(
                name: "UnidadeResidencial");

            migrationBuilder.DropIndex(
                name: "IX_LiderEquipe_EquipeID",
                table: "LiderEquipe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChamadoManutencao",
                table: "ChamadoManutencao");

            migrationBuilder.DropColumn(
                name: "EmpreiteirosNecessarios",
                table: "ChamadoManutencao");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "ChamadoManutencao");

            migrationBuilder.RenameTable(
                name: "ChamadoManutencao",
                newName: "ChamadosManutencao");

            migrationBuilder.RenameColumn(
                name: "chamado",
                table: "Manutencoes",
                newName: "Chamado");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Manutencoes",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_ChamadoManutencao_EquipeManutencaoID",
                table: "ChamadosManutencao",
                newName: "IX_ChamadosManutencao_EquipeManutencaoID");

            migrationBuilder.RenameIndex(
                name: "IX_ChamadoManutencao_EmpreiteiroID",
                table: "ChamadosManutencao",
                newName: "IX_ChamadosManutencao_EmpreiteiroID");

            migrationBuilder.AddColumn<int>(
                name: "EmpreiteiroID",
                table: "EquipeManutencao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LiderEquipeID",
                table: "EquipeManutencao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "EquipeManutencaoID",
                table: "ChamadosManutencao",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChamadosManutencao",
                table: "ChamadosManutencao",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_EquipeManutencao_EmpreiteiroID",
                table: "EquipeManutencao",
                column: "EmpreiteiroID");

            migrationBuilder.CreateIndex(
                name: "IX_EquipeManutencao_LiderEquipeID",
                table: "EquipeManutencao",
                column: "LiderEquipeID");

            migrationBuilder.AddForeignKey(
                name: "FK_ChamadosManutencao_Empreiteiros_EmpreiteiroID",
                table: "ChamadosManutencao",
                column: "EmpreiteiroID",
                principalTable: "Empreiteiros",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ChamadosManutencao_EquipeManutencao_EquipeManutencaoID",
                table: "ChamadosManutencao",
                column: "EquipeManutencaoID",
                principalTable: "EquipeManutencao",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipeManutencao_Empreiteiros_EmpreiteiroID",
                table: "EquipeManutencao",
                column: "EmpreiteiroID",
                principalTable: "Empreiteiros",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EquipeManutencao_LiderEquipe_LiderEquipeID",
                table: "EquipeManutencao",
                column: "LiderEquipeID",
                principalTable: "LiderEquipe",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChamadosManutencao_Empreiteiros_EmpreiteiroID",
                table: "ChamadosManutencao");

            migrationBuilder.DropForeignKey(
                name: "FK_ChamadosManutencao_EquipeManutencao_EquipeManutencaoID",
                table: "ChamadosManutencao");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipeManutencao_Empreiteiros_EmpreiteiroID",
                table: "EquipeManutencao");

            migrationBuilder.DropForeignKey(
                name: "FK_EquipeManutencao_LiderEquipe_LiderEquipeID",
                table: "EquipeManutencao");

            migrationBuilder.DropIndex(
                name: "IX_EquipeManutencao_EmpreiteiroID",
                table: "EquipeManutencao");

            migrationBuilder.DropIndex(
                name: "IX_EquipeManutencao_LiderEquipeID",
                table: "EquipeManutencao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChamadosManutencao",
                table: "ChamadosManutencao");

            migrationBuilder.DropColumn(
                name: "EmpreiteiroID",
                table: "EquipeManutencao");

            migrationBuilder.DropColumn(
                name: "LiderEquipeID",
                table: "EquipeManutencao");

            migrationBuilder.RenameTable(
                name: "ChamadosManutencao",
                newName: "ChamadoManutencao");

            migrationBuilder.RenameColumn(
                name: "Chamado",
                table: "Manutencoes",
                newName: "chamado");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Manutencoes",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_ChamadosManutencao_EquipeManutencaoID",
                table: "ChamadoManutencao",
                newName: "IX_ChamadoManutencao_EquipeManutencaoID");

            migrationBuilder.RenameIndex(
                name: "IX_ChamadosManutencao_EmpreiteiroID",
                table: "ChamadoManutencao",
                newName: "IX_ChamadoManutencao_EmpreiteiroID");

            migrationBuilder.AlterColumn<int>(
                name: "EquipeManutencaoID",
                table: "ChamadoManutencao",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "EmpreiteirosNecessarios",
                table: "ChamadoManutencao",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "ChamadoManutencao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChamadoManutencao",
                table: "ChamadoManutencao",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "UnidadeResidencial",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    CondominioID = table.Column<int>(type: "int", nullable: false),
                    DataEntrega = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EdificioID = table.Column<int>(type: "int", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    ObraID = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadeResidencial", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UnidadeResidencial_Obras_ObraID",
                        column: x => x.ObraID,
                        principalTable: "Obras",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_LiderEquipe_EquipeID",
                table: "LiderEquipe",
                column: "EquipeID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UnidadeResidencial_ObraID",
                table: "UnidadeResidencial",
                column: "ObraID");

            migrationBuilder.AddForeignKey(
                name: "FK_ChamadoManutencao_Empreiteiros_EmpreiteiroID",
                table: "ChamadoManutencao",
                column: "EmpreiteiroID",
                principalTable: "Empreiteiros",
                principalColumn: "ID");

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
    }
}
