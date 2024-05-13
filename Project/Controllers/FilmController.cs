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

        // // GET: api/Film
        // [HttpGet]
        // public async Task<ActionResult<IEnumerable<FilmDTO>>> GetFilms() {
        //     var films = await _context.Films.Include(film => film.Director).Select(film => new FilmDTO {
        //         Titel = film.Titel,
        //         Year = film.Year,
        //         Regisseur = film.DirectorId != null ? new RegisseurDTO { Name = film.Director.Name } : null
        //     }).ToListAsync();
        //     // List<FilmDTO> filmDTOs = convertFilmsToDTO(films);
        //     return films;
        // }

        // // GET: api/Film/5
        // [HttpGet("{id}")]
        // public async Task<ActionResult<FilmDTO>> GetFilm(long id)
        // {
        //     var film = await _context.Films.FindAsync(id);
        //
        //     if (film == null)
        //     {
        //         return NotFound();
        //     }
        //
        //     FilmDTO returnFilm = new FilmDTO(){
        //         Titel = film.Titel,
        //         Year = film.Year,
        //         FilmReviews = convertReviewsToDTO(film.FilmReviews.ToList()),
        //     };
        //
        //     return returnFilm;
        // }

        private List<ReviewDTO> convertReviewsToDTO (List<Review> reviews) {
            List<ReviewDTO> reviewDTOs = new List<ReviewDTO>();
            foreach (Review review in reviews) {
                reviewDTOs.Add(new ReviewDTO {
                    Score = review.Score,
                    Description = review.Description,
                    CreationDate = review.CreationDate,
                    Username = review.Username
                });
            }
            return reviewDTOs;
        }

        // private List<FilmDTO> convertFilmsToDTO (List<Film> films) {
        //     List<FilmDTO> filmDTOs = [];
        //     foreach (Film film in films) {
        //         filmDTOs.Add(new FilmDTO(){
        //             Titel = film.Titel,
        //             Year = film.Year,
        //             FilmReviews = convertReviewsToDTO(film.FilmReviews.ToList()),
        //         });
        //     }
        //     return filmDTOs;
        // }

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
        // [HttpPost]
        // public async Task<ActionResult<Film>> PostFilm(Film film)
        // {
        //     _context.Films.Add(film);
        //     await _context.SaveChangesAsync();
        //
        //     return CreatedAtAction("GetFilm", new { id = film.Id }, film);
        // }

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
