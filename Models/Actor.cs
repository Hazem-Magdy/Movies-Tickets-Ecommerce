namespace Movies_Tickets_Ecommerce_App.Models
{
    public class Actor
    {
        public int Id { get; set; }

        public string ProfilePictureURL { get; set; }

        public string FullName { get; set; }

        public string Bio { get; set; }

        public virtual ICollection<Actors_Movies> ActorsMovies { get; set; } = new HashSet<Actors_Movies>();
    }
}
