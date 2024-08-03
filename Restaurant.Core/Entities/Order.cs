using System.ComponentModel.DataAnnotations;

namespace Restaurant.Core.Entities;

public class Order:BaseEntity
{
    [Required]
    public int TotalAmount { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [Required]
    public List<OrderItem> OrderItems { get; set; }

    public override string ToString()
    {
        return Id + " " + TotalAmount.ToString();
    }
}
