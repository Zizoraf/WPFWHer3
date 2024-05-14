using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : ControllerBase
    {
        private readonly BioscoopContext _context;
        private readonly IGreetingDependency _greetingDependency;
        public FilmController(BioscoopContext context, IGreetingDependency greetingDependency)
        {
            _context = context;
            _greetingDependency = greetingDependency;
        }

        // GET: api/Film
        [HttpGet("Greeting")]
        public String GetGreeting()
        {
            return _greetingDependency.Greeting();
        }

        // GET: api/Film
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FilmDTO>>> GetFilms() {
            var films = await _context.Films
                .Include(film => film.Director)
                .Include(film => film.FilmReviews)
                .Select(film => new FilmDTO (film.Titel,film.Year, 
                    film.FilmReviews.Select(review => new ReviewDTO (review.Score, review.Description, review.CreationDate, review.Username)).ToList(),
                new DirectorDTO (film.Director.Name )
            )).ToListAsync();
            return films;
        }
        
        // GET: api/Film/OnlyReviewMovies
        [HttpGet("OnlyReviewMovies")]
        public async Task<ActionResult<IEnumerable<FilmDTO>>> GetFilmsWithReviews() {
            var films = await _context.Films
                .Include(film => film.Director)
                .Include(film => film.FilmReviews)
                .Where(film => film.FilmReviews.Count > 0)
                .Select(film => new FilmDTO (film.Titel, film.Year,
                    film.FilmReviews.Select(review => new ReviewDTO (review.Score, review.Description, review.CreationDate, review.Username)).ToList(),
                    new DirectorDTO (film.Director.Name)
                )).ToListAsync();
            return films;
        }
        
        // GET: api/Film/GetFilmsWithReviewCharacterCount150HigherAndLessThanYear
        [HttpGet("GetFilmsWithReviewCharacterCount150HigherAndLessThanYear")]
        public async Task<ActionResult<IEnumerable<FilmDTO>>> GetFilmsWithReviewCharacterCount150HigherAndLessThanYear() {
            var films = await _context.Films
                .Include(film => film.Director)
                .Include(film => film.FilmReviews)
                .Where(film => film.FilmReviews.Any(review => 
                        review.Description.Length > 150 &&
                        review.CreationDate >= DateTime.Today.AddYears(-1)))
                .Select(film => new FilmDTO (film.Titel, film.Year,
                    film.FilmReviews.Select(review => 
                        new ReviewDTO (review.Score, review.Description, review.CreationDate, review.Username
                    )).ToList(),
                    new DirectorDTO (film.Director.Name)
                )).ToListAsync();
            return films;
        }

        // GET: api/Film/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FilmDTO>> GetFilm(long id)
        {
            var film = await _context.Films
                .Include(film => film.Director)
                .Include(film => film.FilmReviews)
                .Where(film => film.Id == id)
                .Select(film => new FilmDTO (film.Titel, film.Year,
                    film.FilmReviews
                        .Select(review => new ReviewDTO (review.Score, review.Description, review.CreationDate, review.Username)).ToList(),
                    new DirectorDTO (film.Director.Name )
                    
                )).FirstOrDefaultAsync();
        
            if (film == null)
            {
                return NotFound();
            }
        
            return film;
        }

        // PUT: api/Film/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFilm(long id, Film film)
        {
            if (id != film.Id)
            {
                return BadRequest();
            }

            _context.Entry(film).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FilmExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Film
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FilmDTO>> PostFilm(Film film)
        {
            _context.Films.Add(film);
            await _context.SaveChangesAsync();
        
            return CreatedAtAction("GetFilm", new { id = film.Id }, film);
        }

        // DELETE: api/Film/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFilm(long id)
        {
            var film = await _context.Films.FindAsync(id);
            if (film == null)
            {
                return NotFound();
            }

            _context.Films.Remove(film);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FilmExists(long id)
        {
            return _context.Films.Any(e => e.Id == id);
        }
    }
}
