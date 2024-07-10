using eTickets.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eTickets.Models;
    public class Actor : IEntityBase // 35
    {
        [Key]
        public int Id { get; set; }
    // 17.1
        [Display(Name = "Profile Picture")]
        public string? ProfilePictureURL {get; set;}

        [Display(Name = "Full Name")]
        public string? FullName { get; set;}
        
        [Display(Name = "Biography")]
        public string? Bio { get; set;}

        // Relations
        public List<Actor_Movie>? Actors_Movies { get; set; } // Bir Actor birden çok Movie'de oynayabilir
    }

