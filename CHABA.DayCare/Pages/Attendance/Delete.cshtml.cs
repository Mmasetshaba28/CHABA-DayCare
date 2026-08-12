using CHABA.DayCare.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CHABA.DayCare.Pages.Attendance
{
    public class DeleteModel : PageModel
    {
        private readonly IAttendanceService _attendanceService;

        public DeleteModel(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        public CHABA.DayCare.Models.Child.Attendance Attendance { get; set; } = null!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var attendance = await _attendanceService.GetAttendanceAsync(id);

            if (attendance == null)
            {
                return NotFound();
            }

            Attendance = attendance;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var attendance = await _attendanceService.GetAttendanceAsync(id);

            if (attendance == null)
            {
                return NotFound();
            }

            attendance.IsDeleted = true;

            await _attendanceService.UpdateAttendanceAsync(attendance);

            return RedirectToPage("Index");
        }
    }
}
