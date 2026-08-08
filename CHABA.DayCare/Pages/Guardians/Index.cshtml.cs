using CHABA.DayCare.Models.Guardian;
using CHABA.DayCare.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CHABA.DayCare.Pages.Guardians
{
    public class IndexModel : PageModel
    {
        private readonly IGuardianService _guardianService;
        public IndexModel(IGuardianService guardianService)
        {
            _guardianService = guardianService;
        }

        public List<Guardian> Guardians { get; set; } = new();

        public async Task OnGetAsync()
        {
            Guardians = await _guardianService.GetAllGuardiansAsync();
            
        }
    }
}
