using Agreed.WebUI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agreed.WebUI.Models.ViewModels
{
    public class CommissionViewModel
    {
        public CommissionViewModel()
        {
            Orders = new List<CommissionDto>();
            ResultModel = new ResultModel();
        }
        public List<CommissionDto> Orders { get; set; }

        public ResultModel ResultModel { get; set; }
    }
}
