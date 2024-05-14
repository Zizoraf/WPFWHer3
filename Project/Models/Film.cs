using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Models;

public class Film
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    public required string Title { get; set; }
    public required int Year { get; set; }
    public virtual ICollection<Review>? FilmReviews { get; set; }
    public long DirectorId { get; set; }
    public virtual Director Director { get; set; } = null;
}