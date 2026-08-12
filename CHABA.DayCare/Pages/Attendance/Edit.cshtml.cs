using CHABA.DayCare.Repositories.Interfaces;
using CHABA.DayCare.Services.Interfaces;
using CHABA.DayCare.ViewModels.Attendance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CHABA.DayCare.Pages.Attendance
{
    public class EditModel : PageModel
    {
        private readonly IAttendanceService _attendanceService;
        private readonly IChildService _childService;

        public EditModel(
            IAttendanceService attendanceService,
            IChildService childService)
        {
            _attendanceService = attendanceService;
            _childService = childService;
        }

        [BindProperty]
        public AttendanceCreateViewModel AttendanceModel { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var attendance = await _attendanceService.GetAttendanceAsync(id);

            if (attendance == null)
            {
                return NotFound();
            }

            AttendanceModel = new AttendanceCreateViewModel
            {
                ChildId = attendance.ChildId,
                Date = attendance.Date,
                Status = attendance.Status,
                ArrivalTime = attendance.ArrivalTime,
                DepartureTime = attendance.DepartureTime,
                Notes = attendance.Notes
            };

            await LoadChildren();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                await LoadChildren();
                return Page();
            }

            var attendance = await _attendanceService.GetAttendanceAsync(id);

            if (attendance == null)
            {
                return NotFound();
            }

            attendance.ChildId = AttendanceModel.ChildId;
            attendance.Date = AttendanceModel.Date;
            attendance.Status = AttendanceModel.Status;
            attendance.ArrivalTime = AttendanceModel.ArrivalTime;
            attendance.DepartureTime = AttendanceModel.DepartureTime;
            attendance.Notes = AttendanceModel.Notes;

            await _attendanceService.UpdateAttendanceAsync(attendance);

            return RedirectToPage("Index");
        }

        private async Task LoadChildren()
        {
            var children = await _childService.GetAllChildrenAsync();

            AttendanceModel.Children = children
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = $"{c.FirstName} {c.LastName}"
                })
                .ToList();
        }
    }
}
