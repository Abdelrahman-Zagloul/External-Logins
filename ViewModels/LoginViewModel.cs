using System.ComponentModel.DataAnnotations;

namespace External_Logins.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string? Email { get; set; }


        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }


        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }

    }
}
