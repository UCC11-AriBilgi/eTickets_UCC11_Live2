using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using eTickets.ViewModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace eTickets.Data
{
    // Models <--> VT
    // Bu tür bir tanım için EntityFrameworkCore'ın hazır DbContext sınıfından kalıtıyorum.
    public class AppDbContext : IdentityDbContext<ApplicationUser> //40
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Uygulama ayağa kalkarken... modeller yaratılırken


            // Relations
            modelBuilder.Entity<Actor_Movie>().HasKey(acmo => new
            {
                acmo.ActorId,
                acmo.MovieId
            });

            // Actor_Movie <-->> Actor
            modelBuilder.Entity<Actor_Movie>()
                .HasOne(m => m.Actor)
                .WithMany(acmo => acmo.Actors_Movies)
                .HasForeignKey(m => m.ActorId);

            // Actor_Movie <-->> Movie
            //modelBuilder.Entity<Actor_Movie>()
            //    .HasOne(m => m.Movie).WithMany(acmo => acmo.Actors_Movies)

            //    .HasForeignKey(m => m.MovieId);

            base.OnModelCreating(modelBuilder);

        }

        // Model <-> VT tablo bağlaşımları

        public DbSet<Actor> Actors { get; set; } // Actors VT tarafındaki tablo

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Actor_Movie> Actors_Movies { get; set; }

        public DbSet<Cinema> Cinemas { get; set; }

        public DbSet<Producer> Producers { get; set; }
    // Models <--> VT
        public DbSet<eTickets.ViewModels.NewMovieVM> NewMovieVM { get; set; } = default!;


    }
}
