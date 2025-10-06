using GrainBroker.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Orders")]
public class Order
{
    [Key,Required]    
    public Guid OrderId { get; set; }

    [Required]
    public DateTime OrderDate { get; set; }

    [Required]
    public Guid CustomerId { get; set; }

    [ForeignKey("CustomerId")]
    public virtual Customer Customer { get; set; } = null!;

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    [Range(0, Double.MaxValue)]
    public decimal RequestedGrainAmount { get; set; }
    public string? Status { get; set; } = "Pending";

    // public virtual OrderFulfillment? Fulfillment { get; set; }

}