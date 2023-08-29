using AtManBackend.Entities;
using Microsoft.EntityFrameworkCore;

namespace AtManBackend.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Attendance> Attendances { get; set; }
    }
}
