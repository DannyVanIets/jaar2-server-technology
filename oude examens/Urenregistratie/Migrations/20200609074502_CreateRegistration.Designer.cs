﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Urenregistratie.DAL;

namespace Urenregistratie.Migrations
{
    [DbContext(typeof(UrenContext))]
    [Migration("20200609074502_CreateRegistration")]
    partial class CreateRegistration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Urenregistratie.Models.MedewerkerModel", b =>
                {
                    b.Property<int>("MedewerkerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Achternaam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefoonnummer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Voornaam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MedewerkerId");

                    b.ToTable("Medewerker");
                });

            modelBuilder.Entity("Urenregistratie.Models.RegistratieModel", b =>
                {
                    b.Property<int>("RegistratieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Dinsdag")
                        .HasColumnType("int");

                    b.Property<int?>("Donderdag")
                        .HasColumnType("int");

                    b.Property<int>("Jaar")
                        .HasColumnType("int")
                        .HasMaxLength(9999);

                    b.Property<int?>("Maandag")
                        .HasColumnType("int");

                    b.Property<int>("MedewerkerId")
                        .HasColumnType("int");

                    b.Property<int?>("Vrijdag")
                        .HasColumnType("int");

                    b.Property<int>("Week")
                        .HasColumnType("int")
                        .HasMaxLength(53);

                    b.Property<int?>("Woensdag")
                        .HasColumnType("int");

                    b.Property<int?>("Zaterdag")
                        .HasColumnType("int");

                    b.Property<int?>("Zondag")
                        .HasColumnType("int");

                    b.HasKey("RegistratieId");

                    b.HasIndex("MedewerkerId");

                    b.ToTable("Registratie");
                });

            modelBuilder.Entity("Urenregistratie.Models.RegistratieModel", b =>
                {
                    b.HasOne("Urenregistratie.Models.MedewerkerModel", "Medewerker")
                        .WithMany("Registraties")
                        .HasForeignKey("MedewerkerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}