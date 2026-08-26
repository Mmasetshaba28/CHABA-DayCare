using CHABA.DayCare.Models.Common;
using System.ComponentModel.DataAnnotations;

namespace CHABA.DayCare.Models.Finance
{
    public class Payment :BaseEntity
    {
        [Required]
        public int ChildId { get; set; }

        public Models.Child.Child Child { get; set; } = null!;

        [Required]
        [Range(0.01, 1000000)]
        public decimal Amount { get; set; }

        [Required]
        public DateTime PaymentDate { get; set; }

        [Required]
        [StringLength(50)]
        public string PaymentMethod { get; set; } = string.Empty;

        [StringLength(100)]
        public string? ReferenceNumber { get; set; }

        [StringLength(250)]
        public string? Description { get; set; }

        [StringLength(500)]
        public string? Notes { get; set; }
    }
}
