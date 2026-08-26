using CHABA.DayCare.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CHABA.DayCare.Pages.Reports
{
    public class IndexModel : PageModel
    {
        private readonly IStaffService _staffService;
        public IndexModel(IStaffService staffService)
        {
            _staffService = staffService;
        }

        public int StaffCount { get; set; }

        public async Task OnGetAsync()
        {
            var staff = await _staffService.GetAllStaffAsync();

            StaffCount = staff.Count;
        }
    }
}
