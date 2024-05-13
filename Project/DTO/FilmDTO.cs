using Project.Models;

public class FilmDTO {
    public string Titel { get; set; }
    public int Year { get; set; }
    public ICollection<ReviewDTO> FilmReviews { get; set; }
    public DirectorDTO Director { get; set; }
    public long RegisseurId { get; set; }
}