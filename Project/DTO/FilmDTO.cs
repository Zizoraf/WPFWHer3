using Project.Models;

public class FilmDTO(string title, int year, ICollection<ReviewDTO> reviews, DirectorDTO director)
{
    public string Titel { get; set; } = title;
    public int Year { get; set; } = year;
    public ICollection<ReviewDTO> FilmReviews { get; set; } = reviews;
    public DirectorDTO Director { get; set; } = director;
}