using System;
using System.ComponentModel.DataAnnotations;

namespace Manager.API.ViewModels
{
    public class UpdateUserViewModel
    {
        [Required(ErrorMessage = "The {0} cannot be empty.")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The {0} cannot be empty.")]
        [StringLength(90, ErrorMessage = "The {0} must be between {2} and {1} characters.", MinimumLength = 6)]
        public string Name { get; set; }

        [Required(ErrorMessage = "The {0} cannot be empty.")]
        [StringLength(100, ErrorMessage = "The {0} must be between {2} and {1} characters.", MinimumLength = 10)]
        [EmailAddress(ErrorMessage = "The {0} is invalid.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The {0} cannot be empty.")]
        [StringLength(8, ErrorMessage = "The {PropertyName} must be {2} characters.", MinimumLength = 8)]
        public string Password { get; set; }

        [Required(ErrorMessage = "The {0} cannot be empty.")]
        [StringLength(8, ErrorMessage = "The {PropertyName} must be {2} characters.", MinimumLength = 8)]
        [Compare(nameof(Password), ErrorMessage = "The {0} is invalid.")]
        public string ConfirmPassword { get; set; }
    }
}