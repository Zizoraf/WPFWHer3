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
    public class ReviewController : ControllerBase
    {
        private readonly BioscoopContext _context;
        private readonly IGreetingDependency _greetingDependency;
        public ReviewController(BioscoopContext context, IGreetingDependency greetingDependency)
        {
            _context = context;
            _greetingDependency = greetingDependency;
        }

        // GET: api/Review
        [HttpGet("Greeting")]
        public String GetGreeting()
        {
            return _greetingDependency.Greeting();
        }

        // GET: api/Review
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReviewDTO>>> GetReviews() {
            var reviews = await _context.Reviews
                .Select(review => new ReviewDTO(review.Score, review.Description, review.CreationDate, review.Username)).ToListAsync();;
            return reviews;
        }
        
        // GET: api/Review/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReviewDTO>> GetReview(long id)
        {
            var Review = await _context.Reviews.FindAsync(id);
        
            if (Review == null)
            {
                return NotFound();
            }
        
            ReviewDTO returnReview = new ReviewDTO(Review.Score, Review.Description, Review.CreationDate, Review.Username);
        
            return returnReview;
        }
        
        // // PUT: api/Review/5
        // // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReview(long id, ReviewDTO reviewDto)
        {
            var review = await _context.Reviews.FindAsync(id);

            review.Description = reviewDto.Description;
            review.Username = reviewDto.Username;
            review.Score = reviewDto.Score;
            
            _context.Entry(review).State = EntityState.Modified;
        
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReviewExists(id))
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

        // POST: api/Review
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{filmId}")]
        public async Task<ActionResult<ReviewDTO>> PostReview(long filmId, ReviewDTO reviewDto)
        {
            var film = await _context.Films.FindAsync(filmId);

            if (film == null)
            {
                throw new Exception("filmId doesn't exist");
            }
            
            Review review = new Review {
                FilmId = filmId,
                Score = reviewDto.Score,
                Description = reviewDto.Description,
                CreationDate = reviewDto.CreationDate,
                Username = reviewDto.Username
            };
            
            
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReview", new { id = review.Id }, new ReviewDTO (review.Score, review.Description, review.CreationDate, review.Username));
        }

        // DELETE: api/Review/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(long id)
        {
            var Review = await _context.Reviews.FindAsync(id);
            if (Review == null)
            {
                return NotFound();
            }
        
            _context.Reviews.Remove(Review);
            await _context.SaveChangesAsync();
        
            return NoContent();
        }
        
        private bool ReviewExists(long id)
        {
            return _context.Reviews.Any(e => e.Id == id);
        }
    }
}
