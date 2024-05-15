﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Controllers;
using Moq;
using Project.Data;
using Project.Models;
using Project.Tests.HelpTestScripts;

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
    public async Task GetDirector()
    {
        var director = new List<Director>()
        {
            new() { Id = 1, Name = "Henk", Films = new List<Film>() },
            new() { Id = 2, Name = "Ruttie", Films = new List<Film>() },
            new() { Id = 3, Name = "Bartolomeo", Films = new List<Film>() },
        };

        _mock.Setup(ctx => ctx.Directors).Returns(DbSetMock.Create(director.AsQueryable()));

        DirectorController controller = new DirectorController(_mock.Object, _mockGreeting.Object);

        var result = await controller.GetDirector(1);

        var actionResult = Assert.IsType<ActionResult<DirectorDTO>>(result);
        var directorDto = Assert.IsAssignableFrom<DirectorDTO>(actionResult.Value);
        Assert.Equal(directorDto.Name, director[0].Name);
    }
    
    [Fact]
    public async Task GetDirectors()
    {
        var director = new List<Director>()
        {
            new() { Id = 1, Name = "Henk", Films = new List<Film>() },
            new() { Id = 2, Name = "Ruttie", Films = new List<Film>() },
            new() { Id = 3, Name = "Bartolomeo", Films = new List<Film>() },
        };

        _mock.Setup(ctx => ctx.Directors).Returns(DbSetMock.Create(director.AsQueryable()));

        DirectorController controller = new DirectorController(_mock.Object, _mockGreeting.Object);

        var result = await controller.GetDirectors();

        var actionResult = Assert.IsType<ActionResult<List<DirectorDTO>>>(result);
        var directorDto = Assert.IsAssignableFrom<List<DirectorDTO>>(actionResult.Value);
        Assert.Equal(directorDto.Count(), director.Count);
    }
}