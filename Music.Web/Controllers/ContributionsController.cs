﻿using System.Collections.Generic;
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
    public class ContributionsController : ControllerBase
    {
        private readonly ModelContext _context;

        public ContributionsController(ModelContext context)
        {
            _context = context;
        }

        // GET: api/Contributions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contribution>>> GetContributions()
        {
            return await _context.Contributions.ToListAsync();
        }

        // GET: api/Contributions/5
        [HttpGet("{id}")]
        public ActionResult<Contribution> GetContribution(int id)
        {
            var track = _context.Contributions
                .Where(t => t.Id == id)
                .FirstOrDefault();

            if (track == null)
            {
                return NotFound();
            }

            return track;
        }

        // POST: api/Contributions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Contribution>> PostContribution(Contribution contribution)
        {
            _context.Contributions.Add(contribution);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContribution", new { id = contribution.Id }, contribution);
        }

        // PUT: api/Contributions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContribution(int id, Contribution contribution)
        {
            if (id != contribution.Id)
            {
                return BadRequest();
            }

            _context.Entry(contribution).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContributionExists(id))
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

        // DELETE: api/Contributions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContribution(int id)
        {
            var contribution = await _context.Contributions.FindAsync(id);
            if (contribution == null)
            {
                return NotFound();
            }

            _context.Contributions.Remove(contribution);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContributionExists(int id)
        {
            return _context.Contributions.Any(e => e.Id == id);
        }
    }
}
