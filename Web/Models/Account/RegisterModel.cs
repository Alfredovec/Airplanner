using System.ComponentModel.DataAnnotations;

namespace Web.Models.Account
{
    /// <summary>
    /// Representing view model for registration.
    /// </summary>
    public class RegisterModel
    {
        [Required(ErrorMessage = "Please, enter your login.")]
        public string Login { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Please, enter your email.")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please, enter your password.")]
        [StringLength(16, ErrorMessage = "Must be between 5 and 16 characters", MinimumLength = 5)]
        public string Password { get; set; }

        [Compare("Password")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Required(ErrorMessage = "Please, confirm your password.")]
        [StringLength(16, ErrorMessage = "Must be between 5 and 16 characters", MinimumLength = 5)]
        public string ConfirmPassword { get; set; }
    }
}
