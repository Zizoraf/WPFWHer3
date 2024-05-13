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
        modelBuilder.Entity<Film>().HasKey(f => f.Id);
        modelBuilder.Entity<Film>().HasData(
            CreateFilm(1, "The Shawshank Redemption", 1994),
            CreateFilm(2, "The Godfather", 1972),
            CreateFilm(3, "The Dark Knight", 2008),
            CreateFilm(4, "The Godfather Part II", 1974),
            CreateFilm(5, "12 Angry Men", 1957),
            CreateFilm(6, "Schindler's List", 1993),
            CreateFilm(7, "The Lord of the Rings: The Return of the King", 2003)
        );
    }

    public DbSet<Film> Films { get; set; }

    public Film CreateFilm(int id, string titel, int year)
    {
        return new Film { Id = id, Titel = titel, Year = year };
    }
}