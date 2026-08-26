using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace CHABA.DayCare.ViewModels.Finance
{
    public class PaymentCreateViewModel
    {
        [Required]
        [Display(Name = "Child")]
        public int ChildId { get; set; }

        [Required]
        [Range(0.01, 1000000)]
        public decimal Amount { get; set; }

        [Required]
        [Display(Name = "Payment Date")]
        public DateTime PaymentDate { get; set; } = DateTime.Today;

        [Required]
        [Display(Name = "Payment Method")]
        public string PaymentMethod { get; set; } = string.Empty;

        [Display(Name = "Reference Number")]
        public string? ReferenceNumber { get; set; }

        public string? Description { get; set; }

        public string? Notes { get; set; }

        public List<SelectListItem> Children { get; set; } = new();
    }
}
