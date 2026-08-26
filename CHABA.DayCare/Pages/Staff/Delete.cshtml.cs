using CHABA.DayCare.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CHABA.DayCare.Pages.Staff
{
    public class DeleteModel : PageModel
    {
        private readonly IStaffService _staffService;

        public DeleteModel(IStaffService staffService)
        {
            _staffService = staffService;
        }

        public Models.Staff.Staff Staff { get; set; } = null!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var staff = await _staffService.GetStaffAsync(id);

            if (staff == null)
            {
                return NotFound();
            }

            Staff = staff;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var staff = await _staffService.GetStaffAsync(id);

            if (staff == null)
            {
                return NotFound();
            }

            await _staffService.DeleteStaffAsync(id);

            return RedirectToPage("Index");
        }
    }
}
