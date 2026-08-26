using CHABA.DayCare.Repositories.Interfaces;
using CHABA.DayCare.Services.Interfaces;
using CHABA.DayCare.ViewModels.Dashboard;

namespace CHABA.DayCare.Services.Implementations
{
    public class DashboardService : IDashboardService
    {
        private readonly IOrganisationRepository _organisationRepository;
        private readonly IChildService _childService;
        private readonly IClassroomService _classroomService;
        private readonly IStaffService _staffService;
        private readonly IGuardianService _guardianService;
        private readonly IAttendanceService _attendanceService;
        private readonly IPaymentService _paymentService;
        public DashboardService(IOrganisationRepository organisationRepository,
            IChildService childService,
            IClassroomService classroomService,
            IStaffService staffService,
            IGuardianService guardianService,
            IAttendanceService attendanceService, IPaymentService paymentService)
        {
            _organisationRepository = organisationRepository;
            _childService = childService;
            _classroomService = classroomService;
            _staffService = staffService;
            _guardianService = guardianService;
            _attendanceService = attendanceService;
            _paymentService = paymentService;
        }

        public async Task<DashboardViewModel> GetDashboardAsync()
        {
            var organisation = await _organisationRepository.GetAsync();

            var children = await _childService.GetAllChildrenAsync();
            var classrooms = await _classroomService.GetAllClassroomsAsync();
            var staff = await _staffService.GetAllStaffAsync();
            var guardians = await _guardianService.GetAllGuardiansAsync();
            var attendanceRecords = await _attendanceService.GetAllAttendanceAsync();
            var payments = await _paymentService.GetAllPaymentsAsync();
            var today = DateTime.Today;

            var paymentsToday = payments.Where(p => p.PaymentDate.Date == today).Sum(p => p.Amount);
            var paymentsThisMonth = payments.Where(p => p.PaymentDate.Year == today.Year && p.PaymentDate.Month == today.Month).Sum(p => p.Amount);

            var todayAttendance = attendanceRecords
                .Where(a => a.Date.Date == DateTime.Today)
                .ToList();
            var presentToday = todayAttendance.Count(a =>
    a.Status == Models.Child.AttendanceStatus.Present);

            var absentToday = todayAttendance.Count(a =>
                a.Status == Models.Child.AttendanceStatus.Absent);

            var lateToday = todayAttendance.Count(a =>
                a.Status == Models.Child.AttendanceStatus.Late);

            var excusedToday = todayAttendance.Count(a =>
                a.Status == Models.Child.AttendanceStatus.Excused);

            var notRecordedToday = children.Count - todayAttendance.Count;

            return new DashboardViewModel
            {
                OrganisationName = organisation?.Name ?? "",
                Motto = organisation?.Motto,

                ChildrenCount = children.Count,
                ClassroomCount = classrooms.Count,
                TeacherCount = staff.Count(s => s.Role.Equals("Teacher", StringComparison.OrdinalIgnoreCase)),
                StaffCount = staff.Count,
                ParentCount = guardians.Count,
                PresentToday = presentToday,
                AbsentToday = absentToday,
                LateToday = lateToday,
                ExcusedToday = excusedToday,
                NotRecordedToday = notRecordedToday,
                PaymentsToday = paymentsToday,
                PaymentsThisMonth = paymentsThisMonth
            };
        }
    }
}
