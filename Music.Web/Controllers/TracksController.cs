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
    public class TracksController : ControllerBase
    {
        private readonly ModelContext _context;

        public TracksController(ModelContext context)
        {
            _context = context;
        }

        // GET: api/Tracks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Track>>> GetTracks()
        {
            return await _context.Tracks.ToListAsync();
        }

        // GET: api/Tracks/5
        [HttpGet("{id}")]
        public ActionResult<Track> GetTrack(int id)
        {
            var track = _context.Tracks
                .Where(t => t.Id == id)
                .Include(t => t.Contributions)
                .Include(t => t.Genre)
                .Include(t => t.Disc)
                .FirstOrDefault();

            if (track == null)
            {
                return NotFound();
            }

            return track;
        }

        // POST: api/Tracks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Track>> PostTrack(Track track)
        {
            _context.Tracks.Add(track);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrack", new { id = track.Id }, track);
        }

        // PUT: api/Tracks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrack(int id, Track track)
        {
            if (id != track.Id)
            {
                return BadRequest();
            }

            var currentContributions = await _context.Contributions.Where(c => c.TrackId == id).ToListAsync();
            foreach (var updatedContribution in track.Contributions)
            {
                var contribution = currentContributions.FirstOrDefault(c => c.TrackId == id && c.ArtistId == updatedContribution.ArtistId);
                if (contribution == null)
                {
                    updatedContribution.TrackId = id;
                    _context.Contributions.Add(updatedContribution);
                } else
                {
                    contribution.ContributionType = updatedContribution.ContributionType;
                    _context.Entry(contribution).State = EntityState.Modified;
                }
            }
            var toKeepArtists = track.Contributions.Select(c => c.ArtistId);
            var toDeleteContributions = currentContributions.Where(c => !toKeepArtists.Contains(c.ArtistId));
            foreach (var toDeleteContribution in toDeleteContributions)
            {
                _context.Entry(toDeleteContribution).State = EntityState.Deleted;
            }

            _context.Entry(track).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrackExists(id))
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

        // DELETE: api/Tracks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrack(int id)
        {
            var track = await _context.Tracks.FindAsync(id);
            if (track == null)
            {
                return NotFound();
            }

            _context.Tracks.Remove(track);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TrackExists(int id)
        {
            return _context.Tracks.Any(e => e.Id == id);
        }
    }
}
