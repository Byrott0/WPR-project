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

                    b.Property<int?>("AantalDagen")
                        .HasColumnType("int");

                    b.Property<int>("AbonnementTermijnen")
                        .HasColumnType("int");

                    b.Property<int>("AbonnementType")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<decimal>("Kosten")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("beginDatum")
                        .HasColumnType("datetime2")
                        .HasColumnName("begindatum");

                    b.Property<string>("details")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("directZichtbaar")
                        .HasColumnType("bit");

                    b.Property<decimal?>("korting")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("notitie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("status")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("updateDatum")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("vervaldatum")
                        .HasColumnType("datetime2")
                        .HasColumnName("vervaldatum");

                    b.Property<Guid>("zakelijkeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AbonnementId");

                    b.HasIndex("zakelijkeId");

                    b.ToTable("Abonnementen");
                });

            modelBuilder.Entity("ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Factuur", b =>
                {
                    b.Property<Guid>("FactuurId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AbonnementId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BeheerderId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("FactuurDatum")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("FactuurPDF")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("FactuurId");

                    b.ToTable("Facturen");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("WPR_project.Models.BackofficeMedewerker", b =>
                {
                    b.Property<Guid>("BackofficeMedewerkerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AspNetUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("EmailBevestigingToken")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsEmailBevestigd")
                        .HasColumnType("bit");

                    b.Property<string>("medewerkerEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("medewerkerNaam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("wachtwoord")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BackofficeMedewerkerId");

                    b.ToTable("BackofficeMedewerkers");
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

                    b.Property<string>("AspNetUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("EmailBevestigingToken")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsEmailBevestigd")
                        .HasColumnType("bit");

                    b.Property<Guid>("beheerderId")
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

                    b.Property<Guid>("zakelijkeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("bedrijfsMedewerkerId");

                    b.HasIndex("beheerderId");

                    b.HasIndex("zakelijkeId");

                    b.ToTable("BedrijfsMedewerkers");
                });

            modelBuilder.Entity("WPR_project.Models.FrontofficeMedewerker", b =>
                {
                    b.Property<Guid>("FrontofficeMedewerkerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AspNetUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("EmailBevestigingToken")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("FrontofficeMedewerkerId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsEmailBevestigd")
                        .HasColumnType("bit");

                    b.Property<string>("medewerkerEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("medewerkerNaam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("wachtwoord")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FrontofficeMedewerkerId");

                    b.HasIndex("FrontofficeMedewerkerId1");

                    b.ToTable("FrontofficeMedewerkers");
                });

            modelBuilder.Entity("WPR_project.Models.Huurverzoek", b =>
                {
                    b.Property<Guid>("HuurVerzoekId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("HuurderID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool?>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<string>("Reden")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("VoertuigId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("approved")
                        .HasColumnType("bit");

                    b.Property<DateTime>("beginDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("endDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("isBevestigd")
                        .HasColumnType("bit");

                    b.HasKey("HuurVerzoekId");

                    b.HasIndex("VoertuigId");

                    b.ToTable("Huurverzoeken");
                });

            modelBuilder.Entity("WPR_project.Models.ParticulierHuurder", b =>
                {
                    b.Property<Guid>("particulierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AspNetUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("EmailBevestigingToken")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

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

                    b.HasIndex("AspNetUserId");

                    b.ToTable("ParticulierHuurders");
                });

            modelBuilder.Entity("WPR_project.Models.PrivacyVerklaring", b =>
                {
                    b.Property<Guid>("VerklaringId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MedewerkerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdateDatum")
                        .HasColumnType("datetime2");

                    b.Property<string>("Verklaring")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VerklaringId");

                    b.ToTable("PrivacyVerklaringen");
                });

            modelBuilder.Entity("WPR_project.Models.Schademelding", b =>
                {
                    b.Property<Guid>("SchademeldingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Beschrijving")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Datum")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("IsAfgehandeld")
                        .HasColumnType("bit");

                    b.Property<int?>("Onderhoud")
                        .HasColumnType("int");

                    b.Property<string>("Opmerkingen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Reparatie")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("VoertuigId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("SchademeldingId");

                    b.HasIndex("VoertuigId");

                    b.ToTable("Schademeldingen");
                });

            modelBuilder.Entity("WPR_project.Models.Voertuig", b =>
                {
                    b.Property<Guid>("voertuigId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("AantalDeuren")
                        .HasColumnType("int");

                    b.Property<int?>("AantalSlaapplekken")
                        .HasColumnType("int");

                    b.Property<byte[]>("Afbeelding")
                        .HasColumnType("varbinary(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

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

                    b.Property<string>("notitie")
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

            modelBuilder.Entity("WPR_project.Models.VoertuigNotities", b =>
                {
                    b.Property<Guid>("NotitieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("NotitieDatum")
                        .HasColumnType("datetime2");

                    b.Property<string>("notitie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("voertuigId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("NotitieId");

                    b.ToTable("VoertuigNotities");
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

                    b.HasIndex("voertuigId");

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

                    b.Property<string>("AspNetUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("EmailBevestigingToken")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsEmailBevestigd")
                        .HasColumnType("bit");

                    b.Property<int>("KVKNummer")
                        .HasColumnType("int");

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

                    b.Property<int?>("voertuiglimiet")
                        .HasColumnType("int");

                    b.Property<string>("wachtwoord")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("zakelijkeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("beheerderId");

                    b.HasIndex("AbonnementId");

                    b.ToTable("WagenparkBeheerders");
                });

            modelBuilder.Entity("ZakelijkHuurder", b =>
                {
                    b.Property<Guid>("zakelijkeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AspNetUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("EmailBevestigingToken")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsEmailBevestigd")
                        .HasColumnType("bit");

                    b.Property<int>("KVKNummer")
                        .HasColumnType("int");

                    b.Property<string>("adres")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("bedrijfsEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("bedrijfsNaam")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("telNummer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("wachtwoord")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("zakelijkeId");

                    b.ToTable("ZakelijkHuurders");
                });

            modelBuilder.Entity("Abonnement", b =>
                {
                    b.HasOne("ZakelijkHuurder", "ZakelijkHuurder")
                        .WithMany()
                        .HasForeignKey("zakelijkeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ZakelijkHuurder");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WPR_project.Models.BedrijfsMedewerkers", b =>
                {
                    b.HasOne("WPR_project.Models.WagenparkBeheerder", "WagenparkBeheerder")
                        .WithMany()
                        .HasForeignKey("beheerderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ZakelijkHuurder", "ZakelijkeHuurder")
                        .WithMany("Medewerkers")
                        .HasForeignKey("zakelijkeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WagenparkBeheerder");

                    b.Navigation("ZakelijkeHuurder");
                });

            modelBuilder.Entity("WPR_project.Models.FrontofficeMedewerker", b =>
                {
                    b.HasOne("WPR_project.Models.FrontofficeMedewerker", null)
                        .WithMany("FrontofficeMedewerkers")
                        .HasForeignKey("FrontofficeMedewerkerId1");
                });

            modelBuilder.Entity("WPR_project.Models.Huurverzoek", b =>
                {
                    b.HasOne("WPR_project.Models.Voertuig", "Voertuig")
                        .WithMany()
                        .HasForeignKey("VoertuigId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Voertuig");
                });

            modelBuilder.Entity("WPR_project.Models.ParticulierHuurder", b =>
                {
                    b.HasOne("ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("AspNetUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WPR_project.Models.Schademelding", b =>
                {
                    b.HasOne("WPR_project.Models.Voertuig", "Voertuig")
                        .WithMany("Schademeldingen")
                        .HasForeignKey("VoertuigId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Voertuig");
                });

            modelBuilder.Entity("WPR_project.Models.VoertuigStatus", b =>
                {
                    b.HasOne("WPR_project.Models.Voertuig", "voertuig")
                        .WithMany()
                        .HasForeignKey("voertuigId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("voertuig");
                });

            modelBuilder.Entity("WPR_project.Models.WagenparkBeheerder", b =>
                {
                    b.HasOne("Abonnement", "HuidigAbonnement")
                        .WithMany()
                        .HasForeignKey("AbonnementId");

                    b.Navigation("HuidigAbonnement");
                });

            modelBuilder.Entity("WPR_project.Models.FrontofficeMedewerker", b =>
                {
                    b.Navigation("FrontofficeMedewerkers");
                });

            modelBuilder.Entity("WPR_project.Models.Voertuig", b =>
                {
                    b.Navigation("Schademeldingen");
                });

            modelBuilder.Entity("ZakelijkHuurder", b =>
                {
                    b.Navigation("Medewerkers");
                });
#pragma warning restore 612, 618
        }
    }
}
