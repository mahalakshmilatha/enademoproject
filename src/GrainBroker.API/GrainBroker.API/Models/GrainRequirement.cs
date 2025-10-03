namespace GrainBroker.API.Models
{
    public class GrainRequirement
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }
        public string GrainType { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public DateTime RequiredByDate { get; set; }
        public string Status { get; set; } = "Pending";
        public int? SupplierId { get; set; }
        public Supplier? Supplier { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? FulfilledAt { get; set; }
    }
}
