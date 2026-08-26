using CHABA.DayCare.Services.Interfaces;
using CHABA.DayCare.ViewModels.Finance;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client;

namespace CHABA.DayCare.Pages.Finance
{
    public class EditModel : PageModel
    {
        private readonly IPaymentService _paymentService;
        private readonly IChildService _childService;

        public EditModel(IPaymentService paymentService, IChildService childService)
        {
            _paymentService = paymentService;
            _childService = childService;
        }

        [BindProperty]
        public PaymentCreateViewModel Payment { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var payment = await _paymentService.GetPaymentAsync(id);
            if(payment == null)
            {
                return NotFound();
            }

            Payment = new PaymentCreateViewModel
            {
                ChildId = payment.ChildId,
                Amount = payment.Amount,
                PaymentDate = payment.PaymentDate,
                PaymentMethod = payment.PaymentMethod,
                ReferenceNumber = payment.ReferenceNumber,
                Description = payment.Description,
                Notes = payment.Notes
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

            var payment = await _paymentService.GetPaymentAsync(id);
            if(payment == null)
            {
                return NotFound();
            }

            payment.ChildId = Payment.ChildId;
            payment.Amount = Payment.Amount;
            payment.PaymentDate = Payment.PaymentDate;
            payment.PaymentMethod = Payment.PaymentMethod;
            payment.ReferenceNumber = Payment.ReferenceNumber;
            payment.Description = Payment.Description;
            payment.Notes = Payment.Notes;

            await _paymentService.UpdatePaymentAsync(payment);
            return RedirectToPage("Index");
        }

        private async Task LoadChildren()
        {
            var children = await _childService.GetAllChildrenAsync();
            Payment.Children = children.Select(c => new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
            {
                Value = c.Id.ToString(),
                Text = $"{c.FirstName} {c.LastName}"
            }).ToList();

        }
    }
}
