using Movies_Tickets_Ecommerce_App.Data.Base;
using Movies_Tickets_Ecommerce_App.Models;
using Movies_Tickets_Ecommerce_App.ViewModels;

namespace Movies_Tickets_Ecommerce_App.Services
{
    public interface IMoviesRepository : IEntityBaseRepository<Movie>
    {

        Task<Movie> GetMovieByIdAsync(int id);
        Task<NewMovieDropdownsViewModel> GetNewMovieDropdownsValues();
        Task AddNewMovieAsync(NewMovieViewModel data);
        Task UpdateMovieAsync(NewMovieViewModel data);

    }

}
