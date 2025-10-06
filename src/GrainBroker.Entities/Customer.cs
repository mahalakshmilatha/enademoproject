using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Customers")]
public class Customer
{
    //public Customer()
    //{
    //    Orders = new HashSet<Order>();
    //}

    [Key, Required] 
    public Guid Id { get; set; }

    [Required] public string CustomerName { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string CustomerLocation { get; set; } = string.Empty;

    public string Status { get; set; } = "Active";

   // public virtual ICollection<Order> Orders { get; set; }
}