using CHABA.DayCare.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace CHABA.DayCare.Models.Core
{
    public class Classroom : BaseEntity
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [StringLength(250)]
        public string? Description { get; set; }

        [Required]
        public int MinimumAgeInMonths { get; set; }

        public int? MaximumAgeInMonths { get; set; }

        [Required]
        [Range(1, 100)]
        public int Capacity { get; set; }


        //Foreign key to Organisation
        public int OrganisationId { get; set; }

        //Navigation property to Organisation
        public Organisation Organisation { get; set; } = null!;

        //public ICollection<Child> Children { get; set; } = new List<Child>();
    }
}
