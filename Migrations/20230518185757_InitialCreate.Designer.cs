﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MonNameSpaceGestionCourrier.Data;

#nullable disable

namespace Gestion_courrier_ANDRIANANTENAINA.Migrations
{
    [DbContext(typeof(GestionCourrierDbContext))]
    [Migration("20230518185757_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MonNameSpaceGestionCourrier.Data.Courrier", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateArrivee")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModification")
                        .HasColumnType("datetime2");

                    b.Property<string>("Destinataire")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Expediteur")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Objet")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Urgent_O_N")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Courriers");
                });

            modelBuilder.Entity("MonNameSpaceGestionCourrier.Data.MouvementCourrier", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Acteur")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CourrierId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateMouvement")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nom_depositaire")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Statut")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MouvementsCourriers");
                });
#pragma warning restore 612, 618
        }
    }
}