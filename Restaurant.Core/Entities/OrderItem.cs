using System.ComponentModel.DataAnnotations;

namespace Restaurant.Core.Entities;

public class OrderItem:BaseEntity
{
    [Required]
    public MenuItem MenuItem { get; set; }

    [Required]
    public int Count { get; set; }

    [Required]
    public Order Order { get; set; }
}
