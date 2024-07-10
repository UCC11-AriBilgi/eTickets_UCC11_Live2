using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Order
    {
        //52

        [Key]
        public int Id { get; set; }

        public string Email { get; set; }
        public string UserId { get; set; }

        // Relation
        public List<OrderItem> OrderItems { get; set; } // OrderItems modeline referans veriyoruz.
    }
}
