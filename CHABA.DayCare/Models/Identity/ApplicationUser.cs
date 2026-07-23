using Microsoft.AspNetCore.Identity;

namespace CHABA.DayCare.Models.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName => $"{FirstName} {LastName}".Trim();
        public bool IsActive { get; set; } = true;
        public string? ProfilePictureUrl { get; set; }

        //Organisation Relationship
        public int OrganisationId { get; set; }

        public Core.Organisation Organisation { get; set; } = null!;
    }
}
