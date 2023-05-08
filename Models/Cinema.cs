using Movies_Tickets_Ecommerce_App.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movies_Tickets_Ecommerce_App.Models
{
    public class Cinema:IEntityBase
    {
        public int  Id { get; set; }
        [Display(Name = "Cinema Name")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Logo")]
        public string Logo { get; set;}

        public virtual ICollection<Movie> Movies { get; set; } = new HashSet<Movie>();
}
}
