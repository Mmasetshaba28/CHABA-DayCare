using CHABA.DayCare.Services.Interfaces;
using CHABA.DayCare.ViewModels.Staff;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CHABA.DayCare.Pages.Staff
{
    public class EditModel : PageModel
    {
        private readonly IStaffService _staffService;
        private readonly IClassroomService _classroomService;

        public EditModel(
            IStaffService staffService,
            IClassroomService classroomService)
        {
            _staffService = staffService;
            _classroomService = classroomService;
        }

        [BindProperty]
        public StaffCreateViewModel Staff { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var staff = await _staffService.GetStaffAsync(id);

            if (staff == null)
            {
                return NotFound();
            }

            Staff = new StaffCreateViewModel
            {
                FirstName = staff.FirstName,
                LastName = staff.LastName,
                IDNumber = staff.IDNumber,
                Role = staff.Role,
                Qualification = staff.Qualification,
                PhoneNumber = staff.PhoneNumber,
                AlternativePhoneNumber = staff.AlternativePhoneNumber,
                Email = staff.Email,
                DateJoined = staff.DateJoined,
                ClassroomId = staff.ClassroomId,
                IsActive = staff.IsActive
            };

            await LoadClassrooms();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                await LoadClassrooms();
                return Page();
            }

            var staff = await _staffService.GetStaffAsync(id);

            if (staff == null)
            {
                return NotFound();
            }

            staff.FirstName = Staff.FirstName;
            staff.LastName = Staff.LastName;
            staff.IDNumber = Staff.IDNumber;
            staff.Role = Staff.Role;
            staff.Qualification = Staff.Qualification;
            staff.PhoneNumber = Staff.PhoneNumber;
            staff.AlternativePhoneNumber = Staff.AlternativePhoneNumber;
            staff.Email = Staff.Email;
            staff.DateJoined = Staff.DateJoined;
            staff.ClassroomId = Staff.ClassroomId;
            staff.IsActive = Staff.IsActive;

            await _staffService.UpdateStaffAsync(staff);

            return RedirectToPage("Index");
        }

        private async Task LoadClassrooms()
        {
            var classrooms = await _classroomService.GetAllClassroomsAsync();

            Staff.Classrooms = classrooms
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                })
                .ToList();
        }
    }
}
