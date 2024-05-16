using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Controllers;
using Moq;
using Project.Data;
using Project.Models;
using Project.Tests.HelpTestScripts;

namespace Project.Tests;


public class FilmControllerTests
{
    private readonly Mock<BioscoopContext> _mock;
    private Mock<IGreetingDependency> _mockGreeting;
    
    public FilmControllerTests()
    {
        _mock = new Mock<BioscoopContext>(new DbContextOptions<BioscoopContext>());
        _mockGreeting = new Mock<IGreetingDependency>();
    }
    
    [Fact]
    public async Task GetFilms() { //Works
        var films = getTestDataList();

        _mock.Setup(ctx => ctx.Films).Returns(DbSetMock.Create(films.AsQueryable()));

        FilmController controller = new FilmController(_mock.Object, _mockGreeting.Object);

        var result = await controller.GetFilms();

        var actionResult = Assert.IsType<ActionResult<IEnumerable<FilmDTO>>>(result);
        var filmDto = Assert.IsAssignableFrom<IEnumerable<FilmDTO>>(actionResult.Value);
        Assert.Equal(films.Count(), films.Count);
    }
    
    [Fact]
    public async Task GetFilmsWithReviews() { //Where statement breaks it
        var films = getTestDataList();

        _mock.Setup(ctx => ctx.Films).Returns(DbSetMock.Create(films.AsQueryable()));

        FilmController controller = new FilmController(_mock.Object, _mockGreeting.Object);

        var result = await controller.GetFilmsWithReviews();

        var actionResult = Assert.IsType<ActionResult<FilmDTO>>(result);
        var filmDto = Assert.IsAssignableFrom<FilmDTO>(actionResult.Value);
        Assert.Equal(filmDto.Id, 1);
    }
    
    [Fact]
    public async Task GetFilmsWithReviewCharacterCount150HigherAndLessThanYear() { //Where statement breaks it
        var films = getTestDataList();

        _mock.Setup(ctx => ctx.Films).Returns(DbSetMock.Create(films.AsQueryable()));

        FilmController controller = new FilmController(_mock.Object, _mockGreeting.Object);

        var result = await controller.GetFilmsWithReviewCharacterCount150HigherAndLessThanYear();

        var actionResult = Assert.IsType<ActionResult<IEnumerable<FilmDTO>>>(result);
        var filmDto = Assert.IsAssignableFrom<IEnumerable<FilmDTO>>(actionResult.Value);
        Assert.Equal(films.Count(), films.Count);
    }
    
    [Fact]
    public async Task GetFilm() //Where statement breaks it
    {
        var film = getTestDataList();

        _mock.Setup(ctx => ctx.Films).Returns(DbSetMock.Create(film.AsQueryable()));

        FilmController controller = new FilmController(_mock.Object, _mockGreeting.Object);

        var result = await controller.GetFilm(1);

        var actionResult = Assert.IsType<ActionResult<FilmDTO>>(result);
        var filmDto = Assert.IsAssignableFrom<FilmDTO>(actionResult.Value);
        Assert.Equal(filmDto.Title, film[0].Title);
    }
    
    [Fact]
    public async Task PutFilm() //Works
    {
        var film = getTestDataList(); 
        _mock.Setup(ctx => ctx.Films).Returns(DbSetMock.Create(film.AsQueryable()));

        var controller = new FilmController(_mock.Object, _mockGreeting.Object);
        var filmDtoEditNameAndYear = new FilmDtoEditNameAndYear ("Updated Title", 2023, "Oceania");
        
        var result = await controller.PutFilmMockTest(1, filmDtoEditNameAndYear);
        var result2 = await controller.GetFilms();
        
        Assert.IsType<NoContentResult>(result);
        var actionResult = Assert.IsType<ActionResult<IEnumerable<FilmDTO>>>(result2);
        var filmDto = Assert.IsAssignableFrom<IEnumerable<FilmDTO>>(actionResult.Value);
        Assert.Equal(filmDto.ElementAt(0).Title, filmDtoEditNameAndYear.Title);
    }
    
    [Fact]
    public async Task PostFilm() //TODO: Fix
    {
        var directorId = 1;
        var director = new Director {Id = directorId, Name = "Harry the Wizard"};
        _mock.Setup(ctx => ctx.Directors.FindAsync(directorId)).ReturnsAsync(director);
        _mock.Setup(ctx => ctx.Films).Returns(DbSetMock.Create(new List<Film>().AsQueryable()));
        
        var testSubject = new FilmAdd ("Test Film", 2023, "Oceania");

        FilmController controller = new FilmController(_mock.Object, _mockGreeting.Object);

        var result = await controller.PostFilm(directorId, testSubject);

        var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
        Assert.Equal("GetFilm", createdAtActionResult.ActionName);
        Assert.Equal(testSubject, createdAtActionResult.Value);
    }
    
    [Fact]
    public async Task DeleteFilm() //TODO: Fix
    {
        // Arrange
        var filmId = 1;
        var film = new Film { Id = filmId, Title = "Doom", Year = 1996, LandRecorded = "Zwitserland"};
        _mock.Setup(ctx => ctx.Films.FindAsync(filmId)).ReturnsAsync(film);

        FilmController controller = new FilmController(_mock.Object, _mockGreeting.Object);

        // Act
        var result = await controller.DeleteFilm(filmId);

        // Assert
        Assert.IsType<NoContentResult>(result);
    }

    private List<Film> getTestDataList() {
        return new List<Film>
        {
            new Film
            {
                Id = 1,
                Title = "Inception",
                Year = 2010,
                LandRecorded = "Oceania",
                FilmReviews = new List<Review>(),
                DirectorId = 1, // Assuming you have a Director with Id 1
                Director = new Director
                {
                    Id = 1,
                    Name = "Christopher Nolan" // Assuming you have a Director class with a Name property
                }
            },
            new Film
            {
                Id = 2,
                Title = "The Dark Knight",
                Year = 2008,
                LandRecorded = "Murica",
                FilmReviews = new List<Review>(),
                DirectorId = 1, // Assuming Christopher Nolan is the director again
                Director = new Director
                {
                    Id = 1,
                    Name = "Christopher Nolan"
                }
            },
            new Film
            {
                Id = 3,
                Title = "Interstellar",
                Year = 2014,
                LandRecorded = "Bangladesh",
                FilmReviews = new List<Review>(),
                DirectorId = 1, // Once more, assuming Christopher Nolan is the director
                Director = new Director
                {
                    Id = 1,
                    Name = "Christopher Nolan"
                }
            }
        };
    }
}