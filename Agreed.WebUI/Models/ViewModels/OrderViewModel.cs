using Agreed.Core.Entities;
using Agreed.WebUI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agreed.WebUI.Models.ViewModels
{
    public class OrderViewModel
    {
        public OrderViewModel()
        {
            Orders = new List<Order>();
            ResultModel = new ResultModel();
        }
        public List<Order> Orders{ get; set; }

        public ResultModel ResultModel { get; set; }
    }
}
