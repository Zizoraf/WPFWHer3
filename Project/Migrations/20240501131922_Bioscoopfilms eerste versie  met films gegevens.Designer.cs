﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project.Models;
using Project.Data;

#nullable disable

namespace Project.Migrations
{
    [DbContext(typeof(BioscoopContext))]
    [Migration("20240501131922_Bioscoopfilms eerste versie  met films gegevens")]
    partial class Bioscoopfilmseersteversiemetfilmsgegevens
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("Project.Models.Film", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Titel")
                        .HasColumnType("TEXT");

                    b.Property<int>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Films");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Titel = "The Shawshank Redemption",
                            Year = 1994
                        },
                        new
                        {
                            Id = 2L,
                            Titel = "The Godfather",
                            Year = 1972
                        },
                        new
                        {
                            Id = 3L,
                            Titel = "The Dark Knight",
                            Year = 2008
                        },
                        new
                        {
                            Id = 4L,
                            Titel = "The Godfather Part II",
                            Year = 1974
                        },
                        new
                        {
                            Id = 5L,
                            Titel = "12 Angry Men",
                            Year = 1957
                        },
                        new
                        {
                            Id = 6L,
                            Titel = "Schindler's List",
                            Year = 1993
                        },
                        new
                        {
                            Id = 7L,
                            Titel = "The Lord of the Rings: The Return of the King",
                            Year = 2003
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
