using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Customers")]
public class Customer
{
    [Key, Required] 
    public Guid Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string? CustomerName { get; set; }

    [Required] 
    [MaxLength(100)]
    public string? CustomerLocation { get; set; }
    public virtual ICollection<Order> Orders { get; set; }
}