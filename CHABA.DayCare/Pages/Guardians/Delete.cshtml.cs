using CHABA.DayCare.Models.Guardian;
using CHABA.DayCare.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CHABA.DayCare.Pages.Guardians
{
    public class DeleteModel : PageModel
    {
        private readonly IGuardianService _guardianService;

        public DeleteModel(IGuardianService guardianService)
        {
            _guardianService = guardianService;
        }

        public Guardian Guardian { get; set; } = null!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var guardian = await _guardianService.GetGuardianAsync(id);

            if (guardian == null)
            {
                return NotFound();
            }

            Guardian = guardian;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var guardian = await _guardianService.GetGuardianAsync(id);

            if (guardian == null)
            {
                return NotFound();
            }

            await _guardianService.DeleteGuardianAsync(id);

            return RedirectToPage("Index");
        }
    }
}

