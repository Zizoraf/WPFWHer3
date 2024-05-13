using System.ComponentModel.DataAnnotations;

namespace Project.Models;

public class Director
{
    [Key]
    public long Id { get; set; }
    public ICollection<Film> Films { get; set; }
    public required string Name { get; set; }
}