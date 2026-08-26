using CHABA.DayCare.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CHABA.DayCare.Models.Staff;

namespace CHABA.DayCare.Pages.Staff
{
    public class IndexModel : PageModel
    {
        private readonly IStaffService _staffService;

        public IndexModel(IStaffService staffService)
        {
            _staffService = staffService;
        }

        public List<Models.Staff.Staff> StaffMembers { get; set; } = new();
        public async Task OnGetAsync()
        {
            StaffMembers = await _staffService.GetAllStaffAsync();
        }
    }
}
