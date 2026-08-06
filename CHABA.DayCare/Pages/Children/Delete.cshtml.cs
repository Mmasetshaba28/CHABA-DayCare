using CHABA.DayCare.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CHABA.DayCare.Pages.Children
{
    public class DeleteModel : PageModel
    {
        private readonly IChildService _childService;

        public DeleteModel(IChildService childService)
        {
            _childService = childService;
        }

        public string ChildName { get; set; } = string.Empty;

        [BindProperty]
        public int Id { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var child = await _childService.GetChildAsync(id);

            if(child == null)
            {
                return NotFound();
            }
            Id = child.Id;
            ChildName = $"{child.FirstName} {child.LastName}"; 
            
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _childService.DeleteChildAsync(Id);
            return RedirectToPage("/Children/Index");
        }
    }
}
