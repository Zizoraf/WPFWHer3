using System.ComponentModel.DataAnnotations;

namespace Project.Models;

public class Film
{
    [Key]
    public long Id { get; set; }
    public required string Titel { get; set; }
    public required int Year { get; set; }
    public ICollection<Review> FilmReviews { get; set; }
    public long DirectorId { get; set; }
    public Director Director { get; set; } = null;
}