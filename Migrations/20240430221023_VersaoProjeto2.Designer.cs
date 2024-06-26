﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Gerenciamento_Clientes.Migrations
{
    [DbContext(typeof(BancodeDados))]
    [Migration("20240430221023_VersaoProjeto2")]
    partial class VersaoProjeto2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ChamadoManutencao", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DataAbertura")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataPrimeiroContato")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("DescricaoProblema")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("EmpreiteiroID")
                        .HasColumnType("int");

                    b.Property<int>("EquipeManutencaoID")
                        .HasColumnType("int");

                    b.Property<string>("MotivoNaoRealizacao")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("UnidadeResidencialID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("EmpreiteiroID");

                    b.HasIndex("EquipeManutencaoID");

                    b.ToTable("ChamadosManutencao");
                });

            modelBuilder.Entity("ClienteResidencial", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ImovelID")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ID");

                    b.HasIndex("ImovelID");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Empreiteiro", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ID");

                    b.ToTable("Empreiteiros");
                });

            modelBuilder.Entity("EquipeManutencao", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("EmpreiteiroID")
                        .HasColumnType("int");

                    b.Property<int>("LiderEquipeID")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ID");

                    b.HasIndex("EmpreiteiroID");

                    b.HasIndex("LiderEquipeID");

                    b.ToTable("EquipeManutencao");
                });

            modelBuilder.Entity("Imovel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ID");

                    b.ToTable("Condominios");
                });

            modelBuilder.Entity("LiderEquipe", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("EquipeID")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ID");

                    b.ToTable("LiderEquipe");
                });

            modelBuilder.Entity("Manutencoes", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Chamado")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataAbertura")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DataConclusao")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ID");

                    b.ToTable("Manutencoes");
                });

            modelBuilder.Entity("Obra", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("ID");

                    b.ToTable("Obras");
                });

            modelBuilder.Entity("ChamadoManutencao", b =>
                {
                    b.HasOne("Empreiteiro", null)
                        .WithMany("ManutencoesAtendidas")
                        .HasForeignKey("EmpreiteiroID");

                    b.HasOne("EquipeManutencao", "EquipeManutencao")
                        .WithMany("ManutencoesAtendidas")
                        .HasForeignKey("EquipeManutencaoID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EquipeManutencao");
                });

            modelBuilder.Entity("ClienteResidencial", b =>
                {
                    b.HasOne("Imovel", "Imovel")
                        .WithMany("ClientesResidenciais")
                        .HasForeignKey("ImovelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Imovel");
                });

            modelBuilder.Entity("EquipeManutencao", b =>
                {
                    b.HasOne("Empreiteiro", "Empreiteiro")
                        .WithMany("EquipesManutencao")
                        .HasForeignKey("EmpreiteiroID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LiderEquipe", "Lider")
                        .WithMany("EquipesManutencao")
                        .HasForeignKey("LiderEquipeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Empreiteiro");

                    b.Navigation("Lider");
                });

            modelBuilder.Entity("Empreiteiro", b =>
                {
                    b.Navigation("EquipesManutencao");

                    b.Navigation("ManutencoesAtendidas");
                });

            modelBuilder.Entity("EquipeManutencao", b =>
                {
                    b.Navigation("ManutencoesAtendidas");
                });

            modelBuilder.Entity("Imovel", b =>
                {
                    b.Navigation("ClientesResidenciais");
                });

            modelBuilder.Entity("LiderEquipe", b =>
                {
                    b.Navigation("EquipesManutencao");
                });
#pragma warning restore 612, 618
        }
    }
}
