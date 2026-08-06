using CHABA.DayCare.Services.Interfaces;
using CHABA.DayCare.ViewModels.Child;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CHABA.DayCare.Pages.Children
{
    public class EditModel : PageModel
    {
        private readonly IChildService _childService;
        private readonly IClassroomService _classroomService;

        public EditModel(IChildService childService, IClassroomService classroomService)
        {
            _childService = childService;
            _classroomService = classroomService;
        }

        [BindProperty]
        public ChildCreateViewModel Child { get; set; } = new();

        [BindProperty]
        public int Id { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var child = await _childService.GetChildAsync(id);

            if(child == null)
            {
                return NotFound();
            }

            Id = child.Id;


            Child = new ChildCreateViewModel
            {
                FirstName = child.FirstName,
                LastName = child.LastName,
                DateOfBirth = child.DateOfBirth,
                AdmissionDate = child.AdmissionDate,
                Gender = child.Gender,
                Allergies = child.Allergies,
                MedicalConditions = child.MedicalConditions,
                DoctorName = child.DoctorName,
                DoctorPhone = child.DoctorPhone,
                ClassroomId = child.ClassroomId
            };

            await LoadClassrooms();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await LoadClassrooms();

            if (!ModelState.IsValid)
                return Page();

            var child = await _childService.GetChildAsync(Id);

            if (child == null)
                return NotFound();

            child.FirstName = Child.FirstName;
            child.LastName = Child.LastName;
            child.DateOfBirth = Child.DateOfBirth;
            child.AdmissionDate = Child.AdmissionDate;
            child.Gender = Child.Gender;
            child.Allergies = Child.Allergies;
            child.MedicalConditions = Child.MedicalConditions;
            child.DoctorName = Child.DoctorName;
            child.DoctorPhone = Child.DoctorPhone;
            child.ClassroomId = Child.ClassroomId;

            await _childService.UpdateChildAsync(child);

            return RedirectToPage("Index");
        }
        private async Task LoadClassrooms()
        {
            var classrooms = await _classroomService.GetAllClassroomsAsync();

            Child.Classrooms = classrooms.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();
        }
    }
}
