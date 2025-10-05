using System.ComponentModel.DataAnnotations;

namespace GrainBroker.API.DTOs
{
    public class CreateOrderRequest
    {
       // [Required(ErrorMessage = "CustomerId is required")]
        public Guid CustomerId { get; set; }

        //[Required(ErrorMessage = "RequestedGrainAmount is required")]
      //  [Range(0.01, double.MaxValue, ErrorMessage = "RequestedGrainAmount must be greater than 0")]
        public decimal RequestedGrainAmount { get; set; }
    }
}