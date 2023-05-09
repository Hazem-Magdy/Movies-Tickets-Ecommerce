using Movies_Tickets_Ecommerce_App.Models;

namespace Movies_Tickets_Ecommerce_App.ViewModels
{
    public class NewMovieDropdownsViewModel
    {
        public NewMovieDropdownsViewModel()
        {
            Producers = new List<Producer>();
            Cinemas = new List<Cinema>();
            Actors = new List<Actor>();
        }

        public List<Producer> Producers { get; set; }
        public List<Cinema> Cinemas { get; set; }
        public List<Actor> Actors { get; set; }
    }
}
