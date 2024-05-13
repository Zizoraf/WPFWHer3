using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Project.Data;

public class BioscoopContext : DbContext //https://learn.microsoft.com/en-us/aspnet/core/security/authentication/identity-api-authorization?view=aspnetcore-8.0
{
    public BioscoopContext(DbContextOptions<BioscoopContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Director>().HasKey(f => f.Id);
         modelBuilder.Entity<Director>().HasData(
            CreateRegisseur(1, "Frank Darabont"),
            CreateRegisseur(2, "Francis Ford Coppola"),
            CreateRegisseur(3, "Christopher Nolan"),
            CreateRegisseur(5, "Sidney Lumet"),
            CreateRegisseur(6, "Steven Spielberg"),
            CreateRegisseur(7, "Peter Jackson"));
         
         modelBuilder.Entity<Review>().HasData(
             CreateReview(4, 1, 4, "Nice", "PirateSoftware"),
             CreateReview(5, 1, 5, "Noice", "PirateSoftware"),
             CreateReview(6, 1, 3, "Super noice", "PirateSoftware")
             );

        modelBuilder.Entity<Film>().HasKey(f => f.Id);
        // modelBuilder.Entity<Film>()
        //     .HasOne<Director>(f => f.Director)
        //     .WithMany(f => f.Films)
        //     .HasForeignKey(f => f.RegisseurId);
        modelBuilder.Entity<Film>()
            .HasMany(f => f.FilmReviews)
            .WithOne(r => r.Film)
            .HasForeignKey(r => r.FilmId);
        modelBuilder.Entity<Film>().HasData(
            CreateFilm(1, "The Shawshank Redemption", 1994, 1),
            CreateFilm(2, "The Godfather", 1972, 2),
            CreateFilm(3, "The Dark Knight", 2008, 3),
            CreateFilm(4, "The Godfather Part II", 1974, 2),
            CreateFilm(5, "12 Angry Men", 1957, 4),
            CreateFilm(6, "Schindler's List", 1993, 5),
            CreateFilm(7, "The Lord of the Rings: The Return of the King", 2003, 6)
        );
    }

    public DbSet<Director> Regisseurs { get; set; }
    public DbSet<Film> Films { get; set; }
    public DbSet<Review> Reviews { get; set; }

    public Director CreateRegisseur(long id, string name){
        return new Director {Id = id, Name = name};
    }
    public Film CreateFilm(long id, string titel, int year, long regisseurId){
        return new Film { Id = id, Titel = titel, Year = year , 
            // RegisseurId = regisseurId
            
        };
    }

    public Review CreateReview(long id, long filmId, int score, string description, string username){
        return new Review {Id = id, FilmId = filmId, Score = score , Description = description, Username = username, CreationDate = DateTime.Today};
    }
}