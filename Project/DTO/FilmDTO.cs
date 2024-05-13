using Project.Models;

public class FilmDTO {
    public string Titel { get; set; }
    public int Year { get; set; }
    public ICollection<FilmReviewDTO>? FilmReviews { get; set; }
    public DirectorDTO Director { get; set; }
}