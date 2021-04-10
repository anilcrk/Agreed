using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Agreed.WebUI.Models.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "{0} Gerekli!")]
        public string Email { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "{0} Gerekli!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Beni Hatırla?")]
        public bool RememberMe { get; set; }
    }
}
