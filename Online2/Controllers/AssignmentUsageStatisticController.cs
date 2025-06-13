using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Online2.Data;

namespace Online2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentUsageStatisticController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AssignmentUsageStatisticController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsageStats()
        {
            await _context.Database.ExecuteSqlRawAsync("REFRESH MATERIALIZED VIEW view_assignment_usage_statistics;");
            var data = await _context.AssignmentUsageStatistics.FirstOrDefaultAsync();
            return Ok(data);
        }
    }
}
