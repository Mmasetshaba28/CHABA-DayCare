using CHABA.DayCare.Services.Implementations;
using CHABA.DayCare.Services.Interfaces;
using CHABA.DayCare.ViewModels.Dashboard;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CHABA.DayCare.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IOrganisationService _organisationService;
        private readonly IDashboardService _dashboardService;

        public IndexModel(
            IOrganisationService organisationService,
            IDashboardService dashboardService)
        {
            _organisationService = organisationService;
            _dashboardService = dashboardService;
        }

        public DashboardViewModel Dashboard { get; set; } = new();

        public async Task<IActionResult> OnGetAsync()
        {
            if (!await _organisationService.OrganisationExistsAsync())
            {
                return RedirectToPage("/Organisation/Setup");
            }

            Dashboard = await _dashboardService.GetDashboardAsync();

            return Page();
        }
    }
}
