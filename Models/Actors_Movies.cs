using System.ComponentModel.DataAnnotations.Schema;

namespace Movies_Tickets_Ecommerce_App.Models
{
    public class Actors_Movies
    {
        [ForeignKey("Actor")]
        public int ActorId { get; set; }
        
        [ForeignKey("Movie")]
        public int MovieId { get; set; }

        public Actor Actor { get; set;}

        public Movie Movie { get; set; }


    }
}
