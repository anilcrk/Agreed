using Agreed.WebUI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agreed.WebUI.Models.ViewModels
{
    public class CargoViewModel
    {
        public CargoViewModel()
        {
            Orders = new List<CargoDto>();
            ResultModel = new ResultModel();
        }
        public List<CargoDto> Orders { get; set; }

        public ResultModel ResultModel { get; set; }

    }
}
