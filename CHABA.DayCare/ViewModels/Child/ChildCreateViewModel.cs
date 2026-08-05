using CHABA.DayCare.Models.Child;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace CHABA.DayCare.ViewModels.Child
{
    public class ChildCreateViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime AdmissionDate { get; set; } = DateTime.Today;

        [Required]
        public Gender Gender { get; set; }

        [Display(Name = "Allergies")]
        public string? Allergies { get; set; }

        [Display(Name = "Medical Conditions")]
        public string? MedicalConditions { get; set; }

        [Display(Name = "Doctor Name")]
        public string? DoctorName { get; set; }

        [Display(Name = "Doctor Phone")]
        public string? DoctorPhone { get; set; }

        [Required]
        [Display(Name = "Classroom")]
        public int ClassroomId { get; set; }

        public List<SelectListItem> Classrooms { get; set; } = new();
    }
}
