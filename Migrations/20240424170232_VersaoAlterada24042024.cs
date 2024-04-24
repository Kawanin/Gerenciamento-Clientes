using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace Gerenciamento_Clientes.Migrations
{
    /// <inheritdoc />
    public partial class VersaoAlterada24042024 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Edificios");

            migrationBuilder.RenameColumn(
                name: "NomeResponsavel",
                table: "Lider",
                newName: "Nome");

            migrationBuilder.AddColumn<string>(
                name: "Tipo",
                table: "Condominios",
                type: "longtext",
                nullable: false);

            migrationBuilder.AddColumn<int>(
                name: "ImovelID",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ChamadoManutencao",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UnidadeResidencialID = table.Column<int>(type: "int", nullable: false),
                    DescricaoProblema = table.Column<string>(type: "longtext", nullable: false),
                    DataAbertura = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DataPrimeiroContato = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    MotivoNaoRealizacao = table.Column<string>(type: "longtext", nullable: false),
                    EmpreiteirosNecessarios = table.Column<string>(type: "longtext", nullable: false),
                    EmpreiteiroID = table.Column<int>(type: "int", nullable: true),
                    EquipeManutencaoID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChamadoManutencao", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ChamadoManutencao_Empreiteiros_EmpreiteiroID",
                        column: x => x.EmpreiteiroID,
                        principalTable: "Empreiteiros",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ChamadoManutencao_Equipes_EquipeManutencaoID",
                        column: x => x.EquipeManutencaoID,
                        principalTable: "Equipes",
                        principalColumn: "ID");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UnidadeResidencial",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Tipo = table.Column<string>(type: "longtext", nullable: false),
                    Numero = table.Column<int>(type: "int", nullable: false),
                    ObraID = table.Column<int>(type: "int", nullable: false),
                    CondominioID = table.Column<int>(type: "int", nullable: false),
                    EdificioID = table.Column<int>(type: "int", nullable: false),
                    DataEntrega = table.Column<DateTime>(type: "datetime(6)", nullable: false)
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
                name: "IX_Lider_EquipeID",
                table: "Lider",
                column: "EquipeID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_ImovelID",
                table: "Clientes",
                column: "ImovelID");

            migrationBuilder.CreateIndex(
                name: "IX_ChamadoManutencao_EmpreiteiroID",
                table: "ChamadoManutencao",
                column: "EmpreiteiroID");

            migrationBuilder.CreateIndex(
                name: "IX_ChamadoManutencao_EquipeManutencaoID",
                table: "ChamadoManutencao",
                column: "EquipeManutencaoID");

            migrationBuilder.CreateIndex(
                name: "IX_UnidadeResidencial_ObraID",
                table: "UnidadeResidencial",
                column: "ObraID");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Condominios_ImovelID",
                table: "Clientes",
                column: "ImovelID",
                principalTable: "Condominios",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lider_Equipes_EquipeID",
                table: "Lider",
                column: "EquipeID",
                principalTable: "Equipes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Condominios_ImovelID",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Lider_Equipes_EquipeID",
                table: "Lider");

            migrationBuilder.DropTable(
                name: "ChamadoManutencao");

            migrationBuilder.DropTable(
                name: "UnidadeResidencial");

            migrationBuilder.DropIndex(
                name: "IX_Lider_EquipeID",
                table: "Lider");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_ImovelID",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Condominios");

            migrationBuilder.DropColumn(
                name: "ImovelID",
                table: "Clientes");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Lider",
                newName: "NomeResponsavel");

            migrationBuilder.CreateTable(
                name: "Edificios",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Endereco = table.Column<string>(type: "longtext", nullable: false),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edificios", x => x.ID);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }
    }
}
