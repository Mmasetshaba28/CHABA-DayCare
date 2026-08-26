using CHABA.DayCare.Models.Common;
using CHABA.DayCare.Models.Core;
using System.ComponentModel.DataAnnotations;

namespace CHABA.DayCare.Models.Staff
{
    public class Staff : BaseEntity
    {
        [Required]
        [StringLength(100)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [StringLength(13)]
        [RegularExpression(@"^\d{13}$", ErrorMessage = "ID Number must contain exactly 13 digits.")]
        [Display(Name = "ID Number")]
        public string IDNumber { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Role { get; set; } = string.Empty;

        [StringLength(200)]
        public string? Qualification { get; set; }

        [Required]
        [Phone]
        [StringLength(20)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Phone]
        [StringLength(20)]
        [Display(Name = "Alternative Phone Number")]
        public string? AlternativePhoneNumber { get; set; }

        [EmailAddress]
        [StringLength(150)]
        public string? Email { get; set; }

        [Required]
        [Display(Name = "Date Joined")]
        public DateTime DateJoined { get; set; }

        // Optional classroom assignment
        public int? ClassroomId { get; set; }

        public Classroom? Classroom { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
