﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyAxiaMarket.Data;

namespace MyAxiaMarket.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6");

            modelBuilder.Entity("MyAxiaMarket.Models.Article", b =>
                {
                    b.Property<int>("IdArticle")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("NomArticle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Reference")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("addedon")
                        .HasColumnType("datetime2");

                    b.Property<int>("categoryId")
                        .HasColumnType("int");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("lastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("modifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("panierId")
                        .HasColumnType("int");

                    b.Property<decimal>("price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("valide")
                        .HasColumnType("bit");

                    b.HasKey("IdArticle");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("MyAxiaMarket.Models.Boutique", b =>
                {
                    b.Property<int>("IdBoutique")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ManagerId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NatureBoutique")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomBoutique")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("addedon")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("lastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("modifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("valide")
                        .HasColumnType("bit");

                    b.HasKey("IdBoutique");

                    b.ToTable("Boutiques");
                });

            modelBuilder.Entity("MyAxiaMarket.Models.Categorie", b =>
                {
                    b.Property<int>("IdCategorie")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomCategorie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("addedon")
                        .HasColumnType("datetime2");

                    b.Property<int>("boutiqueId")
                        .HasColumnType("int");

                    b.Property<DateTime>("lastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("modifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("valide")
                        .HasColumnType("bit");

                    b.HasKey("IdCategorie");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("MyAxiaMarket1.Models.Commande", b =>
                {
                    b.Property<int>("CommandId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransporterId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("addedon")
                        .HasColumnType("datetime2");

                    b.Property<string>("clientId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("commandRefrence")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("lastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("modifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("panierId")
                        .HasColumnType("int");

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("valide")
                        .HasColumnType("bit");

                    b.HasKey("CommandId");

                    b.ToTable("Commandes");
                });

            modelBuilder.Entity("MyAxiaMarket1.Models.Contrat", b =>
                {
                    b.Property<int>("ContractId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("AdminId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContractNature")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("addedon")
                        .HasColumnType("datetime2");

                    b.Property<string>("clauses")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("effectiveDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("fournisseurId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("lastModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("modifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("startDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("valide")
                        .HasColumnType("bit");

                    b.HasKey("ContractId");

                    b.ToTable("Contrats");
                });

            modelBuilder.Entity("MyAxiaMarket1.Models.Facture", b =>
                {
                    b.Property<int>("FactureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CommandId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FactureRef")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("addedon")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("lastModified")
                        .HasColumnType("datetime2");

                    b.Property<int>("modifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("payBefore")
                        .HasColumnType("datetime2");

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("valide")
                        .HasColumnType("bit");

                    b.HasKey("FactureId");

                    b.ToTable("Factures");
                });

            modelBuilder.Entity("MyAxiaMarket1.Models.Panier", b =>
                {
                    b.Property<int>("PanierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("NomPanier")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Reference")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("addedon")
                        .HasColumnType("datetime2");

                    b.Property<string>("description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("lastModified")
                        .HasColumnType("datetime2");

                    b.Property<int>("modifiedBy")
                        .HasColumnType("int");

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("valide")
                        .HasColumnType("bit");

                    b.Property<string>("visitorId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PanierId");

                    b.ToTable("Paniers");
                });
#pragma warning restore 612, 618
        }
    }
}
