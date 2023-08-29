using AtManBackend.Data;
using AtManBackend.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AtManBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AttendancesController: ControllerBase
    {
        private readonly ApplicationDbContext context;

        public AttendancesController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<List<Attendance>> Get()
        {
            return await context.Attendances.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Attendance attendance)
        {
            context.Add(attendance);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
