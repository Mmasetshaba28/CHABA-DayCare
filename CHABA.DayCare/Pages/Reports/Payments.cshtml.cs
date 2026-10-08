using CHABA.DayCare.Models.Finance;
using CHABA.DayCare.Services.Interfaces;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CHABA.DayCare.Pages.Reports
{
    public class PaymentsModel : PageModel
    {
        private readonly IPaymentService _paymentService;

        public PaymentsModel(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public List<Payment> Payments { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public DateTime FromDate { get; set; } =
            new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);

        [BindProperty(SupportsGet = true)]
        public DateTime ToDate { get; set; } =
            DateTime.Today;

        public decimal TotalPayments { get; set; }

        public async Task OnGetAsync()
        {
            if (FromDate > ToDate)
            {
                return;
            }

            Payments = await _paymentService.GetPaymentsByDateRangeAsync(
                FromDate,
                ToDate);

            TotalPayments = Payments.Sum(p => p.Amount);
        }

        public async Task<IActionResult> OnPostExportAsync(
            DateTime fromDate,
            DateTime toDate)
        {
            var payments =
                await _paymentService.GetPaymentsByDateRangeAsync(
                    fromDate,
                    toDate);

            using var workbook = new XLWorkbook();

            var worksheet = workbook.Worksheets.Add("Payments");

            worksheet.Cell(1, 1).Value = "Child";
            worksheet.Cell(1, 2).Value = "Amount";
            worksheet.Cell(1, 3).Value = "Payment Date";
            worksheet.Cell(1, 4).Value = "Payment Method";
            worksheet.Cell(1, 5).Value = "Reference";
            worksheet.Cell(1, 6).Value = "Description";

            var row = 2;

            foreach (var payment in payments)
            {
                worksheet.Cell(row, 1).Value =
                    payment.Child != null
                        ? $"{payment.Child.FirstName} {payment.Child.LastName}"
                        : "-";

                worksheet.Cell(row, 2).Value = payment.Amount;

                worksheet.Cell(row, 3).Value =
                    payment.PaymentDate.ToString("dd/MM/yyyy");

                worksheet.Cell(row, 4).Value =
                    payment.PaymentMethod;

                worksheet.Cell(row, 5).Value =
                    payment.ReferenceNumber ?? "-";

                worksheet.Cell(row, 6).Value =
                    payment.Description ?? "-";

                row++;
            }

            worksheet.Cell(row, 1).Value = "TOTAL";
            worksheet.Cell(row, 2).Value = payments.Sum(p => p.Amount);

            worksheet.Columns().AdjustToContents();

            using var stream = new MemoryStream();

            workbook.SaveAs(stream);

            var fileName =
                $"Payments_{fromDate:yyyyMMdd}_to_{toDate:yyyyMMdd}.xlsx";

            return File(
                stream.ToArray(),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                fileName);
        }
    }
}
