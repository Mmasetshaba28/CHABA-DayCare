namespace CHABA.DayCare.ViewModels.Classroom
{
    public class ClassroomListViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public int MinimumAgeInMonths { get; set; }

        public int? MaximumAgeInMonths { get; set; }

        public int Capacity { get; set; }
    }
}
