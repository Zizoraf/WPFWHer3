using Project.Models;

public class DirectorDTO {
    public ICollection<Film> Films { get; set; }
    public required string Name { get; set; }
}