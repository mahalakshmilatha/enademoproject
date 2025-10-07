using System.ComponentModel.DataAnnotations;
using GrainBroker.Entities;

namespace GrainBroker.Frontend.Models
{
    public class SupplierModel
    {
        [Required(ErrorMessage = "Supplier name is required")]
        [StringLength(100, ErrorMessage = "Supplier name cannot be longer than 100 characters")]
        public string SupplierName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Location is required")]
        [StringLength(100, ErrorMessage = "Location cannot be longer than 100 characters")]
        public string Location { get; set; } = string.Empty;

        public string? ErrorMessage { get; set; }
        
        public bool IsSubmitting { get; set; }

        public SupplierModel()
        {
            SupplierName = string.Empty;
            Location = string.Empty;
        }

        public CreateSupplierRequest ToCreateSupplierRequest()
        {
            return new CreateSupplierRequest
            {
                Name = SupplierName,
                Location = Location
            };
        }

        public void Reset()
        {
            SupplierName = string.Empty;
            Location = string.Empty;
            ErrorMessage = null;
            IsSubmitting = false;
        }
    }
}