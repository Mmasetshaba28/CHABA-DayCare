using CHABA.DayCare.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CHABA.DayCare.ViewModels.Child;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CHABA.DayCare.Pages.Children
{
    public class CreateModel : PageModel
    {
        private readonly IChildService _childService;
        private readonly IClassroomService _classroomService;
        private readonly IOrganisationService _organisationService;

        public CreateModel(IChildService childService, IClassroomService classroomService, IOrganisationService organisationService)
        {
            _childService = childService;
            _classroomService = classroomService;
            _organisationService = organisationService;
        }

        [BindProperty]
        public ChildCreateViewModel Child { get; set; } = new();

        public async Task OnGetAsync()
        {
            await LoadClassrooms();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await LoadClassrooms();

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var organisation = await _organisationService.GetOrganisationAsync();

            if (organisation == null)
                return RedirectToPage("/Organisation/Setup");

            var child = new Models.Child.Child
            {
                FirstName = Child.FirstName,
                LastName = Child.LastName,
                DateOfBirth = Child.DateOfBirth,
                AdmissionDate = Child.AdmissionDate,
                Gender = Child.Gender,
                Allergies = Child.Allergies,
                MedicalConditions = Child.MedicalConditions,
                DoctorName = Child.DoctorName,
                DoctorPhone = Child.DoctorPhone,
                ClassroomId = Child.ClassroomId,
                OrganisationId = organisation.Id
            };

            await _childService.CreateChildAsync(child);
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
