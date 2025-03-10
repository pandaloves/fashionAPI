namespace shop.Entities
{
    public class Cart
    {
        public int CartId { get; set; }

        public int UserId { get; set; } // Foreign key to ShopUser
        public ShopUser User { get; set; } // A Cart belongs to one ShopUser

        public ICollection<CartItem> CartItems { get; set; } // A Cart can have many CartItems
    }

    public class CartItem
    {
        public int CartItemId { get; set; }

        // Reference to Product
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int CartId { get; set; } // Foreign key to Cart
        public Cart Cart { get; set; } // A CartItem belongs to one Cart

        public int ProductQuantity { get; set; } // Add this property to track the quantity of the product
    }
}
