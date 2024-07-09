using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Producer
    {
        [Key]
        public int Id { get; set; }

        public string? ProfilePictureURL { get; set; }

        public string? FullName { get; set; }

        public string? Bio { get; set; }

        //5.1 Relations
        public List<Movie>? Movies { get; set; } // bir producerın birçok filmi olabilir
    }
}
