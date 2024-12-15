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

            modelBuilder.Entity("Abonnement", b =>
                {
                    b.Property<Guid>("AbonnementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AbonnementType")
                        .HasColumnType("int");

                    b.Property<decimal>("Kosten")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AbonnementId");

                    b.ToTable("Abonnementen");
                });

            modelBuilder.Entity("WPR_project.Models.Bedrijf", b =>
                {
                    b.Property<int>("BedrijfId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BedrijfId"));

                    b.Property<int>("KvkNummer")
                        .HasColumnType("int");

                    b.Property<string>("bedrijfsAdres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("bedrijfsNaam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BedrijfId");

                    b.ToTable("Bedrijven");
                });

            modelBuilder.Entity("WPR_project.Models.BedrijfsMedewerkers", b =>
                {
                    b.Property<Guid>("bedrijfsMedewerkerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AbonnementId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("WagenparkBeheerderbeheerderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("medewerkerEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("medewerkerNaam")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("wachtwoord")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("zakelijkeHuurderId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("bedrijfsMedewerkerId");

                    b.HasIndex("AbonnementId");

                    b.HasIndex("WagenparkBeheerderbeheerderId");

                    b.HasIndex("zakelijkeHuurderId");

                    b.ToTable("BedrijfsMedewerkers");
                });

            modelBuilder.Entity("WPR_project.Models.Huurverzoek", b =>
                {
                    b.Property<Guid>("HuurderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("approved")
                        .HasColumnType("bit");

                    b.Property<DateTime>("beginDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("endDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("voertuigId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("HuurderID");

                    b.ToTable("Huurverzoeken");
                });

            modelBuilder.Entity("WPR_project.Models.Medewerker", b =>
                {
                    b.Property<int>("medewerkerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("medewerkerId"));

                    b.Property<string>("medewerkerEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("medewerkerNaam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("medewerkerRol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("medewerkerId");

                    b.ToTable("Medewerkers", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("WPR_project.Models.ParticulierHuurder", b =>
                {
                    b.Property<Guid>("particulierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EmailBevestigingToken")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("IsEmailBevestigd")
                        .HasColumnType("bit");

                    b.Property<string>("adress")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("particulierEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("particulierNaam")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("postcode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("telefoonnummer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("wachtwoord")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("woonplaats")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("particulierId");

                    b.ToTable("ParticulierHuurders");
                });

            modelBuilder.Entity("WPR_project.Models.Voertuig", b =>
                {
                    b.Property<Guid>("voertuigId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("bouwjaar")
                        .HasColumnType("int");

                    b.Property<DateTime?>("eindDatum")
                        .HasColumnType("datetime2");

                    b.Property<string>("kenteken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("kleur")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("merk")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("prijsPerDag")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("startDatum")
                        .HasColumnType("datetime2");

                    b.Property<bool>("voertuigBeschikbaar")
                        .HasColumnType("bit");

                    b.Property<string>("voertuigType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("voertuigId");

                    b.ToTable("Voertuigen");
                });

            modelBuilder.Entity("WPR_project.Models.VoertuigStatus", b =>
                {
                    b.Property<Guid>("VoertuigStatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("onderhoud")
                        .HasColumnType("bit");

                    b.Property<bool>("schade")
                        .HasColumnType("bit");

                    b.Property<bool>("verhuurd")
                        .HasColumnType("bit");

                    b.Property<Guid>("voertuigId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("VoertuigStatusId");

                    b.HasIndex("voertuigId")
                        .IsUnique();

                    b.ToTable("VoertuigStatussen");
                });

            modelBuilder.Entity("WPR_project.Models.WagenparkBeheerder", b =>
                {
                    b.Property<Guid>("beheerderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AbonnementId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("AbonnementType")
                        .HasColumnType("int");

                    b.Property<string>("Adres")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("KVKNummer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("PrepaidSaldo")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("bedrijfsEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("beheerderNaam")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("telefoonNummer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("updateDatumAbonnement")
                        .HasColumnType("datetime2");

                    b.Property<string>("wachtwoord")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("beheerderId");

                    b.HasIndex("AbonnementId");

                    b.ToTable("WagenparkBeheerders");
                });

            modelBuilder.Entity("ZakelijkHuurder", b =>
                {
                    b.Property<Guid>("zakelijkeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EmailBevestigingToken")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<bool>("IsEmailBevestigd")
                        .HasColumnType("bit");

                    b.Property<int>("KVKNummer")
                        .HasColumnType("int");

                    b.Property<string>("adres")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("bedrijfsNaam")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("bedrijsEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("telNummer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("wachtwoord")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("zakelijkeId");

                    b.ToTable("ZakelijkHuurders");
                });

            modelBuilder.Entity("WPR_project.Models.BackofficeMedewerker", b =>
                {
                    b.HasBaseType("WPR_project.Models.Medewerker");

                    b.ToTable("BackofficeMedewerkers", (string)null);
                });

            modelBuilder.Entity("WPR_project.Models.FrontofficeMedewerker", b =>
                {
                    b.HasBaseType("WPR_project.Models.Medewerker");

                    b.ToTable("FrontofficeMedewerkers", (string)null);
                });

            modelBuilder.Entity("WPR_project.Models.BedrijfsMedewerkers", b =>
                {
                    b.HasOne("Abonnement", null)
                        .WithMany("Medewerkers")
                        .HasForeignKey("AbonnementId");

                    b.HasOne("WPR_project.Models.WagenparkBeheerder", null)
                        .WithMany("MedewerkerLijst")
                        .HasForeignKey("WagenparkBeheerderbeheerderId");

                    b.HasOne("ZakelijkHuurder", "ZakelijkeHuurder")
                        .WithMany("Medewerkers")
                        .HasForeignKey("zakelijkeHuurderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ZakelijkeHuurder");
                });

            modelBuilder.Entity("WPR_project.Models.VoertuigStatus", b =>
                {
                    b.HasOne("WPR_project.Models.Voertuig", null)
                        .WithOne("voertuigstatus")
                        .HasForeignKey("WPR_project.Models.VoertuigStatus", "voertuigId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WPR_project.Models.WagenparkBeheerder", b =>
                {
                    b.HasOne("Abonnement", "HuidigAbonnement")
                        .WithMany("WagenparkBeheerders")
                        .HasForeignKey("AbonnementId");

                    b.Navigation("HuidigAbonnement");
                });

            modelBuilder.Entity("WPR_project.Models.BackofficeMedewerker", b =>
                {
                    b.HasOne("WPR_project.Models.Medewerker", null)
                        .WithOne()
                        .HasForeignKey("WPR_project.Models.BackofficeMedewerker", "medewerkerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WPR_project.Models.FrontofficeMedewerker", b =>
                {
                    b.HasOne("WPR_project.Models.Medewerker", null)
                        .WithOne()
                        .HasForeignKey("WPR_project.Models.FrontofficeMedewerker", "medewerkerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Abonnement", b =>
                {
                    b.Navigation("Medewerkers");

                    b.Navigation("WagenparkBeheerders");
                });

            modelBuilder.Entity("WPR_project.Models.Voertuig", b =>
                {
                    b.Navigation("voertuigstatus")
                        .IsRequired();
                });

            modelBuilder.Entity("WPR_project.Models.WagenparkBeheerder", b =>
                {
                    b.Navigation("MedewerkerLijst");
                });

            modelBuilder.Entity("ZakelijkHuurder", b =>
                {
                    b.Navigation("Medewerkers");
                });
#pragma warning restore 612, 618
        }
    }
}
