using System.ComponentModel.DataAnnotations;

namespace AtManBackend.Entities
{
    public class Attendance
    {
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }
    }
}
