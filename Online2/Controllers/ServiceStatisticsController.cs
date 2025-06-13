using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Online2.Data;

namespace Online2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceStatisticsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ServiceStatisticsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetServiceStats()
        {
            await _context.Database.ExecuteSqlRawAsync("REFRESH MATERIALIZED VIEW view_service_statistics;");
            var data = await _context.ServiceStatistics.ToListAsync();
            return Ok(data);
        }
    }
}
