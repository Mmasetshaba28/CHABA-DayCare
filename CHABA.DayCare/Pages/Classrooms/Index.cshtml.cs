using CHABA.DayCare.Services.Interfaces;
using CHABA.DayCare.ViewModels.Classroom;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CHABA.DayCare.Pages.Classrooms
{
    public class IndexModel : PageModel
    {
        private readonly IClassroomService _classroomService;

        public IndexModel(IClassroomService classroomService)
        {
            _classroomService = classroomService;
        }

        public List<ClassroomListViewModel> Classrooms { get; set; } = new();

        public async Task OnGetAsync()
        {
            var classrooms =  await _classroomService.GetAllClassroomsAsync();

            Classrooms = classrooms.Select(c => new ClassroomListViewModel
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                MinimumAgeInMonths = c.MinimumAgeInMonths,
                MaximumAgeInMonths = c.MaximumAgeInMonths,
                Capacity = c.Capacity
            }).ToList();
        }
    }
}
