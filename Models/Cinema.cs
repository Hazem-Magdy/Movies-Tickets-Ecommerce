namespace Movies_Tickets_Ecommerce_App.Models
{
    public class Cinema
    {
        public int  Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Logo { get; set;}

        public virtual ICollection<Movie> Movies { get; set; } = new HashSet<Movie>();
}
}
