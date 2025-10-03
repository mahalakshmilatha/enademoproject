using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Customers")]
public class Customer
{
    public Customer()
    {
        Orders = new HashSet<Order>();
    }

    [Key, Required] 
    public Guid Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Location { get; set; } = string.Empty;

    public virtual ICollection<Order> Orders { get; set; }
}