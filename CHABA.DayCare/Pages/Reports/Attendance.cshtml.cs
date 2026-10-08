using CHABA.DayCare.Services.Interfaces;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace CHABA.DayCare.Pages.Reports
{
    public class AttendanceModel : PageModel
    {
        private readonly IAttendanceService _attendanceService;

        public AttendanceModel(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        public List<Models.Child.Attendance> AttendanceRecords { get; set; } = new();

        [BindProperty(SupportsGet = true)]

        public DateTime SelectedDate { get; set; } = DateTime.Today;

        public async Task OnGetAsync()
        {
            AttendanceRecords = await _attendanceService.GetAttendanceByDateAsync(SelectedDate);
        }

        public async Task<IActionResult> OnPostExportAsync(DateTime selectedDate)
        {
            var attendanceRecords =
                await _attendanceService.GetAttendanceByDateAsync(selectedDate);

            using var workbook = new XLWorkbook();

            var worksheet = workbook.Worksheets.Add("Attendance");

            worksheet.Cell(1, 1).Value = "Child Name";
            worksheet.Cell(1, 2).Value = "Date";
            worksheet.Cell(1, 3).Value = "Status";
            worksheet.Cell(1, 4).Value = "Arrival Time";
            worksheet.Cell(1, 5).Value = "Departure Time";
            worksheet.Cell(1, 6).Value = "Notes";

            var row = 2;

            foreach (var attendance in attendanceRecords)
            {
                worksheet.Cell(row, 1).Value =
                    attendance.Child != null
                        ? $"{attendance.Child.FirstName} {attendance.Child.LastName}"
                        : "-";

                worksheet.Cell(row, 2).Value =
                    attendance.Date.ToString("dd/MM/yyyy");

                worksheet.Cell(row, 3).Value =
                    attendance.Status.ToString();

                worksheet.Cell(row, 4).Value =
                    attendance.ArrivalTime?.ToString(@"hh\:mm") ?? "-";

                worksheet.Cell(row, 5).Value =
                    attendance.DepartureTime?.ToString(@"hh\:mm") ?? "-";

                worksheet.Cell(row, 6).Value =
                    attendance.Notes ?? "-";

                row++;
            }

            worksheet.Columns().AdjustToContents();

            using var stream = new MemoryStream();

            workbook.SaveAs(stream);

            var fileName =
                $"Attendance_{selectedDate:yyyyMMdd}.xlsx";

            return File(
                stream.ToArray(),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                fileName);
        }

    }
}
