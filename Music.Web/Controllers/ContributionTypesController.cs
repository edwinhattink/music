using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
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
        public ActionResult<IEnumerable<ContributionType>> GetContributionTypes()
        {
            return _context.ContributionTypes.ToList();
        }
    }
}
