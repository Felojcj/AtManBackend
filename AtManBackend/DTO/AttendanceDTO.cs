using System.ComponentModel.DataAnnotations;

namespace AtManBackend.DTO
{
    public class AttendanceDTO
    {
        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }
    }
}
