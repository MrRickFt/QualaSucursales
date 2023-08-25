﻿// <auto-generated />
using System;
using BackEndSucursales.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BackEndSucursales.Migrations
{
    [DbContext(typeof(AplicationDbContext))]
    partial class AplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BackEndSucursales.Domain.Models.Moneda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CodigoMoneda")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("DescripcionMoneda")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Monedas_Quala");
                });

            modelBuilder.Entity("BackEndSucursales.Domain.Models.Sucursal", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Codigo"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("varchar(250)");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("date");

                    b.Property<string>("Identificacion")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int>("MonedaId")
                        .HasColumnType("int");

                    b.HasKey("Codigo");

                    b.HasIndex("MonedaId");

                    b.ToTable("Sucursal_Quala");
                });

            modelBuilder.Entity("BackEndSucursales.Domain.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios_Quala");
                });

            modelBuilder.Entity("BackEndSucursales.Domain.Models.Sucursal", b =>
                {
                    b.HasOne("BackEndSucursales.Domain.Models.Moneda", "Moneda")
                        .WithMany()
                        .HasForeignKey("MonedaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Moneda");
                });
#pragma warning restore 612, 618
        }
    }
}
