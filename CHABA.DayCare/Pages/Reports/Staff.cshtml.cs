using CHABA.DayCare.Models.Staff;
using CHABA.DayCare.Services.Interfaces;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CHABA.DayCare.Pages.Reports
{
    public class StaffModel : PageModel
    {
        private readonly IStaffService _staffService;
        public StaffModel(IStaffService staffService)
        {
            _staffService = staffService;
        }

        public List<CHABA.DayCare.Models.Staff.Staff> StaffMembers { get; set; } = new();

        public async Task OnGetAsync()
        {
            StaffMembers = await _staffService.GetAllStaffAsync();
        }

        public async Task<IActionResult> OnPostExportAsync()
        {
            var staffMembers = await _staffService.GetAllStaffAsync();

            using var workbook = new XLWorkbook();

            var worksheet = workbook.Worksheets.Add("Staff Details");

            worksheet.Cell(1, 1).Value = "Staff Member";
            worksheet.Cell(1, 2).Value = "ID Number";
            worksheet.Cell(1, 3).Value = "Role";
            worksheet.Cell(1, 4).Value = "Qualification";
            worksheet.Cell(1, 5).Value = "Phone Number";
            worksheet.Cell(1, 6).Value = "Email";
            worksheet.Cell(1, 7).Value = "Date Joined";
            worksheet.Cell(1, 8).Value = "Status";

            var row = 2;

            foreach (var staff in staffMembers)
            {
                worksheet.Cell(row, 1).Value =
                    $"{staff.FirstName} {staff.LastName}";

                worksheet.Cell(row, 2).Value = staff.IDNumber;
                worksheet.Cell(row, 3).Value = staff.Role;
                worksheet.Cell(row, 4).Value =
                    staff.Qualification ?? "-";
                worksheet.Cell(row, 5).Value = staff.PhoneNumber;
                worksheet.Cell(row, 6).Value =
                    staff.Email ?? "-";

                worksheet.Cell(row, 7).Value =
                    staff.DateJoined.ToString("dd/MM/yyyy");

                worksheet.Cell(row, 8).Value =
                    staff.IsActive ? "Active" : "Inactive";

                row++;
            }

            worksheet.Columns().AdjustToContents();

            using var stream = new MemoryStream();

            workbook.SaveAs(stream);

            var fileName =
                $"Staff_Details_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

            return File(
                stream.ToArray(),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                fileName);
        }
    }
}
