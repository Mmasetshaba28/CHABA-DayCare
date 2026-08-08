using CHABA.DayCare.Services.Interfaces;
using CHABA.DayCare.ViewModels.Guardian;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CHABA.DayCare.Pages.Guardians
{
    public class EditModel : PageModel
    {
        private readonly IGuardianService _guardianService;
        private readonly IChildService _childService;

        public EditModel(IGuardianService guardianService, IChildService childService)
        {
            _guardianService = guardianService;
            _childService = childService;
        }

        [BindProperty]
        public GuardianCreateViewModel Guardian { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var guardian = await _guardianService.GetGuardianAsync(id);

            if (guardian == null)
            {
                return NotFound();
            }

            Guardian = new GuardianCreateViewModel
            {
                FirstName = guardian.FirstName,
                LastName = guardian.LastName,
                Relationship = guardian.Relationship,
                PhoneNumber = guardian.PhoneNumber,
                AlternativePhoneNumber = guardian.AlternativePhoneNumber,
                Email = guardian.Email,
                PhysicalAddress = guardian.PhysicalAddress,
                Occupation = guardian.Occupation,
                Employer = guardian.Employer,
                IsPrimaryContact = guardian.IsPrimaryContact,
                IsEmergencyContact = guardian.IsEmergencyContact,
                ChildId = guardian.ChildId
            };

            await LoadChildren();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                await LoadChildren();
                return Page();
            }

            var guardian = await _guardianService.GetGuardianAsync(id);

            if (guardian == null)
            {
                return NotFound();
            }

            guardian.FirstName = Guardian.FirstName;
            guardian.LastName = Guardian.LastName;
            guardian.Relationship = Guardian.Relationship;
            guardian.PhoneNumber = Guardian.PhoneNumber;
            guardian.AlternativePhoneNumber = Guardian.AlternativePhoneNumber;
            guardian.Email = Guardian.Email;
            guardian.PhysicalAddress = Guardian.PhysicalAddress;
            guardian.Occupation = Guardian.Occupation;
            guardian.Employer = Guardian.Employer;
            guardian.IsPrimaryContact = Guardian.IsPrimaryContact;
            guardian.IsEmergencyContact = Guardian.IsEmergencyContact;
            guardian.ChildId = Guardian.ChildId;

            await _guardianService.UpdateGuardianAsync(guardian);

            return RedirectToPage("Index");
        }

        private async Task LoadChildren()
        {
            var children = await _childService.GetAllChildrenAsync();

            Guardian.Children = children
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = $"{c.FirstName} {c.LastName}"
                })
                .ToList();
        }
    }
}
