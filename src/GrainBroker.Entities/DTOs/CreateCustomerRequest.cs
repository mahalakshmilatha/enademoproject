using System.ComponentModel.DataAnnotations;

namespace GrainBroker.Entities.DTOs
{
    public class CreateCustomerRequest
    {
        [Required(ErrorMessage = "Customer name is required")]
        [StringLength(100, ErrorMessage = "Customer name cannot be longer than 100 characters")]
        public string CustomerName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Location is required")]
        [StringLength(100, ErrorMessage = "Location cannot be longer than 100 characters")]
        public string Location { get; set; } = string.Empty;
    }
}