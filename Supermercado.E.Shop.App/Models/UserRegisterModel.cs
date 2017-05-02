using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Supermercado.E.Shop.App.Models
{
    public class UserRegisterModel
    {
        [Required(ErrorMessage = "User name field is required")]
        [Display(Name = "User name")]
        [StringLength(10, ErrorMessage = "User name cannot be more than {1} caracters and less than {2}", MinimumLength = 5)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password field is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [StringLength(20, ErrorMessage = "Password field cannot be more than {1} caracters and less than {2}", MinimumLength = 8)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirmation password field is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmation Password")]
        [StringLength(20, ErrorMessage = "Confirmation password field cannot be more than {1} caracters and less than {2}", MinimumLength = 8)]
        [Compare("Password", ErrorMessage = "The password do not match")]
        public string ConfirmationPassword { get; set; }

        [Required(ErrorMessage = "Email Address field is required")]
        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
    }
}