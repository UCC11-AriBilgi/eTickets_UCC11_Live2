using eTickets.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace eTickets.ViewModels
{
    public class NewMovieVM
    {
        [Key]
        public int Id { get; set; }

        [Display(Name="Movie Name")]
        [Required(ErrorMessage = "Film adı gerekli bilgidir..")]
        public string Name { get; set; }

        [Display(Name = "Movie Description")]
        [Required(ErrorMessage = "Film açıklaması gerekli bilgidir..")]
        public string Description { get; set; }

        [Display(Name = "Price (TL)")]
        [Required(ErrorMessage = "Fiyat gerekli bilgidir..")]
        public double Price { get; set; }

        [Display(Name = "Movie Poster URL")]
        [Required(ErrorMessage = "Afiş URL gerekli bilgidir..")]
        public string ImageURL { get; set; }

        [Display(Name = "Movie Start Date")]
        [Required(ErrorMessage = "Film Başlangıç Tarihi gerekli bilgidir..")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Movie End Date")]
        [Required(ErrorMessage = "Film Bitiş Tarihi gerekli bilgidir..")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Movie Category")]
        [Required(ErrorMessage = "Film Kategorisi gerekli bilgidir..")]
        public MovieCategory MovieCategory { get; set; }

        // Burası çoktan seçmeli dropdownlist olarak gelecek
        [Display(Name = "Select Actor(s)")]
        [Required(ErrorMessage = "Film aktörleri gerekli bilgidir..")]
        public List<int> ActorIds { get; set; }

        // Burası çoktan seçmeli dropdownlist olarak gelecek
        [Display(Name = "Select Cinema")]
        [Required(ErrorMessage = "Cinema bilgisi gerekli bilgidir..")]
        public int CinemaId { get; set; }

        // Burası çoktan seçmeli dropdownlist olarak gelecek
        [Display(Name = "Select Producer")]
        [Required(ErrorMessage = "Film yönetmeni gerekli bilgidir..")]
        public int ProducerId { get; set; }






    }
}
