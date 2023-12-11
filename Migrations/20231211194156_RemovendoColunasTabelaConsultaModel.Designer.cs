﻿// <auto-generated />
using System;
using FluxoMedicoTesteNeoApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FluxoMedicoTesteNeoApp.Migrations
{
    [DbContext(typeof(BancoContext))]
    [Migration("20231211194156_RemovendoColunasTabelaConsultaModel")]
    partial class RemovendoColunasTabelaConsultaModel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FluxoMedicoTesteNeoApp.Core.Models.MedicosPacientes", b =>
                {
                    b.Property<int>("MedicoId")
                        .HasColumnType("integer")
                        .HasColumnName("id_Medico");

                    b.Property<int>("PacienteId")
                        .HasColumnType("integer")
                        .HasColumnName("id_paciente");

                    b.HasKey("MedicoId", "PacienteId");

                    b.HasIndex("PacienteId");

                    b.ToTable("tb_medico_paciente", (string)null);
                });

            modelBuilder.Entity("FluxoMedicoTesteNeoApp.Core.Models.PacienteModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("DataCadastroPaciente")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("IdUsuarioPaciente")
                        .HasColumnType("integer");

                    b.Property<int>("Idade")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Perfil")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("IdUsuarioPaciente")
                        .IsUnique();

                    b.ToTable("Pacientes");
                });

            modelBuilder.Entity("FluxoMedicoTesteNeoApp.Core.Models.UsuarioModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("FluxoMedicoTesteNeoApp.Models.ConsultaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DataConsulta")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Diagnostico")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("MedicoId")
                        .HasColumnType("integer");

                    b.Property<int?>("PacienteId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("MedicoId");

                    b.HasIndex("PacienteId");

                    b.ToTable("ConsultasMedicas");
                });

            modelBuilder.Entity("FluxoMedicoTesteNeoApp.Models.MedicoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DataCadastroMedico")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Especialidade")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("IdUsuarioMedico")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Perfil")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("IdUsuarioMedico")
                        .IsUnique();

                    b.ToTable("Medicos");
                });

            modelBuilder.Entity("FluxoMedicoTesteNeoApp.Core.Models.MedicosPacientes", b =>
                {
                    b.HasOne("FluxoMedicoTesteNeoApp.Models.MedicoModel", "Medico")
                        .WithMany()
                        .HasForeignKey("MedicoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FluxoMedicoTesteNeoApp.Core.Models.PacienteModel", "Paciente")
                        .WithMany()
                        .HasForeignKey("PacienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medico");

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("FluxoMedicoTesteNeoApp.Core.Models.PacienteModel", b =>
                {
                    b.HasOne("FluxoMedicoTesteNeoApp.Core.Models.UsuarioModel", "UsuarioPaciente")
                        .WithOne("PacienteUsuario")
                        .HasForeignKey("FluxoMedicoTesteNeoApp.Core.Models.PacienteModel", "IdUsuarioPaciente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UsuarioPaciente");
                });

            modelBuilder.Entity("FluxoMedicoTesteNeoApp.Models.ConsultaModel", b =>
                {
                    b.HasOne("FluxoMedicoTesteNeoApp.Models.MedicoModel", "Medico")
                        .WithMany("Consultas")
                        .HasForeignKey("MedicoId");

                    b.HasOne("FluxoMedicoTesteNeoApp.Core.Models.PacienteModel", "Paciente")
                        .WithMany("Consultas")
                        .HasForeignKey("PacienteId");

                    b.Navigation("Medico");

                    b.Navigation("Paciente");
                });

            modelBuilder.Entity("FluxoMedicoTesteNeoApp.Models.MedicoModel", b =>
                {
                    b.HasOne("FluxoMedicoTesteNeoApp.Core.Models.UsuarioModel", "UsuarioMedico")
                        .WithOne("MedicoUsuario")
                        .HasForeignKey("FluxoMedicoTesteNeoApp.Models.MedicoModel", "IdUsuarioMedico")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UsuarioMedico");
                });

            modelBuilder.Entity("FluxoMedicoTesteNeoApp.Core.Models.PacienteModel", b =>
                {
                    b.Navigation("Consultas");
                });

            modelBuilder.Entity("FluxoMedicoTesteNeoApp.Core.Models.UsuarioModel", b =>
                {
                    b.Navigation("MedicoUsuario")
                        .IsRequired();

                    b.Navigation("PacienteUsuario")
                        .IsRequired();
                });

            modelBuilder.Entity("FluxoMedicoTesteNeoApp.Models.MedicoModel", b =>
                {
                    b.Navigation("Consultas");
                });
#pragma warning restore 612, 618
        }
    }
}
