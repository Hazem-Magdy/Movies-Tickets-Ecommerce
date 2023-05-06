using System.ComponentModel.DataAnnotations;

namespace Movies_Tickets_Ecommerce_App.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string UserName { get; set; }

        [Required,DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
