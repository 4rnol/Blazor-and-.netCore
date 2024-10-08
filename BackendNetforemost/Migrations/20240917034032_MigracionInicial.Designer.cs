﻿// <auto-generated />
using System;
using BackendNetforemost.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BackendNetforemost.Migrations
{
    [DbContext(typeof(ManejadorDeTareas))]
    [Migration("20240917034032_MigracionInicial")]
    partial class MigracionInicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entidad.Prioridad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Prioridades");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nombre = "Alta"
                        },
                        new
                        {
                            Id = 2,
                            Nombre = "Media"
                        },
                        new
                        {
                            Id = 3,
                            Nombre = "Baja"
                        });
                });

            modelBuilder.Entity("Entidad.Tarea", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Created_At")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Eliminado")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaVencimiento")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Finalizado")
                        .HasColumnType("bit");

                    b.Property<int>("PrioridadId")
                        .HasColumnType("int");

                    b.Property<string>("Tags")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Updated_At")
                        .HasColumnType("datetime2");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PrioridadId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Tareas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Created_At = new DateTime(2024, 9, 16, 23, 40, 32, 348, DateTimeKind.Local).AddTicks(7611),
                            Descripcion = "Descripcion de la tarea 1",
                            Eliminado = false,
                            FechaVencimiento = new DateTime(2024, 9, 16, 23, 40, 32, 348, DateTimeKind.Local).AddTicks(7610),
                            Finalizado = false,
                            PrioridadId = 1,
                            Tags = "tag1, tag2",
                            Titulo = "Tarea 1",
                            Updated_At = new DateTime(2024, 9, 16, 23, 40, 32, 348, DateTimeKind.Local).AddTicks(7611),
                            UsuarioId = 1
                        },
                        new
                        {
                            Id = 2,
                            Created_At = new DateTime(2024, 9, 16, 23, 40, 32, 348, DateTimeKind.Local).AddTicks(7614),
                            Descripcion = "Descripcion de la tarea 2",
                            Eliminado = false,
                            FechaVencimiento = new DateTime(2024, 9, 16, 23, 40, 32, 348, DateTimeKind.Local).AddTicks(7613),
                            Finalizado = false,
                            PrioridadId = 2,
                            Tags = "tag1, tag2",
                            Titulo = "Tarea 2",
                            Updated_At = new DateTime(2024, 9, 16, 23, 40, 32, 348, DateTimeKind.Local).AddTicks(7614),
                            UsuarioId = 1
                        },
                        new
                        {
                            Id = 3,
                            Created_At = new DateTime(2024, 9, 16, 23, 40, 32, 348, DateTimeKind.Local).AddTicks(7616),
                            Descripcion = "Descripcion de la tarea 3",
                            Eliminado = false,
                            FechaVencimiento = new DateTime(2024, 9, 16, 23, 40, 32, 348, DateTimeKind.Local).AddTicks(7615),
                            Finalizado = false,
                            PrioridadId = 3,
                            Tags = "tag1, tag2",
                            Titulo = "Tarea 3",
                            Updated_At = new DateTime(2024, 9, 16, 23, 40, 32, 348, DateTimeKind.Local).AddTicks(7616),
                            UsuarioId = 2
                        });
                });

            modelBuilder.Entity("Entidad.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created_At")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Updated_At")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Apellido = "Perez",
                            Correo = "juan@asd.asd",
                            Created_At = new DateTime(2024, 9, 16, 23, 40, 32, 348, DateTimeKind.Local).AddTicks(7505),
                            Nombre = "Juan",
                            Telefono = "123456789",
                            Updated_At = new DateTime(2024, 9, 16, 23, 40, 32, 348, DateTimeKind.Local).AddTicks(7513)
                        },
                        new
                        {
                            Id = 2,
                            Apellido = "Gomez",
                            Correo = "maria@asdas.asd",
                            Created_At = new DateTime(2024, 9, 16, 23, 40, 32, 348, DateTimeKind.Local).AddTicks(7514),
                            Nombre = "Maria",
                            Telefono = "987654321",
                            Updated_At = new DateTime(2024, 9, 16, 23, 40, 32, 348, DateTimeKind.Local).AddTicks(7515)
                        });
                });

            modelBuilder.Entity("Entidad.Tarea", b =>
                {
                    b.HasOne("Entidad.Prioridad", "Prioridad")
                        .WithMany("Tareas")
                        .HasForeignKey("PrioridadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entidad.Usuario", "Usuario")
                        .WithMany("Tareas")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Prioridad");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Entidad.Prioridad", b =>
                {
                    b.Navigation("Tareas");
                });

            modelBuilder.Entity("Entidad.Usuario", b =>
                {
                    b.Navigation("Tareas");
                });
#pragma warning restore 612, 618
        }
    }
}
