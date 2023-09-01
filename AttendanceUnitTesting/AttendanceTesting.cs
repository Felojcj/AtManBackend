using AtManBackend.Controllers;
using AtManBackend.Data;
using AtManBackend.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AttendanceUnitTesting
{
    public class AttendanceTesting
    {
        private readonly AttendancesController _controller;
        private readonly ApplicationDbContext context;

        public AttendanceTesting()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer("server=.;database=AtManDb;integrated security=true; Encrypt=False")
                .Options;
            context = new ApplicationDbContext(options);
            _controller = new AttendancesController(context);
        }

        [Fact]
        public async Task Get_Ok()
        {
            var result = await _controller.Get();

            Assert.IsAssignableFrom<List<Attendance>>(result);
        }

    }
}