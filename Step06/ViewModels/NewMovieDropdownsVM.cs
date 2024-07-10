using eTickets.Models;

namespace eTickets.ViewModels
{
    public class NewMovieDropdownsVM
    {
        public List<Producer> Producers { get; set; } // Producer dropdown için

        public List<Actor> Actors { get; set; } // Actor dd için

        public List<Cinema> Cinemas { get; set; } // Cinema dd için

        public NewMovieDropdownsVM()
        {
            Actors = new List<Actor>();

            Cinemas = new List<Cinema>();
            
            Producers = new List<Producer>();
        }

    }
}