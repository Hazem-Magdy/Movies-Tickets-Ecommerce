using Movies_Tickets_Ecommerce_App.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movies_Tickets_Ecommerce_App.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }
        public string ImageURL { get; set; }

        public DateTime StartDate { get; set; }
        
        public DateTime EndDate { get; set;}

        public MovieCategory MovieCategory { get; set; }
        
        [ForeignKey("Cinema")]
        public int  CinemaId { get; set; }
        public virtual Cinema Cinema { get; set; }
        [ForeignKey("Producer")]
        public int ProducerId { get; set; }
        public virtual Producer Producer { get; set; }
        public virtual ICollection<Actors_Movies> ActorsMovies { get; set; } = new HashSet<Actors_Movies>();


    }
    
}
