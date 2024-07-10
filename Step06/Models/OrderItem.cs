using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTickets.Models
{
    public class OrderItem
    {
        // 52
        [Key]
        public int Id { get; set; }

        public int Amount { get; set; }

        public double Price { get; set; }

        public int MovieId { get; set; }

        // Relations

        // Movie tarafıyla
        [ForeignKey("MovieId")]
        public Movie Movie { get; set; } // Movie tablosuna referans veriyoruz.

        // Order tarafıyla
        public int OrderId { get; set; }

        [ForeignKey("OrderId")]
        public Order Order { get; set; } // Order tablosuna referans veriyoruz.

    }
}
