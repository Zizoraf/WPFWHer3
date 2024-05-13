public class ReviewDTO
{
    public required int Score { get; set; }
    public required string Description { get; set; }
    public DateTime CreationDate { get; set; } = DateTime.Today;
    public required string Username { get; set; }
}