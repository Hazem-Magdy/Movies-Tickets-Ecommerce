using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movies_Tickets_Ecommerce_App.Models
{
    public class Actor
    {
        public int Id { get; set; }
        [Display(Name = "Profile Picture")]
        public string ProfilePictureURL { get; set; }
        [Display(Name = "FullName")]
        public string FullName { get; set; }
        [Display(Name = "Bio")]
        public string Bio { get; set; }

        public virtual ICollection<Actors_Movies> ActorsMovies { get; set; } = new HashSet<Actors_Movies>();
    }
}
