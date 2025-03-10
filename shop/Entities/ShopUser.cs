using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using shop.Entities;
public class ShopUser
{
    [Key]
    public int UserId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }

    [NotMapped]
    public Cart Cart { get; set; } // ShopUser can have one Cart

    [NotMapped]
    public ICollection<Order> Orders { get; set; } // ShopUser can have many Orders
}
