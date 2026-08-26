using CHABA.DayCare.Models.Finance;
using CHABA.DayCare.Services.Interfaces;
using CHABA.DayCare.ViewModels.Finance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CHABA.DayCare.Pages.Finance
{
    public class CreateModel : PageModel
    {
        private readonly IPaymentService _paymentService;
        private readonly IChildService _childService;

        public CreateModel(IPaymentService paymentService, IChildService childService)
        {
            _paymentService = paymentService;
            _childService = childService;
        }

        [BindProperty]
        public PaymentCreateViewModel Payment { get; set; } = new();

        public async Task OnGetAsync()
        {
            await LoadChildren();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await LoadChildren();
                return Page();
            }

            var payment = new Payment
            {
                ChildId = Payment.ChildId,
                Amount = Payment.Amount,
                PaymentDate = Payment.PaymentDate,
                PaymentMethod = Payment.PaymentMethod,
                ReferenceNumber = Payment.ReferenceNumber,
                Description = Payment.Description,
                Notes = Payment.Notes
            };

            await _paymentService.CreatePaymentAsync(payment);
            return RedirectToPage("Index");
        }

        private async Task LoadChildren()
        {
            var children = await _childService.GetAllChildrenAsync();
            Payment.Children = children.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = $"{c.FirstName} {c.LastName}"
            }).ToList();
        }
    }
}
