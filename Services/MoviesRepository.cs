using Microsoft.EntityFrameworkCore;
using Movies_Tickets_Ecommerce_App.Data;
using Movies_Tickets_Ecommerce_App.Data.Base;
using Movies_Tickets_Ecommerce_App.Models;
using Movies_Tickets_Ecommerce_App.ViewModels;

namespace Movies_Tickets_Ecommerce_App.Services
{
    public class MoviesRepository:EntityBaseRepository<Movie>, IMoviesRepository
    {
        private readonly AppDbContext context;
        public MoviesRepository(AppDbContext _db) : base(_db)
        {
            context= _db;


        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            var movieDetails = await context.Movies
                .Include(p=>p.Producer)
                .Include(c=>c.Cinema)
                .Include(a => a.ActorsMovies).ThenInclude(a=>a.Actor)
                .FirstOrDefaultAsync(x => x.Id == id);
            return movieDetails;

        }
        public async Task AddNewMovieAsync(NewMovieViewModel data)
        {
            var newMovie = new Movie()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageURL = data.ImageURL,
                CinemaId = data.CinemaId,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                MovieCategory = data.MovieCategory,
                ProducerId = data.ProducerId
            };
            await context.Movies.AddAsync(newMovie);
            await context.SaveChangesAsync();

            //Add Movie Actors
            foreach (var actorId in data.ActorIds)
            {
                var newActorMovie = new Actors_Movies()
                {
                    MovieId = newMovie.Id,
                    ActorId = actorId
                };
                await context.Actors_Movies.AddAsync(newActorMovie);
            }
            await context.SaveChangesAsync();
        }
        public async Task<NewMovieDropdownsViewModel> GetNewMovieDropdownsValues()
        {
            var response = new NewMovieDropdownsViewModel()
            {
                Actors = await context.Actors.OrderBy(n => n.FullName).ToListAsync(),
                Cinemas = await context.Cinemas.OrderBy(n => n.Name).ToListAsync(),
                Producers = await context.Producers.OrderBy(n => n.FullName).ToListAsync()
            };

            return response;
        }
        public async Task UpdateMovieAsync(NewMovieViewModel data)
        {
            var dbMovie = await context.Movies.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbMovie != null)
            {
                dbMovie.Name = data.Name;
                dbMovie.Description = data.Description;
                dbMovie.Price = data.Price;
                dbMovie.ImageURL = data.ImageURL;
                dbMovie.CinemaId = data.CinemaId;
                dbMovie.StartDate = data.StartDate;
                dbMovie.EndDate = data.EndDate;
                dbMovie.MovieCategory = data.MovieCategory;
                dbMovie.ProducerId = data.ProducerId;
                await context.SaveChangesAsync();
            }

            //Remove existing actors
            var existingActorsDb = context.Actors_Movies.Where(n => n.MovieId == data.Id).ToList();
            context.Actors_Movies.RemoveRange(existingActorsDb);
            await context.SaveChangesAsync();

            //Add Movie Actors
            foreach (var actorId in data.ActorIds)
            {
                var newActorMovie = new Actors_Movies()
                {
                    MovieId = data.Id,
                    ActorId = actorId
                };
                await context.Actors_Movies.AddAsync(newActorMovie);
            }
            await context.SaveChangesAsync();
        }
    }
}

