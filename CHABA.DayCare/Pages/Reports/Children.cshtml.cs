using CHABA.DayCare.Models.Child;
using CHABA.DayCare.Services.Interfaces;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CHABA.DayCare.Pages.Reports
{
    public class ChildrenModel : PageModel
    {
        private readonly IChildService _childService;
        public ChildrenModel(IChildService childService)
        {
            _childService = childService;
        }

        public List<Child> Children { get; set; } = new();

        public async Task OnGetAsync()
        {
            Children = await _childService.GetAllChildrenAsync();
        }

        public async Task<IActionResult> OnPostExportAsync()
        {
            var children = await _childService.GetAllChildrenAsync();

            using var workbook = new XLWorkbook();

            var worksheet = workbook.Worksheets.Add("Children Details");

            worksheet.Cell(1, 1).Value = "Child Name";
            worksheet.Cell(1, 2).Value = "Date of Birth";
            worksheet.Cell(1, 3).Value = "Admission Date";
            worksheet.Cell(1, 4).Value = "Gender";
            worksheet.Cell(1, 5).Value = "Classroom";
            worksheet.Cell(1, 6).Value = "Status";
            worksheet.Cell(1, 7).Value = "Allergies";
            worksheet.Cell(1, 8).Value = "Medical Conditions";
            worksheet.Cell(1, 9).Value = "Doctor Name";
            worksheet.Cell(1, 10).Value = "Doctor Phone";

            var row = 2;

            foreach (var child in children)
            {
                worksheet.Cell(row, 1).Value = $"{child.FirstName} {child.LastName}";

                worksheet.Cell(row, 2).Value =
                    child.DateOfBirth.ToString("dd/MM/yyyy");

                worksheet.Cell(row, 3).Value =
                    child.AdmissionDate.ToString("dd/MM/yyyy");

                worksheet.Cell(row, 4).Value =
                    child.Gender.ToString();

                worksheet.Cell(row, 5).Value =
                    child.Classroom?.Name ?? "-";

                worksheet.Cell(row, 6).Value =
                    child.Status.ToString();

                worksheet.Cell(row, 7).Value =
                    child.Allergies ?? "-";

                worksheet.Cell(row, 8).Value =
                    child.MedicalConditions ?? "-";

                worksheet.Cell(row, 9).Value =
                    child.DoctorName ?? "-";

                worksheet.Cell(row, 10).Value =
                    child.DoctorPhone ?? "-";

                row++;
            }

            worksheet.Columns().AdjustToContents();

            using var stream = new MemoryStream();

            workbook.SaveAs(stream);

            var fileName =
                $"Children_Details_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

            return File(
                stream.ToArray(),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                fileName);
        }
    }
}
