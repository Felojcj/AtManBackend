using AtManBackend.Data;
using AtManBackend.DTO;
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

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Attendance>> Get(int id)
        {
            var attendance = await context.Attendances.FirstOrDefaultAsync(x => x.Id == id);

            if (attendance == null)
            {
                return NotFound($"The worker with the id {id} does not exist.");
            }

            return Ok(attendance);

        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AttendanceDTO attendanceDTO)
        {
            if (attendanceDTO.EndDate <= attendanceDTO.StartDate)
            {
                return BadRequest("End date must be greater than start date.");
            }

            var attendance = new Attendance 
            {
                Name = attendanceDTO.Name,
                StartDate = attendanceDTO.StartDate, 
                EndDate = attendanceDTO.EndDate,
            };

            context.Add(attendance);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] AttendanceDTO attendanceDTO)
        {
            var attendance = await context.Attendances.FirstOrDefaultAsync(x => x.Id == id);

            if (attendance == null)
            {
                return NotFound("The worker does not exists");
            }

            attendance.Name = attendanceDTO.Name;
            attendance.StartDate = attendanceDTO.StartDate;
            attendance.EndDate = attendanceDTO.EndDate;

            context.Attendances.Update(attendance);
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var attendance = await context.Attendances.FirstOrDefaultAsync(x => x.Id == id);

            if(attendance == null) 
            { 
                return NotFound("The worker does not exists"); 
            }

            context.Attendances.Remove(attendance);
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}
