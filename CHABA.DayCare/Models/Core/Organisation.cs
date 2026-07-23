using CHABA.DayCare.Models.Common;
using System.ComponentModel.DataAnnotations;
using CHABA.DayCare.Models.Identity;

namespace CHABA.DayCare.Models.Core
{
    public class Organisation : BaseEntity
    {

        [Required]
        [StringLength(150)]
        public string Name { get; set; } = string.Empty;

        [StringLength(50)]
        public string? RegistrationNumber { get; set; }

        [StringLength(20)]
        public string? PhoneNumber { get; set; }

        [EmailAddress]
        public string? Email {  get; set; }

        [StringLength(250)]
        public string? PhysicalAddress { get; set; }

        public string? LogoUrl { get; set; }

        public bool IsActive { get; set; } = true;

        public string? PrincipalName { get; set; }

        public string? Motto { get; set; }
        public ICollection<ApplicationUser> Users { get; set; } = new List<ApplicationUser>();
    }
}
