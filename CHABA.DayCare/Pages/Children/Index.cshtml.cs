using CHABA.DayCare.Models.Child;
using CHABA.DayCare.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CHABA.DayCare.Pages.Children
{
    public class IndexModel : PageModel
    {
        private readonly IChildService _childService;
        public IndexModel(IChildService childService)
        {
            _childService = childService;
        }

        public List<Child> Children { get; set; } = new();

        public async Task OnGetAsync()
        {
            Children = await _childService.GetAllChildrenAsync();
        }
    }
}
