﻿using eTickets.Models;


namespace eTickets.Data
{
    public class AppDbInitializer
    {

        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope= applicationBuilder.ApplicationServices.CreateScope())
            {
                var context= serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated(); // Db yaratıldığından emin ol.

                // Cinema Data (5)
                if (!context.Actors.Any())
                { 
                    context.Cinemas.AddRange(new List<Cinema>()
                    {
                        new Cinema()
                        {
                            Name="Cinema 1",
                            Logo="http://dotnethow.net/images/cinemas/cinema-1.jpeg",
                            Description= "Bu Cinema 1 dir"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 2",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-2.jpeg",
                            Description = "Bu Cinema 2 dir"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 3",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-3.jpeg",
                            Description = "Bu Cinema 3 dir"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 4",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-4.jpeg",
                            Description = "Bu Cinema 4 dir"
                        },
                        new Cinema()
                        {
                            Name = "Cinema 5",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-5.jpeg",
                            Description = "Bu Cinema 5 dir"
                        }
                    });                          
                            
                    context.SaveChanges(); // VT tarafına kayıtların yazılması için

                }
               

                // Actor(5)
                if(!context.Actors.Any()) // Eğer Actors tablosunda herhangi bir kayıt yoksa
                {
                    context.Actors.AddRange(new List<Actor>()
                    {
                        new Actor()
                        {
                            FullName="Actor 1",
                            Bio="Actor Bio 1",
                            ProfilePictureURL= "http://dotnethow.net/images/actors/actor-1.jpeg"
                        },
                        new Actor()
                        {
                            FullName = "Actor 2",
                            Bio = "Actor Bio 2",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-2.jpeg"
                        },
                        new Actor()
                        {
                            FullName = "Actor 3",
                            Bio = "Actor Bio 3",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-3.jpeg"
                        },
                        new Actor()
                        {
                            FullName = "Actor 4",
                            Bio = "Actor Bio 4",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-4.jpeg"
                        },
                        new Actor()
                        {
                            FullName = "Actor 5",
                            Bio = "Actor Bio 5",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-5.jpeg"
                        }
                    });
                    context.SaveChanges();
                }

                // Producer (5)
                if (!context.Producers.Any()) // Eğer tabloda herhangi bir kayıt yoksa
                {
                    context.Producers.AddRange(new List<Producer>()
                    {
                        new Producer()
                        {
                            FullName="Producer 1",
                            Bio="Producer Bio 1",
                            ProfilePictureURL= "http://dotnethow.net/images/producers/producer-1.jpeg"
                        },
                        new Producer()
                        {
                            FullName="Producer 2",
                            Bio="Producer Bio 2",
                            ProfilePictureURL= "http://dotnethow.net/images/producers/producer-2.jpeg"
                        },
                        new Producer()
                        {
                            FullName="Producer 3",
                            Bio="Producer Bio 3",
                            ProfilePictureURL= "http://dotnethow.net/images/producers/producer-3.jpeg"
                        },
                        new Producer()
                        {
                            FullName="Producer 4",
                            Bio="Producer Bio 4",
                            ProfilePictureURL= "http://dotnethow.net/images/producers/producer-4.jpeg"
                        },
                        new Producer()
                        {
                            FullName="Producer 5",
                            Bio="Producer Bio 5",
                            ProfilePictureURL= "http://dotnethow.net/images/producers/producer-5.jpeg"
                        }
                    });
                    context.SaveChanges();
                }

                // Movie (6)
                if (!context.Movies.Any())
                {
                    context.Movies.AddRange(new List<Movie>()
                    {
                        new Movie()
                        {
                            Name="Life",
                            Description= "This is Life movie description",
                            Price= 39.50,
                            ImageURL="http://dotnethow.net/images/movies/movie-3.jpeg",
                            StartDate= DateTime.Now.AddDays(-10),
                            EndDate= DateTime.Now.AddDays(10),
                            CinemaId=3,
                            ProducerId=3,
                            MovieCategory = Enums.MovieCategory.Documentary
                        },
                        new Movie()
                        {
                            Name="The Shawnshank Redemption",
                            Description= "This is ... movie description",
                            Price= 39.50,
                            ImageURL="http://dotnethow.net/images/movies/movie-1.jpeg",
                            StartDate= DateTime.Now,
                            EndDate= DateTime.Now.AddDays(35),
                            CinemaId=1,
                            ProducerId=1,
                            MovieCategory = Enums.MovieCategory.Drama
                        },
                        new Movie()
                        {
                            Name="Ghost",
                            Description= "This is .... movie description",
                            Price= 49.50,
                            ImageURL="http://dotnethow.net/images/movies/movie-4.jpeg",
                            StartDate= DateTime.Now,
                            EndDate= DateTime.Now.AddDays(7),
                            CinemaId=4,
                            ProducerId=4,
                            MovieCategory = Enums.MovieCategory.Drama
                        },
                        new Movie()
                        {
                            Name="Race",
                            Description= "This is Race movie description",
                            Price= 39.50,
                            ImageURL="http://dotnethow.net/images/movies/movie-6.jpeg",
                            StartDate= DateTime.Now.AddDays(-10),
                            EndDate= DateTime.Now.AddDays(-5),
                            CinemaId=1,
                            ProducerId=2,
                            MovieCategory = Enums.MovieCategory.Action
                        },
                        new Movie()
                        {
                            Name="Scoob",
                            Description= "This is Scoob movie description",
                            Price= 39.50,
                            ImageURL="http://dotnethow.net/images/movies/movie-7.jpeg",
                            StartDate= DateTime.Now.AddDays(-10),
                            EndDate= DateTime.Now.AddDays(-2),
                            CinemaId=1,
                            ProducerId=3,
                            MovieCategory = Enums.MovieCategory.Cartoon
                        },
                        new Movie()
                        {
                            Name="Cold Souls",
                            Description= "This is Cold Souls movie description",
                            Price= 39.50,
                            ImageURL="http://dotnethow.net/images/movies/movie-8.jpeg",
                            StartDate= DateTime.Now.AddDays(3),
                            EndDate= DateTime.Now.AddDays(33),
                            CinemaId=1,
                            ProducerId=5,
                            MovieCategory = Enums.MovieCategory.Drama
                        }
                    });

                    context.SaveChanges();
                }

                // Actors & Movies
                if (!context.Actors_Movies.Any())
                {
                    context.Actors_Movies.AddRange(new List<Actor_Movie>()
                    {
                        new Actor_Movie() { ActorId=1,MovieId=1 },
                        new Actor_Movie() { ActorId=3,MovieId=1 },
                        new Actor_Movie() { ActorId=1,MovieId=2 },
                        new Actor_Movie() { ActorId=4,MovieId=2 },
                        new Actor_Movie() { ActorId=1,MovieId=3 },
                        new Actor_Movie() { ActorId=2,MovieId=3 },
                        new Actor_Movie() { ActorId=5,MovieId=3 },
                        new Actor_Movie() { ActorId=2,MovieId=4 },
                        new Actor_Movie() { ActorId=3,MovieId=4 },
                        new Actor_Movie() { ActorId=4,MovieId=4 },
                        new Actor_Movie() { ActorId=2,MovieId=5 },
                        new Actor_Movie() { ActorId=3,MovieId=5 },
                        new Actor_Movie() { ActorId=4,MovieId=5 },
                        new Actor_Movie() { ActorId=5,MovieId=5 },
                        new Actor_Movie() { ActorId=3,MovieId=6 },
                        new Actor_Movie() { ActorId=4,MovieId=6 },
                        new Actor_Movie() { ActorId=1,MovieId=6 }
                    });

                    context.SaveChanges();
                }

            }
        }

    }
}
