namespace Movies_Tickets_Ecommerce_App.Models
{
    public class Producer
    {
        public int Id { get; set; }

        public string ProfilePictureURL { get; set; }

        public string FullName { get; set; }

        public string Bio { get; set; }

        public virtual ICollection<Movie> Movies { get; set; } = new HashSet<Movie>();
    }
}
