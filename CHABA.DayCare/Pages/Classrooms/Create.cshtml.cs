using CHABA.DayCare.Models.Core;
using CHABA.DayCare.Services.Interfaces;
using CHABA.DayCare.ViewModels.Classroom;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CHABA.DayCare.Pages.Classrooms
{
    public class CreateModel : PageModel
    {
        private readonly IClassroomService _classroomService;
        private readonly IOrganisationService _organisationService;

        public CreateModel(IClassroomService classroomService, IOrganisationService organisationService)
        {
            _classroomService = classroomService;
            _organisationService = organisationService;
        }

        [BindProperty]
        public ClassroomCreateViewModel Classroom { get; set; } = new();

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var organisation = await _organisationService.GetOrganisationAsync();
            if(organisation == null)
            {
                return RedirectToPage("/Organisation/Setup");
            }
            var classroom = new Classroom
            {
                Name = Classroom.Name,
                Description = Classroom.Description,
                MinimumAgeInMonths = Classroom.MinimumAgeInMonths,
                MaximumAgeInMonths = Classroom.MaximumAgeInMonths,
                Capacity = Classroom.Capacity,
                OrganisationId = organisation.Id
            };

            await _classroomService.CreateClassroomAsync(classroom);

            return RedirectToPage("Index");
        }
    }
}
