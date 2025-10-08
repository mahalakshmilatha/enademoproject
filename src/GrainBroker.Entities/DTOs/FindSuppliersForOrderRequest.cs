using System.ComponentModel.DataAnnotations;

namespace GrainBroker.Entities.DTOs
{
    public class FindSuppliersForOrderRequest
    {
        [Required]
        public Guid OrderId { get; set; }
    }
}