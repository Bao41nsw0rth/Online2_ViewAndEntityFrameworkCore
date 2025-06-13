using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Online2.Data;

namespace Online2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentsPerDeviceController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AssignmentsPerDeviceController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAssignmentsPerDevice()
        {
            await _context.Database.ExecuteSqlRawAsync("REFRESH MATERIALIZED VIEW view_assignments_per_device;");
            var data = await _context.AssignmentsPerDevice.ToListAsync();
            return Ok(data);
        }
    }
}
