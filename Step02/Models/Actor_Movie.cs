namespace eTickets.Models
{
    public class Actor_Movie
    {
        public int MovieId { get; set; }

        public Movie? Movie { get; set; } // Movie modelinden gelecek bilgi

        public int ActorId { get; set; }

        public Actor? Actor { get; set; } // Actor modelinden gelecek bilgi
    }
}
