using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GrainBroker.API.Data;
using GrainBroker.API.Models;

namespace GrainBroker.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GrainRequirementsController : ControllerBase
    {
        private readonly GrainBrokerContext _context;
        private readonly ILogger<GrainRequirementsController> _logger;

        public GrainRequirementsController(GrainBrokerContext context, ILogger<GrainRequirementsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GrainRequirement>>> GetGrainRequirements()
        {
            return await _context.GrainRequirements
                .Include(r => r.Customer)
                .Include(r => r.Supplier)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GrainRequirement>> GetGrainRequirement(int id)
        {
            var requirement = await _context.GrainRequirements
                .Include(r => r.Customer)
                .Include(r => r.Supplier)
                .FirstOrDefaultAsync(r => r.Id == id);

            if (requirement == null)
            {
                return NotFound();
            }

            return requirement;
        }

        [HttpPost]
        public async Task<ActionResult<GrainRequirement>> CreateGrainRequirement(GrainRequirement requirement)
        {
            _context.GrainRequirements.Add(requirement);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGrainRequirement), new { id = requirement.Id }, requirement);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGrainRequirement(int id, GrainRequirement requirement)
        {
            if (id != requirement.Id)
            {
                return BadRequest();
            }

            _context.Entry(requirement).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GrainRequirementExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrainRequirement(int id)
        {
            var requirement = await _context.GrainRequirements.FindAsync(id);
            if (requirement == null)
            {
                return NotFound();
            }

            _context.GrainRequirements.Remove(requirement);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GrainRequirementExists(int id)
        {
            return _context.GrainRequirements.Any(e => e.Id == id);
        }
    }
}
