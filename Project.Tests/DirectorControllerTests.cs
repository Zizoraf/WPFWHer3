using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Controllers;
using Moq;
using Project.Data;
using Project.Models;

namespace Project.Tests;


public class DirectorControllerTests
{
    private readonly Mock<BioscoopContext> _mock;
    private Mock<IGreetingDependency> _mockGreeting;
    
    public DirectorControllerTests()
    {
        _mock = new Mock<BioscoopContext>(new DbContextOptions<BioscoopContext>());
        _mockGreeting = new Mock<IGreetingDependency>();
    }

    [Fact]
    public async Task GetDirectors()
    {
        var director = new List<Director>() //VOEG CLASSES TOE VAN LINK IN TEAMS!!!
        {
            new Director() { }
        }.AsQueryable();

        _mock.Setup(ctx => ctx.Directors).Returns(DbSetMock.Create(director));

        DirectorController controller = new DirectorController(_mock.Object, _mockGreeting.Object);

        var result = controller.GetDirector(1);

        var actioResult = Assert.IsType<ActionResult<IEnumerable<DirectorDTO>>>(result);
        var directorDto = Assert.IsAssignableFrom<IEnumerable<DirectorDTO>>(actioResult.Value);
        Assert.Equal(3, directorDto.Count());
    }
    
    [Fact]
    public void TestGreetingCall()
    {
        //Arrange
        Mock<IGreetingDependency> mock = new();
        mock.Setup(m => m.Greeting());
        DirectorController controller = new DirectorController(null, mock.Object);
        
        //Act
        controller.GetGreeting();
        
        //Assert
        mock.Verify(m => m.Greeting(), Times.Once);
    }
    

    [Fact]
    public async Task GetAllReviewsTest()
    {
        var options = new DbContextOptionsBuilder<BioscoopContext>()
            .UseInMemoryDatabase(databaseName: "ReviewListDatabase")
            .Options;

        // Insert seed data into the database using one instance of the context
        using (var context = new BioscoopContext(options))
        {
            context.Reviews.Add(new Review { Id = 1, Score = 5, Description = "Great", CreationDate = DateTime.Now, Username = "user1" });
            context.Reviews.Add(new Review { Id = 2, Score = 4, Description = "Enjoyed it", CreationDate = DateTime.Now, Username = "user2" });
            context.Reviews.Add(new Review { Id = 3, Score = 3, Description = "Not bad", CreationDate = DateTime.Now, Username = "user3" });
            context.SaveChanges();
        }

        // Use a clean instance of the context to run the test
        using (var context = new BioscoopContext(options))
        {
            ReviewController reviewController = new ReviewController(context);
            ActionResult<IEnumerable<ReviewDTO>> result = await reviewController.GetReviews();
        
            var reviews = result.Value;
            Assert.NotNull(reviews);
        
            Assert.Equal(3, reviews.Count());;
        }
    }
    
    [Fact]
    public void CreateBlog_saves_a_blog_via_context()
    {
        var mockSet = new Mock<DbSet<Review>>();

        
        mockContext.Setup(m => m.Reviews).Returns(mockSet.Object);

        var service = new BlogService(mockContext.Object);
        service.AddBlog("ADO.NET Blog", "http://blogs.msdn.com/adonet");

        mockSet.Verify(m => m.Add(It.IsAny<Blog>()), Times.Once());
        mockContext.Verify(m => m.SaveChanges(), Times.Once());
    }
    
}