using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Music.Model;
using Music.Model.Data;

namespace Music.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscsController : ControllerBase
    {
        private readonly ModelContext _context;

        public DiscsController(ModelContext context)
        {
            _context = context;
        }

        // GET: api/Discs
        [HttpGet]
        public ActionResult<IEnumerable<Disc>> GetDiscs()
        {
            return _context.Discs.ToList();
        }

        // GET: api/Discs/5
        [HttpGet("{id}")]
        public ActionResult<Disc> GetDisc(int id)
        {
            var disc = _context.Discs.FirstOrDefault(disc => disc.Id == id);

            if (disc == null)
            {
                return NotFound();
            }

            return disc;
        }

        // POST: api/Discs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Disc> PostDisc(Disc disc)
        {
            _context.Discs.Add(disc);
            _context.SaveChanges();

            return CreatedAtAction("GetDisc", new { id = disc.Id }, disc);
        }

        // PUT: api/Discs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public IActionResult PutDisc(int id, Disc disc)
        {
            if (id != disc.Id)
            {
                return BadRequest();
            }

            _context.Entry(disc).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiscExists(id))
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

        // DELETE: api/Discs/5
        [HttpDelete("{id}")]
        public IActionResult DeleteDisc(int id)
        {
            var disc = _context.Discs.Include(disc => disc.DiscContributions).FirstOrDefault(disc => disc.Id == id);
            if (disc == null)
            {
                return NotFound();
            }

            bool discHasTracks = _context.Tracks.Where(track => track.DiscId == disc.Id).Any();
            if (discHasTracks)
            {
                return BadRequest();
            }

            foreach (var contribution in disc.DiscContributions)
            {
                _context.DiscContributions.Remove(contribution);
            }

            _context.Discs.Remove(disc);
            _context.SaveChanges();

            return NoContent();
        }

        private bool DiscExists(int id)
        {
            return _context.Discs.Any(e => e.Id == id);
        }
    }
}
