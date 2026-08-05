using CHABA.DayCare.Models.Common;
using CHABA.DayCare.Models.Core;
using System.ComponentModel.DataAnnotations;

namespace CHABA.DayCare.Models.Child
{
    public class Child : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public DateTime AdmissionDate { get; set; } = DateTime.Today;

        [Required]
        public Gender Gender { get; set; }

        public ChildStatus Status { get; set; } = ChildStatus.Active;

        [StringLength(500)]
        public string? Allergies { get; set; }

        [StringLength(500)]
        public string? MedicalConditions { get; set; }

        [StringLength(100)]
        public string? DoctorName { get; set; }

        [Phone]
        public string? DoctorPhone { get; set; }

        // Classroom Relationship
        public int ClassroomId { get; set; }

        public Classroom Classroom { get; set; } = null!;

        // Organisation Relationship
        public int OrganisationId { get; set; }

        public Organisation Organisation { get; set; } = null!;
    }
}
