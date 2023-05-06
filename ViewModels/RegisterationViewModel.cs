using System.ComponentModel.DataAnnotations;

namespace Movies_Tickets_Ecommerce_App.ViewModels
{
    public class RegisterationViewModel
    {
        [Required]
        public string UserName { get; set; }

        [Required, DataType(DataType.EmailAddress)] 
        public string Email { get; set; }
        [Required,DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password"),Required]
        public string ConfirmPassword { get; set; }
    }
}

