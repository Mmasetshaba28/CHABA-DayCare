using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace CHABA.DayCare.ViewModels.Guardian
{
    public class GuardianCreateViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public string Relationship { get; set; } = string.Empty;

        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Phone]
        [Display(Name = "Alternative Phone Number")]
        public string? AlternativePhoneNumber { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [Display(Name = "Physical Address")]
        public string? PhysicalAddress { get; set; }

        public string? Occupation { get; set; }

        public string? Employer { get; set; }

        [Display(Name = "Primary Contact")]
        public bool IsPrimaryContact { get; set; } = true;

        [Display(Name = "Emergency Contact")]
        public bool IsEmergencyContact { get; set; } = true;

        [Required]
        [Display(Name = "Child")]
        public int ChildId { get; set; }

        public List<SelectListItem> Children { get; set; } = new();
    }
}
