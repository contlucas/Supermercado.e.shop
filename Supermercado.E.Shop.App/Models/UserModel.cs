using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Supermercado.E.Shop.App.Models
{
    public class UserModel
    {
        [Required(ErrorMessage = "User name field is required")]
        [Display(Name = "User name")]
        [StringLength(10, ErrorMessage = "User name cannot be more than {0} caracters")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password field is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [StringLength(20, ErrorMessage = "Password field cannot be more than {0} caracters")]
        public string Password { get; set; }

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }
}