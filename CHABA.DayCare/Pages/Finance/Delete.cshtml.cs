using CHABA.DayCare.Models.Finance;
using CHABA.DayCare.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CHABA.DayCare.Pages.Finance
{
    public class DeleteModel : PageModel
    {
        private readonly IPaymentService _paymentService;

        public DeleteModel(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public Payment Payment { get; set; } = null!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var payment = await _paymentService.GetPaymentAsync(id);

            if (payment == null)
            {
                return NotFound();
            }

            Payment = payment;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var payment = await _paymentService.GetPaymentAsync(id);

            if (payment == null)
            {
                return NotFound();
            }

            await _paymentService.DeletePaymentAsync(id);

            return RedirectToPage("Index");
        }
    }
}
