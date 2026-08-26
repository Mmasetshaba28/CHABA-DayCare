using CHABA.DayCare.Repositories.Interfaces;
using CHABA.DayCare.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CHABA.DayCare.Pages.Finance
{
    public class IndexModel : PageModel
    {
        private readonly IPaymentService _paymentService;
        
        public IndexModel(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public List<Models.Finance.Payment> Payments { get; set; } = new();
        public async Task OnGetAsync()
        {
            Payments = await _paymentService.GetAllPaymentsAsync();
        }

    }
}
