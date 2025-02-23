﻿// <auto-generated />
using System;
using Cooperchip.Demo.Data.Data.ORM;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Cooperchip.Demo.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Cooperchip.Demo.Domain.Entities.EstadoPaciente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(90)")
                        .HasColumnName("Descicao");

                    b.HasKey("Id");

                    b.ToTable("EstadoPaciente", (string)null);
                });

            modelBuilder.Entity("Cooperchip.Demo.Domain.Entities.Paciente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Cpf")
                        .HasMaxLength(11)
                        .HasColumnType("varchar(90)")
                        .HasColumnName("CPF")
                        .IsFixedLength();

                    b.Property<DateTime>("DataInternacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(90)")
                        .HasColumnName("Email");

                    b.Property<Guid>("EstadoPacienteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Motivo")
                        .HasMaxLength(90)
                        .HasColumnType("varchar(90)")
                        .HasColumnName("Motivo");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("varchar(90)")
                        .HasColumnName("Nome");

                    b.Property<string>("Rg")
                        .HasMaxLength(15)
                        .HasColumnType("varchar(90)");

                    b.Property<string>("RgDataEmissao")
                        .HasColumnType("varchar(90)");

                    b.Property<string>("RgOrgao")
                        .HasColumnType("varchar(90)")
                        .HasColumnName("RgOrgao");

                    b.Property<int>("Sexo")
                        .HasColumnType("int");

                    b.Property<int>("TipoPaciente")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EstadoPacienteId");

                    b.ToTable("Paciente", (string)null);
                });

            modelBuilder.Entity("Cooperchip.Demo.Domain.Entities.Paciente", b =>
                {
                    b.HasOne("Cooperchip.Demo.Domain.Entities.EstadoPaciente", "EstadoPaciente")
                        .WithMany("Pacientes")
                        .HasForeignKey("EstadoPacienteId")
                        .IsRequired();

                    b.Navigation("EstadoPaciente");
                });

            modelBuilder.Entity("Cooperchip.Demo.Domain.Entities.EstadoPaciente", b =>
                {
                    b.Navigation("Pacientes");
                });
#pragma warning restore 612, 618
        }
    }
}
