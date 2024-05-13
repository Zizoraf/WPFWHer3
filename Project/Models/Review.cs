using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Project.Models;

public class Review
{
    [Key]
    public long Id { get; set; }
    public long FilmId { get; set; }
    public Film Film { get; set; }
    [Range(1, 5, ErrorMessage = "Value must be between 1 and 5")]
    public required int Score { get; set; }
    [MinLength(50, ErrorMessage = "Description needs atleast 50 characters. ") ]
    public required string Description { get; set; }
    public required DateTime CreationDate { get; set; } = DateTime.Today;
    public required string Username { get; set; }
}