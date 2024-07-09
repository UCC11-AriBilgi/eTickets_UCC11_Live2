using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Actor 
    {
        [Key]
        public int Id { get; set; }

        public string? ProfilePictureURL { get; set; }

        public string? FullName { get; set; }

        public string? Bio { get; set; }

        //5.1 Relations 
        public List<Actor_Movie>? Actors_Movies { get; set; } // Bir Actor çok Movie de oynayabilir
    }
}
