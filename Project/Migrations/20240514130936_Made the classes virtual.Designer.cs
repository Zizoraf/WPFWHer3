﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Project.Data;

#nullable disable

namespace Project.Migrations
{
    [DbContext(typeof(BioscoopContext))]
    [Migration("20240514130936_Made the classes virtual")]
    partial class Madetheclassesvirtual
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("Project.Models.Director", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Directors");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "Frank Darabont"
                        },
                        new
                        {
                            Id = 2L,
                            Name = "Francis Ford Coppola"
                        },
                        new
                        {
                            Id = 3L,
                            Name = "Christopher Nolan"
                        },
                        new
                        {
                            Id = 5L,
                            Name = "Sidney Lumet"
                        },
                        new
                        {
                            Id = 6L,
                            Name = "Steven Spielberg"
                        },
                        new
                        {
                            Id = 7L,
                            Name = "Peter Jackson"
                        });
                });

            modelBuilder.Entity("Project.Models.Film", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("DirectorId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Year")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("DirectorId");

                    b.ToTable("Films");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            DirectorId = 1L,
                            Title = "The Shawshank Redemption",
                            Year = 1994
                        },
                        new
                        {
                            Id = 2L,
                            DirectorId = 2L,
                            Title = "The Godfather",
                            Year = 1972
                        },
                        new
                        {
                            Id = 3L,
                            DirectorId = 3L,
                            Title = "The Dark Knight",
                            Year = 2008
                        },
                        new
                        {
                            Id = 4L,
                            DirectorId = 2L,
                            Title = "The Godfather Part II",
                            Year = 1974
                        },
                        new
                        {
                            Id = 5L,
                            DirectorId = 4L,
                            Title = "12 Angry Men",
                            Year = 1957
                        },
                        new
                        {
                            Id = 6L,
                            DirectorId = 5L,
                            Title = "Schindler's List",
                            Year = 1993
                        },
                        new
                        {
                            Id = 7L,
                            DirectorId = 6L,
                            Title = "The Lord of the Rings: The Return of the King",
                            Year = 2003
                        });
                });

            modelBuilder.Entity("Project.Models.Review", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("FilmId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Score")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("FilmId");

                    b.ToTable("Reviews");

                    b.HasData(
                        new
                        {
                            Id = 4L,
                            CreationDate = new DateTime(2024, 5, 14, 0, 0, 0, 0, DateTimeKind.Local),
                            Description = "Nice",
                            FilmId = 1L,
                            Score = 4,
                            Username = "PirateSoftware"
                        },
                        new
                        {
                            Id = 5L,
                            CreationDate = new DateTime(2024, 5, 14, 0, 0, 0, 0, DateTimeKind.Local),
                            Description = "Noice",
                            FilmId = 1L,
                            Score = 5,
                            Username = "PirateSoftware"
                        },
                        new
                        {
                            Id = 6L,
                            CreationDate = new DateTime(2024, 5, 14, 0, 0, 0, 0, DateTimeKind.Local),
                            Description = "Super noice",
                            FilmId = 1L,
                            Score = 3,
                            Username = "PirateSoftware"
                        });
                });

            modelBuilder.Entity("Project.Models.Film", b =>
                {
                    b.HasOne("Project.Models.Director", "Director")
                        .WithMany("Films")
                        .HasForeignKey("DirectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Director");
                });

            modelBuilder.Entity("Project.Models.Review", b =>
                {
                    b.HasOne("Project.Models.Film", "Film")
                        .WithMany("FilmReviews")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Film");
                });

            modelBuilder.Entity("Project.Models.Director", b =>
                {
                    b.Navigation("Films");
                });

            modelBuilder.Entity("Project.Models.Film", b =>
                {
                    b.Navigation("FilmReviews");
                });
#pragma warning restore 612, 618
        }
    }
}