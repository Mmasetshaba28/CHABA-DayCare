using CHABA.DayCare.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CHABA.DayCare.Pages.Attendance
{
    public class IndexModel : PageModel
    {
        private readonly IAttendanceService _attendanceService;
        private readonly IChildService _childService;

        public IndexModel(IAttendanceService attendanceService, IChildService childService)
        {
            _attendanceService = attendanceService;
            _childService = childService;
        }

        public List<Models.Child.Attendance> AttendanceRecords { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public DateTime SelectedDate { get; set; } = DateTime.Today;

        public async Task OnGetAsync()
        {
            AttendanceRecords =
                await _attendanceService.GetAttendanceByDateAsync(SelectedDate);

            var children =
                await _childService.GetAllChildrenAsync();

            PresentCount = AttendanceRecords.Count(a =>
                a.Status == Models.Child.AttendanceStatus.Present);

            AbsentCount = AttendanceRecords.Count(a =>
                a.Status == Models.Child.AttendanceStatus.Absent);

            LateCount = AttendanceRecords.Count(a =>
                a.Status == Models.Child.AttendanceStatus.Late);

            ExcusedCount = AttendanceRecords.Count(a =>
                a.Status == Models.Child.AttendanceStatus.Excused);

            NotRecordedCount =
                Math.Max(0, children.Count - AttendanceRecords.Count);
        }

        public int PresentCount { get; set; }
        public int AbsentCount { get; set; }
        public int LateCount { get; set; }
        public int ExcusedCount { get; set; }
        public int NotRecordedCount { get; set; }
    }
}
