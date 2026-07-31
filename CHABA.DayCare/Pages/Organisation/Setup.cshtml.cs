using CHABA.DayCare.Services.Interfaces;
using CHABA.DayCare.ViewModels.Organisation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CHABA.DayCare.Pages.Organisation
{
    public class SetupModel : PageModel
    {
        private readonly IOrganisationService _organisationService;
        public SetupModel(IOrganisationService organisationService)
        {
            _organisationService = organisationService;
        }

        [BindProperty]
        public OrganisationSetupViewModel Organisation { get; set; } = new();

        public async Task<IActionResult> OnGetAsync()
        {
            if (await _organisationService.OrganisationExistsAsync())
            {
                return RedirectToPage("/Index");
            }
            return Page();
        }
    

    public async Task<IActionResult> OnPostAsync()
    {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var organisation = new Models.Core.Organisation
            {
                Name = Organisation.Name,
                RegistrationNumber = Organisation.RegistrationNumber,
                PrincipalName = Organisation.PrincipalName,
                PhoneNumber = Organisation.PhoneNumber,
                Email = Organisation.Email,
                PhysicalAddress = Organisation.PhysicalAddress,
                Motto = Organisation.Motto,
                IsActive = true
            };
            await _organisationService.CreateOrganisationAsync(organisation);
            return RedirectToPage("/Index");
        }
    }
}
