using System.ComponentModel.DataAnnotations;

namespace Project.Models;

public class Film
{
    [Key]
    public long Id { get; set; }
    public string? Titel { get; set; }
    public int Year { get; set; }
}