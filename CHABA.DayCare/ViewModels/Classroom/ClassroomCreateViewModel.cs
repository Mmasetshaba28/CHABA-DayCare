using System.ComponentModel.DataAnnotations;

namespace CHABA.DayCare.ViewModels.Classroom
{
    public class ClassroomCreateViewModel
    {
        [Required]
        [StringLength(100)]
        [Display(Name = "Classroom Name")]
        public string Name { get; set; } = string.Empty;

        [StringLength(250)]
        public string? Description { get; set; }

        [Required]
        [Display(Name = "Minimum Age (Months)")]
        public int MinimumAgeInMonths { get; set; }

        [Display(Name = "Maximum Age (Months)")]
        public int? MaximumAgeInMonths { get; set; }

        [Required]
        [Range(1, 100)]
        public int Capacity { get; set; }
    }
}
