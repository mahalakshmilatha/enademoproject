using System.ComponentModel.DataAnnotations;
using GrainBroker.Entities;
using GrainBroker.Entities.DTOs;

namespace GrainBroker.Frontend.Models
{
    public class CustomerModel
    {
        [Required(ErrorMessage = "Customer name is required")]
        [StringLength(100, ErrorMessage = "Customer name cannot be longer than 100 characters")]
        public string CustomerName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Location is required")]
        [StringLength(100, ErrorMessage = "Location cannot be longer than 100 characters")]
        public string Location { get; set; } = string.Empty;

        public string? ErrorMessage { get; set; }
        
        public bool IsSubmitting { get; set; }

        public CustomerModel()
        {
            CustomerName = string.Empty;
            Location = string.Empty;
        }

        public CreateCustomerRequest ToCreateCustomerRequest()
        {
            return new CreateCustomerRequest
            {
                CustomerName = CustomerName,
                Location = Location
            };
        }

        public void Reset()
        {
            CustomerName = string.Empty;
            Location = string.Empty;
            ErrorMessage = null;
            IsSubmitting = false;
        }
    }
}