using CHABA.DayCare.Repositories.Interfaces;
using CHABA.DayCare.Services.Interfaces;
using CHABA.DayCare.ViewModels.Staff;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CHABA.DayCare.Pages.Staff
{
    public class CreateModel : PageModel
    {
        private readonly IStaffService _staffService;
        private readonly IClassroomService _classroomService;

        public CreateModel(IStaffService staffService, IClassroomService classroomService)
        {
            _staffService = staffService;
            _classroomService = classroomService;
        }

        [BindProperty]
        public StaffCreateViewModel Staff { get; set; } = new();

        public async Task OnGetAsync()
        {
            await LoadClassrooms();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await LoadClassrooms();
                return Page();
            }

            var staff = new Models.Staff.Staff
            {
                FirstName = Staff.FirstName,
                LastName = Staff.LastName,
                IDNumber = Staff.IDNumber,
                Role = Staff.Role,
                Qualification = Staff.Qualification,
                PhoneNumber = Staff.PhoneNumber,
                AlternativePhoneNumber = Staff.AlternativePhoneNumber,
                Email = Staff.Email,
                DateJoined = Staff.DateJoined,
                ClassroomId = Staff.ClassroomId,
                IsActive = Staff.IsActive
            };

            await _staffService.CreateStaffAsync(staff);

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
