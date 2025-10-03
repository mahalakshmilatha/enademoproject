using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("OrderFulfillments")]
public class OrderFulfillment
{
    [Key,Required]    
    public Guid Id { get; set; }

    [Required]
    public Guid OrderId { get; set; }

    [ForeignKey("OrderId")]
    public virtual Order Order { get; set; } = null!;

    [Required]
    public Guid SupplierId { get; set; }

    [ForeignKey("SupplierId")]
    public virtual Supplier Supplier { get; set; } = null!;

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    [Range(0, Double.MaxValue)]
    public decimal SuppliedAmount { get; set; }

    [Required]
    [Column(TypeName = "decimal(18,2)")]
    [Range(0, Double.MaxValue)]
    public decimal CostOfDelivery { get; set; }
}