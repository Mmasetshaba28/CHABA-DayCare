using CHABA.DayCare.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CHABA.DayCare.Pages.Attendance
{
    public class IndexModel : PageModel
    {
        private readonly IAttendanceService _attendanceService;

        public IndexModel(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        public List<Models.Child.Attendance> AttendanceRecords { get; set; } = new();

        public async Task OnGetAsync()
        {
            AttendanceRecords = await _attendanceService.GetAllAttendanceAsync();
        }
    }
}
