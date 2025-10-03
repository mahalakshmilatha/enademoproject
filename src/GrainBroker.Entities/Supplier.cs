using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Suppliers")]
public class Supplier
{
    [Key, Required]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string? SupName { get; set; }

    [Required]
    [MaxLength(100)]
    public string? SupLocation { get; set; }

    [MaxLength(15)]
    public string? InStockAmount { get; set; }
    public virtual ICollection<OrderFulfillment> Fulfillments { get; set; }
}