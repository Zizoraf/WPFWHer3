using Project.Controllers;
using Moq;
namespace Project.Tests;


public class FilmControllerTests
{
    [Fact]
    public void TestGreetingCall()
    {
        //Arrange
        Mock<IGreetingDependency> mock = new();
        mock.Setup(m => m.Greeting());
        FilmController controller = new FilmController(null, mock.Object);
        
        //Act
        controller.GetGreeting();
        
        //Assert
        mock.Verify(m => m.Greeting(), Times.Once);
    }
    
    // [Fact]
    // public void TestGreetingCall()
    // {
    //     //Arrange
    //     Mock<IGreetingDependency> mock = new();
    //     mock.Setup(m => m.Greeting());
    //     FilmController controller = new FilmController(null, mock.Object);
    //     
    //     //Act
    //     controller.GetGreeting();
    //     
    //     //Assert
    //     mock.Verify(m => m.Greeting(), Times.Once);
    // }
}