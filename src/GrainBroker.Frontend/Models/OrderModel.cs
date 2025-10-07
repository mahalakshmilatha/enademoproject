using System;
using System.ComponentModel.DataAnnotations;
using GrainBroker.Entities;

namespace GrainBroker.Frontend.Models
{
    public class OrderModel
    {
        [Required(ErrorMessage = "Please select a customer")]
        public Guid CustomerId { get; set; }

        [Required(ErrorMessage = "Please enter the grain amount")]
        [Range(1, 10000, ErrorMessage = "Grain amount must be between 1 and 10,000 tons")]
        public decimal RequestedGrainAmount { get; set; }

        public string? ErrorMessage { get; set; }
        
        public bool IsSubmitting { get; set; }

        public OrderModel()
        {
            RequestedGrainAmount = 1; // Set a default value
        }

        public CreateOrderRequest ToCreateOrderRequest()
        {
            return new CreateOrderRequest
            {
                CustomerId = CustomerId,
                RequestedGrainAmount = RequestedGrainAmount
            };
        }
    }
}