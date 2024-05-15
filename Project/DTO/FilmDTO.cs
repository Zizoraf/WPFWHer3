using Project.Models;

public class FilmDTO(long id, string title, int year, ICollection<ReviewDTO> reviews, DirectorDTO director)
{
    public long Id { get; set; } = id;
    public string Title { get; set; } = title;
    public int Year { get; set; } = year;
    public ICollection<ReviewDTO> FilmReviews { get; set; } = reviews;
    public DirectorDTO Director { get; set; } = director;
}

public class FilmDtoEditNameAndYear(string title, int year) {
    public string Title { get; set; } = title;
    public int Year { get; set; } = year;
}

public class FilmAdd(string title, int year) {
    public string Title { get; set; } = title;
    public int Year { get; set; } = year;
}