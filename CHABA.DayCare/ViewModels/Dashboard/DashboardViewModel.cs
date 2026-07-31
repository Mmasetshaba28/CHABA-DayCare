namespace CHABA.DayCare.ViewModels.Dashboard
{
    public class DashboardViewModel
    {
        public string OrganisationName { get; set; } = string.Empty;

        public string? Motto { get; set; }

        public int ChildrenCount { get; set; }

        public int ClassroomCount { get; set; }

        public int TeacherCount { get; set; }

        public int ParentCount { get; set; }
    }
}
