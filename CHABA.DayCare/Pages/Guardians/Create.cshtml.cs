using CHABA.DayCare.Models.Guardian;
using CHABA.DayCare.Services.Interfaces;
using CHABA.DayCare.ViewModels.Guardian;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CHABA.DayCare.Pages.Guardians
{
    public class CreateModel : PageModel
    {
        private readonly IGuardianService _guardianService;
        private readonly IChildService _childService;

        public CreateModel(IGuardianService guardianService, IChildService childService)
        {
            _guardianService = guardianService;
            _childService = childService;
        }

        [BindProperty]
        public GuardianCreateViewModel Guardian { get; set; } = new();

        public async Task OnGetAsync()
        {
            await LoadChildren();
        
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid)
            {
                await LoadChildren();
                return Page();
            }

            var guardian = new Guardian
            {
                FirstName = Guardian.FirstName,
                LastName = Guardian.LastName,
                Relationship = Guardian.Relationship,
                PhoneNumber = Guardian.PhoneNumber,
                AlternativePhoneNumber = Guardian.AlternativePhoneNumber,
                Email = Guardian.Email,
                PhysicalAddress = Guardian.PhysicalAddress,
                Occupation = Guardian.Occupation,
                Employer = Guardian.Employer,
                IsPrimaryContact = Guardian.IsPrimaryContact,
                IsEmergencyContact = Guardian.IsEmergencyContact,
                ChildId = Guardian.ChildId
            };

            await _guardianService.CreateGuardianAsync(guardian);
            return RedirectToPage("Index");
        }
        private async Task LoadChildren()
        {
            var children = await _childService.GetAllChildrenAsync();

            Guardian.Children = children.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = $"{c.FirstName} {c.LastName}"
            }).ToList();
        }

      
    }
}
