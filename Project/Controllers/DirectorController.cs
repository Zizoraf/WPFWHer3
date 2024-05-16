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
    public class DirectorController : ControllerBase
    {
        private readonly BioscoopContext _context;
        private readonly IGreetingDependency _greetingDependency;
        public DirectorController(BioscoopContext context, IGreetingDependency greetingDependency)
        {
            _context = context;
            _greetingDependency = greetingDependency;
        }

        // GET: api/Director
        [HttpGet("Greeting")]
        public String GetGreeting()
        {
            return _greetingDependency.Greeting();
        }

        // GET: api/Director
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DirectorDTO>>> GetDirectors() {
            var directors = await _context.Directors
                .Select(director => new DirectorDTO (director.Id, director.Name)).ToListAsync();
            return directors;
        }

        // GET: api/Director/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DirectorDTO>> GetDirector(long id)
        {
            var director = await _context.Directors.FindAsync(id);
        
            if (director == null)
            {
                return NotFound();
            }

            DirectorDTO returnDirector = new DirectorDTO(director.Id, director.Name);
        
            return returnDirector;
        }

        // PUT: api/Director/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDirector(long id, DirectorDTO directorDto)
        {
            var director = await _context.Directors.FindAsync(id);
            if (director == null)
            {
                return NotFound();
            }

            director.Name = directorDto.Name;

            _context.Entry(director).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DirectorExists(id))
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
        
        // PUT: api/Director/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}/Mocktest")]
        public async Task<IActionResult> PutDirectorMock(long id, DirectorDTO directorDto)
        {
            var director = await _context.Directors.FindAsync(id);
            if (director == null)
            {
                return NotFound();
            }

            director.Name = directorDto.Name;

            // _context.Entry(director).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DirectorExists(id))
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

        // POST: api/Director
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DirectorDTO>> PostDirector(DirectorDTO directorDto)
        {
            Director director = new Director {
                Name = directorDto.Name,
                Films = new List<Film>()
            };
            _context.Directors.Add(director);
            await _context.SaveChangesAsync();
        
            return CreatedAtAction("GetDirector", new { id = director.Id }, directorDto);
        }

        // DELETE: api/Director/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDirector(long id)
        {
            var director = await _context.Directors.FindAsync(id);
            if (director == null)
            {
                return NotFound();
            }

            _context.Directors.Remove(director);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DirectorExists(long id)
        {
            return _context.Directors.Any(e => e.Id == id);
        }
    }
}
