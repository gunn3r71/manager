using System.ComponentModel.DataAnnotations;

namespace Manager.API.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "The {0} cannot be empty.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The {0} cannot be empty.")]
        public string Password { get; set; }
    }
}