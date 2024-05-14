public class ReviewDTO (int score, string description, DateTime creationDate, string username)
{
    public int Score { get; set; } = score;
    public string Description { get; set; } = description;
    public DateTime CreationDate { get; set; } = creationDate;
    public string Username { get; set; } = username;
}