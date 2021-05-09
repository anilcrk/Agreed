using Agreed.WebUI.DTOs;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agreed.WebUI.Models.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel()
        {
            Users = new List<UserDto>();
            ResultModel = new ResultModel();
            Companies = new List<SelectListItem>();
        }
        public List<UserDto> Users { get; set; }

        public UserDto User { get; set; }

        public List<SelectListItem> Companies { get; set; }

        public List<SelectListItem> UserRoles { get; set; }

        public ResultModel ResultModel { get; set; }
    }
}
