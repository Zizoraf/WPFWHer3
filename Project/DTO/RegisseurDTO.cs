using Project.Models;

public class RegisseurDTO {
    public ICollection<Film> Films { get; set; }
    public required string Name;
}