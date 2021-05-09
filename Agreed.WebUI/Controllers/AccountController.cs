using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Agreed.Core.Entities;
using Agreed.Core.Services;
using Agreed.WebUI.Models.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Agreed.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        public AccountController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {


            var user = await _userService.LoginControlAsync(new Core.Entities.User
            {
                Email = model.Email,
                Password = model.Password
            });

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Login Hatası");
                return RedirectToAction("Index", "Account");
            }

            var userClaims = _userService.GetClaims(user);

            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,user.FirstName + " " + user.LastName),
                    new Claim(ClaimTypes.Role,string.Join(",", userClaims.Select(uc=>uc.Name))),
                    new Claim(type:Core.Enums.ClaimTypes.CompanyId.ToString(), string.Join(",", user.CompanyId)),
                    new Claim(type:Core.Enums.ClaimTypes.UserId.ToString(), string.Join(",", user.Id))
                };

            var identity = new ClaimsIdentity
            (
                claims, CookieAuthenticationDefaults.AuthenticationScheme
            );
            var pricipal = new ClaimsPrincipal(identity);
            var props = new AuthenticationProperties();

            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, pricipal, props).Wait();

            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Index");
        }
    }
}