﻿// <auto-generated />
using System;
using Empleados.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Empleados.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240119215730_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Empleados.Models.Empleado", b =>
                {
                    b.Property<int>("Empleado_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Empleado_Id"), 1L, 1);

                    b.Property<string>("Apellido_Materno")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Apellido_Paterno")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("Estatus_Id")
                        .HasColumnType("int");

                    b.Property<DateTime>("Fecha_Nacimiento")
                        .HasColumnType("Date");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Empleado_Id");

                    b.HasIndex("Estatus_Id");

                    b.ToTable("Empleados");
                });

            modelBuilder.Entity("Empleados.Models.Estatus", b =>
                {
                    b.Property<int>("Estatus_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Estatus_Id"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Estatus_Id");

                    b.ToTable("Estatus");

                    b.HasData(
                        new
                        {
                            Estatus_Id = 1,
                            Descripcion = "Activo"
                        },
                        new
                        {
                            Estatus_Id = 2,
                            Descripcion = "No Activo"
                        });
                });

            modelBuilder.Entity("Empleados.Models.Empleado", b =>
                {
                    b.HasOne("Empleados.Models.Estatus", "Estatus")
                        .WithMany()
                        .HasForeignKey("Estatus_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estatus");
                });
#pragma warning restore 612, 618
        }
    }
}
