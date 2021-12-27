using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Music.Model;
using Music.Model.Data;

namespace Music.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContributionTypesController : ControllerBase
    {
        private readonly ModelContext _context;

        public ContributionTypesController(ModelContext context)
        {
            _context = context;
        }

        // GET: api/ContributionTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContributionType>>> GetContributionTypes()
        {
            return await _context.ContributionTypes.ToListAsync();
        }
    }
}
