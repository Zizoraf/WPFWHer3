public class ReviewDTO (long id, int score, string description, DateTime creationDate, string username)
{
    public long Id { get; set; } = id;
    public int Score { get; set; } = score;
    public string Description { get; set; } = description;
    public DateTime CreationDate { get; set; } = creationDate;
    public string Username { get; set; } = username;
}

public class ReviewAddUpdateDTO (int score, string description, string username)
{
    public int Score { get; set; } = score;
    public string Description { get; set; } = description;
    public string Username { get; set; } = username;
}