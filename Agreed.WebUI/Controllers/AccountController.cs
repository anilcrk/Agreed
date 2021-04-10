using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agreed.Core.Services;
using Agreed.WebUI.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Agreed.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var user = _userService.Where(u => u.Email == model.Email);

            if(user == null)
            {
                ModelState.AddModelError(string.Empty, "Kullanıcı bulunamadı !");
                return View();
            }

            return View();

        }

    }
}