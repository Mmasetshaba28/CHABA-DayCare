namespace CHABA.DayCare.ViewModels.Dashboard
{
    public class DashboardViewModel
    {
        public string OrganisationName { get; set; } = string.Empty;

        public string? Motto { get; set; }

        public int ChildrenCount { get; set; }

        public int ClassroomCount { get; set; }

        public int TeacherCount { get; set; }

        public int StaffCount { get; set; }

        public int ParentCount { get; set; }

        public int PresentToday { get; set; }

        public int AbsentToday { get; set; }

        public int LateToday { get; set; }

        public int ExcusedToday { get; set; }

        public int NotRecordedToday { get; set; }
        public decimal PaymentsToday { get; set; }
        public decimal PaymentsThisMonth { get; set; }
    }
}
