using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data
{
    // Models <--> VT
    // Bu tür bir tanım için EntityFrameworkCore'ın hazır DbContext sınıfından kalıtıyorum.
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
                
        }

        //8
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

        // 8
        // Model <-> VT tablo bağlaşımları

        public DbSet<Actor> Actors { get; set; } // Actors VT tarafındaki tablo

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Actor_Movie> Actors_Movies { get; set; }

        public DbSet<Cinema> Cinemas { get; set; }

        public DbSet<Producer> Producers { get; set; }


    }
}
