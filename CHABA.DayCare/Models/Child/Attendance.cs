using CHABA.DayCare.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace CHABA.DayCare.Models.Child
{
    public class Attendance : BaseEntity
    {
        [Required]
        public int ChildId { get; set; }

        public Child Child { get; set; } = null!;

        [Required]
        public DateTime Date { get; set; } = DateTime.Today;

        [Required]
        public AttendanceStatus Status { get; set; }

        public TimeSpan? ArrivalTime { get; set; }

        public TimeSpan? DepartureTime { get; set; }

        [StringLength(500)]
        public string? Notes { get; set; }
    }
    public enum AttendanceStatus
    {
        Present,
        Absent,
        Late,
        Excused
    }
}
