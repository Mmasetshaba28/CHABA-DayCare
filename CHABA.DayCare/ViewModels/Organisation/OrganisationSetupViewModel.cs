using System.ComponentModel.DataAnnotations;

namespace CHABA.DayCare.ViewModels.Organisation
{
    public class OrganisationSetupViewModel
    {
        [Required]
        [Display(Name ="Organisation Name")]
        [StringLength(150)]
        public string Name { get; set; } = string.Empty;

        [Display(Name ="Registration Number")]
        [StringLength(50)]
        public string? RegistrationNumber { get; set; }

        [Required]
        [Display(Name ="Principal Name")]
        [StringLength(100)]
        public string PrincipalName { get; set; } = string.Empty;

        [Required]
        [Display(Name ="Phone Number")]
        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Display(Name ="Physical Address")]
        [StringLength(250)]
        public string PhysicalAddress { get; set; } = string.Empty;

        [Display(Name ="School Motto")]
        [StringLength(200)]
        public string? Motto { get; set; }
    }
}
