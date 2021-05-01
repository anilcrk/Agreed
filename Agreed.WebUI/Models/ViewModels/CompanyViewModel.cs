using Agreed.WebUI.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Agreed.WebUI.Models.ViewModels
{
    public class CompanyViewModel
    {
        public CompanyViewModel()
        {
            ResultModel = new ResultModel();
            Companies = new List<CompanyDto>();
        }

        public List<CompanyDto> Companies { get; set; }

        public ResultModel ResultModel { get; set; }
    }
}
