using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Music.Model;
using Music.Model.Data;

namespace Music.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly ModelContext _context;

        public GenresController(ModelContext context)
        {
            _context = context;
        }

        // GET: api/Genres
        [HttpGet]
        public ActionResult<IEnumerable<Genre>> GetGenres()
        {
            return _context.Genres.ToList();
        }

        // GET: api/Genres/5
        [HttpGet("{id}")]
        public ActionResult<Genre> GetGenre(int id)
        {
            var genre = _context.Genres
                .Where(x => x.Id == id)
                .Include(genre => genre.ParentGenre)
                .Include(genre => genre.Genres)
                .FirstOrDefault();

            if (genre == null)
            {
                return NotFound();
            }

            return genre;
        }

        // POST: api/Genres
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Genre> PostGenre(Genre genre)
        {
            _context.Genres.Add(genre);
            _context.SaveChanges();

            return CreatedAtAction("GetGenre", new { id = genre.Id }, genre);
        }

        // PUT: api/Genres/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutGenre(int id, Genre genre)
        {
            if (id != genre.Id)
            {
                return BadRequest();
            }

            _context.Entry(genre).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GenreExists(id))
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

        // DELETE: api/Genres/5
        [HttpDelete("{id}")]
        public IActionResult DeleteGenre(int id)
        {
            var genre = _context.Genres.Find(id);
            if (genre == null)
            {
                return NotFound();
            }

            bool genreHasSubgenres = _context.Genres.Any(genre => genre.ParentGenre.Id == id);
            bool genreHasTracks = _context.Tracks.Any(track => track.Genre.Id == genre.Id);
            if (genreHasSubgenres || genreHasTracks)
            {
                return BadRequest();
            }

            _context.Genres.Remove(genre);
            _context.SaveChanges();

            return NoContent();
        }

        private bool GenreExists(int id)
        {
            return _context.Genres.Any(e => e.Id == id);
        }
    }
}
