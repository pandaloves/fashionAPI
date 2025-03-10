using System.ComponentModel.DataAnnotations;

namespace shop.Entities
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string CardNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string NameOnCard { get; set; }
        public string ExpirationDate { get; set; }
        public string CVV { get; set; }

        // Foreign key to represent the Order
        public int OrderId { get; set; }

        // Navigation property to reference the associated Order
        public Order Order { get; set; }
    }
}
