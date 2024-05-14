using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Controllers;
using Moq;
using Project.Data;
using Project.Models;

namespace Project.Tests;


public class ReviewControllerTests
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
    
    
}