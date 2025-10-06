using System.ComponentModel.DataAnnotations;

namespace GrainBroker.API.DTOs
{
    public class CreateFulfillmentRequest
    {
       // [Required(ErrorMessage = "OrderId is required")]
        public Guid OrderId { get; set; }

        //[Required(ErrorMessage = "SupplierId is required")]
        public Guid SupplierId { get; set; }

        //[Required(ErrorMessage = "SuppliedAmount is required")]
       // [Range(0.01, double.MaxValue, ErrorMessage = "SuppliedAmount must be greater than 0")]
        public decimal SuppliedAmount { get; set; }

       // [Required(ErrorMessage = "CostOfDelivery is required")]
       // [Range(0, double.MaxValue, ErrorMessage = "CostOfDelivery must be greater than or equal to 0")]
        public decimal CostOfDelivery { get; set; }
    }
}