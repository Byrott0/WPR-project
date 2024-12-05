﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WPR_project.Data;

#nullable disable

namespace WPR_project.Migrations
{
    [DbContext(typeof(GegevensContext))]
    partial class GegevensContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WPR_project.Models.Abonnement", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("abonnementNaam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("beginDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("endDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("price")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("term")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Abonnementen");
                });

            modelBuilder.Entity("WPR_project.Models.Huurverzoek", b =>
                {
                    b.Property<string>("HuurderID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("approved")
                        .HasColumnType("bit");

                    b.Property<DateTime>("beginDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("endDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("voertuigId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HuurderID");

                    b.ToTable("Huurverzoeken", (string)null);
                });

            modelBuilder.Entity("WPR_project.Models.Medewerker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("Medewerkers");
                });

            modelBuilder.Entity("WPR_project.Models.ParticulierHuurder", b =>
                {
                    b.Property<int>("gebruikerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("gebruikerId"));

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("naam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("phoneNumber")
                        .HasColumnType("int");

                    b.HasKey("gebruikerId");

                    b.ToTable("ParticulierHuurders", (string)null);
                });

            modelBuilder.Entity("WPR_project.Models.Voertuig", b =>
                {
                    b.Property<int>("voertuigId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("voertuigId"));

                    b.Property<string>("merk")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("prijsPerDag")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("voertuigType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("voertuigId");

                    b.ToTable("Voertuigen", (string)null);
                });

            modelBuilder.Entity("WPR_project.Models.WagenparkBeheerder", b =>
                {
                    b.Property<int>("beheerderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("beheerderId"));

                    b.Property<string>("beheerderNaam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("phoneNumber")
                        .HasColumnType("int");

                    b.HasKey("beheerderId");

                    b.ToTable("WagenParkBeheerders", (string)null);
                });

            modelBuilder.Entity("WPR_project.Models.ZakelijkHuurder", b =>
                {
                    b.Property<int>("zakelijkeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("zakelijkeId"));

                    b.Property<string>("adres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("bedrijfsNaam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("telNummer")
                        .HasColumnType("int");

                    b.HasKey("zakelijkeId");

                    b.ToTable("ZakelijkHuurders", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
