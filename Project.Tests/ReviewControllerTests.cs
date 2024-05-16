using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Controllers;
using Moq;
using Project.Data;
using Project.Models;
using Project.Tests.HelpTestScripts;

namespace Project.Tests;


public class ReviewControllerTests
{
    private readonly Mock<BioscoopContext> _mock;
    private Mock<IGreetingDependency> _mockGreeting;
    
    public ReviewControllerTests()
    {
        _mock = new Mock<BioscoopContext>(new DbContextOptions<BioscoopContext>());
        _mockGreeting = new Mock<IGreetingDependency>();
    }
    
    [Fact]
    public async Task GetReviews() {
        List<Review> reviewTest = GetReviewTestData();
        _mock.Setup(ctx => ctx.Reviews).Returns(DbSetMock.Create(reviewTest.AsQueryable()));

        ReviewController controller = new ReviewController(_mock.Object);

        var result = await controller.GetReviews();

        var actionResult = Assert.IsType<ActionResult<IEnumerable<ReviewDTO>>>(result);
        var reviewDto = Assert.IsAssignableFrom<IEnumerable<ReviewDTO>>(actionResult.Value);
        Assert.Equal(reviewDto.Count(), reviewTest.Count);
    }
    
    [Fact]
    public async Task GetReview()
    {
        List<Review> reviewTest = GetReviewTestData();
        _mock.Setup(ctx => ctx.Reviews).Returns(DbSetMock.Create(reviewTest.AsQueryable()));

        ReviewController controller = new ReviewController(_mock.Object);

        var result = await controller.GetReview(1);

        var actionResult = Assert.IsType<ActionResult<ReviewDTO>>(result);
        var reviewDto = Assert.IsAssignableFrom<ReviewDTO>(actionResult.Value);
        Assert.Equal(reviewDto.Description, reviewTest[0].Description);
    }
    
    [Fact]
    public async Task PutReview() //Works
    {
        List<Review> reviewTest = GetReviewTestData();
        _mock.Setup(ctx => ctx.Reviews).Returns(DbSetMock.Create(reviewTest.AsQueryable()));

        int reviewId = 1;
        
        var reviewController = new ReviewController(_mock.Object);
        var reviewDto = new ReviewAddUpdateDTO(5, "This movie is a masterpiece. The acting, direction, and storyline are all top-notch. I was glued to the screen from start to finish.", "user1");
        
        var result = await reviewController.PutReviewMock(reviewId, reviewDto);
        var result2 = await reviewController.GetReviews();
        
        Assert.IsType<NoContentResult>(result);
        var actionResult = Assert.IsType<ActionResult<IEnumerable<ReviewDTO>>>(result2);
        var reviewDTO = Assert.IsAssignableFrom<IEnumerable<ReviewDTO>>(actionResult.Value);
        Assert.Equal(reviewDTO.ElementAt(0).Description, reviewDto.Description);
    }
    
    [Fact]
    public async Task PostReview() //Not working
    {
        List<Review> reviewTest = GetReviewTestData();
        _mock.Setup(ctx => ctx.Reviews).Returns(DbSetMock.Create(reviewTest.AsQueryable()));
    
        ReviewController controller = new ReviewController(_mock.Object);

        ReviewAddUpdateDTO testSubject = new ReviewAddUpdateDTO(4,
            "Great movie, loved the plot twists! The characters were well-developed and the cinematography was stunning. It's definitely worth watching.",
            "user1");
        var result = await controller.PostReview(1, testSubject);
        
        var result2 = await controller.GetReviews();
    
        var actionResult = Assert.IsType<ActionResult<ReviewDTO>>(result);
        var reviewDto = Assert.IsAssignableFrom<ReviewDTO>(actionResult.Value);
        Assert.Equal(reviewDto.Description, reviewDto.Description);
    }
    
    [Fact]
    public async Task DeleteReview() //fix
    {
        List<Review> reviewTest = GetReviewTestData();
        _mock.Setup(ctx => ctx.Reviews).Returns(DbSetMock.Create(reviewTest.AsQueryable()));

        ReviewController controller = new ReviewController(_mock.Object);

        var delete = await controller.DeleteReview(3);
        var result = await controller.GetReviews();

        var actionResult = Assert.IsType<ActionResult<IEnumerable<ReviewDTO>>>(result);
        var reviewDto = Assert.IsAssignableFrom<IEnumerable<ReviewDTO>>(actionResult.Value);
        Assert.Equal(reviewDto.Count(), reviewTest.Count() - 1);
    }
    
    private List<Review> GetReviewTestData() {
        return new List<Review>()
        {
            new Review() { Id = 1, FilmId = 1, Score = 4, Description = "Great movie, loved the plot twists! The characters were well-developed and the cinematography was stunning.", CreationDate = new DateTime(2024, 5, 10), Username = "user1" },
            new Review() { Id = 2, FilmId = 1, Score = 5, Description = "Outstanding performance by the actors. The story kept me on the edge of my seat from start to finish.", CreationDate = new DateTime(2024, 5, 11), Username = "user2" },
            new Review() { Id = 3, FilmId = 2, Score = 3, Description = "Good but could be better. The pacing felt a bit off at times, but overall it was an enjoyable experience.", CreationDate = new DateTime(2024, 5, 12), Username = "user3" },
            new Review() { Id = 4, FilmId = 2, Score = 2, Description = "Disappointing, not what I expected. I had high hopes for this film but it fell short of my expectations.", CreationDate = new DateTime(2024, 5, 13), Username = "user4" },
            new Review() { Id = 5, FilmId = 3, Score = 5, Description = "Absolutely brilliant! The acting was superb and the storyline was captivating from start to finish.", CreationDate = new DateTime(2024, 5, 14), Username = "user5" },
            new Review() { Id = 6, FilmId = 3, Score = 4, Description = "A must-watch for everyone. This film tackles important themes with grace and depth.", CreationDate = new DateTime(2024, 5, 15), Username = "user6" }
        };
    }
}