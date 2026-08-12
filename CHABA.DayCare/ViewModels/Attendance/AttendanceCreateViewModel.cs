using CHABA.DayCare.Models.Child;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace CHABA.DayCare.ViewModels.Attendance
{
    public class AttendanceCreateViewModel
    {
        [Required]
        [Display(Name = "Child")]
        public int ChildId { get; set; }

        public List<SelectListItem> Children { get; set; } = new();

        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.Today;

        [Required]
        public AttendanceStatus Status { get; set; }

        [Display(Name = "Arrival Time")]
        public TimeSpan? ArrivalTime { get; set; }

        [Display(Name = "Departure Time")]
        public TimeSpan? DepartureTime { get; set; }

        [StringLength(500)]
        public string? Notes { get; set; }
    }
}
