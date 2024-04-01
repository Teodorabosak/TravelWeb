﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TravelWeb.Data;

#nullable disable

namespace TravelWeb.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240401133325_ImageUrl")]
    partial class ImageUrl
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.1.24081.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TravelWeb.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DisplayOrder = 1,
                            Name = "Letovanje"
                        },
                        new
                        {
                            Id = 2,
                            DisplayOrder = 2,
                            Name = "Gradovi Europe"
                        },
                        new
                        {
                            Id = 3,
                            DisplayOrder = 3,
                            Name = "Putovanja za mlade"
                        },
                        new
                        {
                            Id = 4,
                            DisplayOrder = 4,
                            Name = "Egzotična putovanja"
                        });
                });

            modelBuilder.Entity("TravelWeb.Models.Destination", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date1")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date2")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Hotel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Destinations");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            Date1 = new DateTime(2024, 3, 6, 12, 50, 0, 0, DateTimeKind.Unspecified),
                            Date2 = new DateTime(2024, 3, 29, 0, 50, 0, 0, DateTimeKind.Unspecified),
                            Description = "Uživajte u čarima termalnih kupki, poput čuvenih Gellért kupki, gde možete opustiti tela u toplim izvorima pod elegantnim mozaicima. Za ljubitelje umetnosti, poseta Muzeju savremene umetnosti ili Mađarskoj nacionalnoj galeriji predstavlja priliku da se upoznate sa bogatom kulturnom baštinom grada.  Gurmani će uživati u mađarskoj kuhinji, probajući čuvene gulaše, paprikaš i slatke poslastice poput krempita. Ne zaboravite posetiti Veliko tržište kako biste istražili lokalne proizvode i suvenire.  Budimpešta takođe nudi dinamičan noćni život, sa širokim spektrom barova, klubova i restorana. Šetnja duž obala Dunava noću pruža romantičnu atmosferu, posebno kada su mostovi osvetljeni.",
                            Hotel = "Sheraton hotel",
                            ImageUrl = "",
                            Name = "Budimpesta",
                            Price = 120.0
                        });
                });

            modelBuilder.Entity("TravelWeb.Models.Destination", b =>
                {
                    b.HasOne("TravelWeb.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}