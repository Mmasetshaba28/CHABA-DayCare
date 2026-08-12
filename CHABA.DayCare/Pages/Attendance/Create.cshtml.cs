using CHABA.DayCare.Services.Interfaces;
using CHABA.DayCare.ViewModels.Attendance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CHABA.DayCare.Pages.Attendance
{
    public class CreateModel : PageModel
    {
        private readonly IAttendanceService _attendanceService;
        private readonly IChildService _childService;

        public CreateModel(IAttendanceService attendanceService, IChildService childService)
        {
            _attendanceService = attendanceService;
            _childService = childService;
        }

        [BindProperty]
        public AttendanceCreateViewModel Attendance { get; set; } = new();

        public async Task OnGetAsync()
        {
            await LoadChildren();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await LoadChildren();
                return Page();
            }

            var attendance = new Models.Child.Attendance
            {
                ChildId = Attendance.ChildId,
                Date = Attendance.Date,
                Status = Attendance.Status,
                ArrivalTime = Attendance.ArrivalTime,
                DepartureTime = Attendance.DepartureTime,
                Notes = Attendance.Notes

            };

            await _attendanceService.CreateAttendanceAsync(attendance);
            return RedirectToPage("Index");
        }
        private async Task LoadChildren()
        {
            var children = await _childService.GetAllChildrenAsync();
            Attendance.Children = children.Select(c => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Value = c.Id.ToString(),
                Text = $"{c.FirstName} {c.LastName}"
            }).ToList();
        }
    }
}
