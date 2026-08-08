using CHABA.DayCare.Models.Common;
using System.ComponentModel.DataAnnotations;
using CHABA.DayCare.Models.Child;

namespace CHABA.DayCare.Models.Guardian
{
    public class Guardian : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Relationship { get; set; } = string.Empty;

        [Required]
        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;

        [Phone]
        public string? AlternativePhoneNumber { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [StringLength(250)]
        public string? PhysicalAddress { get; set; }

        [StringLength(100)]
        public string? Occupation { get; set; }

        [StringLength(100)]
        public string? Employer { get; set; }

        public bool IsPrimaryContact { get; set; } = true;

        public bool IsEmergencyContact { get; set; } = true;

        // Relationship to Child
        public int ChildId { get; set; }

        public CHABA.DayCare.Models.Child.Child Child { get; set; } = null!;
    }
}
