﻿// <auto-generated />
using System;
using GestaoOcorrencias.Api;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GestaoOcorrencias.Api.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240923114643_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GestaoOcorrencias.Domain.Entities.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("ClienteId")
                        .HasColumnType("float");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("EnderecoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("GestaoOcorrencias.Domain.Entities.Endereco", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("CEP")
                        .HasColumnType("float");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UF")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("GestaoOcorrencias.Domain.Entities.Ocorrencia", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CodResponsavelAbertura")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Conclusao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataAbertura")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataOcorrencia")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ResponsavelAberturaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ResponsavelOcorrenciaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ResponsavelAberturaId");

                    b.HasIndex("ResponsavelOcorrenciaId");

                    b.ToTable("Ocorrencias");
                });

            modelBuilder.Entity("GestaoOcorrencias.Domain.Entities.Cliente", b =>
                {
                    b.HasOne("GestaoOcorrencias.Domain.Entities.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId");

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("GestaoOcorrencias.Domain.Entities.Ocorrencia", b =>
                {
                    b.HasOne("GestaoOcorrencias.Domain.Entities.Cliente", "ResponsavelAbertura")
                        .WithMany()
                        .HasForeignKey("ResponsavelAberturaId");

                    b.HasOne("GestaoOcorrencias.Domain.Entities.Cliente", "ResponsavelOcorrencia")
                        .WithMany()
                        .HasForeignKey("ResponsavelOcorrenciaId");

                    b.Navigation("ResponsavelAbertura");

                    b.Navigation("ResponsavelOcorrencia");
                });
#pragma warning restore 612, 618
        }
    }
}
