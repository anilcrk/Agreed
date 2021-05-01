using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Agreed.WebUI.DTOs
{
    public class CompanyDto
    {
        public int Id { get; set; }
        [Display(Name = "Şirket Adı")]
        [Required(ErrorMessage = "{0} Gerekli!")]
        public string CompanyName { get; set; }
    }
}
