using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Suppliers")]
public class Supplier
{
    //public Supplier()
    //{
    //    Fulfillments = new HashSet<OrderFulfillment>();
    //}

    [Key, Required]
    public Guid Id { get; set; }

    [Required] public string SupplierName { get; set; } = string.Empty;
    [Required]
    [MaxLength(100)]
    public string SupplierLocation { get; set; } = string.Empty;

    public int StockAvailable { get; set; } = 0;

    public string Status { get; set; } = "Active";



    // public virtual ICollection<OrderFulfillment> Fulfillments { get; set; }
}