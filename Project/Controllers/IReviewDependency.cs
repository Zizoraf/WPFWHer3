using Project.Models;

namespace Project.Controllers;

public interface IReviewDependency
{
    // ICollection<ReviewDTO> GetReviews();
    Task<IEnumerable<Review>> GetAll();
    Task<IEnumerable<Review>> GetReviews();
}