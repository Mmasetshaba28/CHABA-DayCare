using CHABA.DayCare.Models.Guardian;
using CHABA.DayCare.Services.Interfaces;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CHABA.DayCare.Pages.Reports
{
    public class GuardiansModel : PageModel
    {
        private readonly IGuardianService _guardianService;
        public GuardiansModel(IGuardianService guardianService)
        {
            _guardianService = guardianService;
        }

        public List<Guardian> Guardians { get; set; } = new();

        public async Task OnGetAsync()
        {
            Guardians = await _guardianService.GetAllGuardiansAsync();
        }

        public async Task<IActionResult> OnPostExportAsync()
        {
            var guardians = await _guardianService.GetAllGuardiansAsync();

            using var workbook = new XLWorkbook();

            var worksheet = workbook.Worksheets.Add("Guardian Details");

            worksheet.Cell(1, 1).Value = "Guardian Name";
            worksheet.Cell(1, 2).Value = "Child";
            worksheet.Cell(1, 3).Value = "Relationship";
            worksheet.Cell(1, 4).Value = "Phone Number";
            worksheet.Cell(1, 5).Value = "Alternative Phone";
            worksheet.Cell(1, 6).Value = "Email";
            worksheet.Cell(1, 7).Value = "Physical Address";
            worksheet.Cell(1, 8).Value = "Occupation";
            worksheet.Cell(1, 9).Value = "Employer";
            worksheet.Cell(1, 10).Value = "Primary Contact";
            worksheet.Cell(1, 11).Value = "Emergency Contact";

            var row = 2;

            foreach (var guardian in guardians)
            {
                worksheet.Cell(row, 1).Value =
                    $"{guardian.FirstName} {guardian.LastName}";

                worksheet.Cell(row, 2).Value =
                    guardian.Child != null
                        ? $"{guardian.Child.FirstName} {guardian.Child.LastName}"
                        : "-";

                worksheet.Cell(row, 3).Value =
                    guardian.Relationship;

                worksheet.Cell(row, 4).Value =
                    guardian.PhoneNumber;

                worksheet.Cell(row, 5).Value =
                    guardian.AlternativePhoneNumber ?? "-";

                worksheet.Cell(row, 6).Value =
                    guardian.Email ?? "-";

                worksheet.Cell(row, 7).Value =
                    guardian.PhysicalAddress ?? "-";

                worksheet.Cell(row, 8).Value =
                    guardian.Occupation ?? "-";

                worksheet.Cell(row, 9).Value =
                    guardian.Employer ?? "-";

                worksheet.Cell(row, 10).Value =
                    guardian.IsPrimaryContact ? "Yes" : "No";

                worksheet.Cell(row, 11).Value =
                    guardian.IsEmergencyContact ? "Yes" : "No";

                row++;
            }

            worksheet.Columns().AdjustToContents();

            using var stream = new MemoryStream();

            workbook.SaveAs(stream);

            var fileName =
                $"Guardian_Details_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

            return File(
                stream.ToArray(),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                fileName);
        }
    }
}
