using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agreed.Core.Constants;
using Agreed.WebUI.Authorize;
using Agreed.WebUI.Models.ViewModels;
using Agreed.WebUI.ModelServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agreed.WebUI.Controllers
{
    [Authorize]
    [AuthorizeRoles(Role.Administrator)]
    public class CompanyController : Controller
    {
        private readonly CompanyModelService _modelService;
        private readonly int _userCompanyId;
        public CompanyController(CompanyModelService modelService, IHttpContextAccessor contextAccessor)
        {
            _modelService = modelService;
            _userCompanyId = Convert.ToInt32(contextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == Core.Enums.ClaimTypes.CompanyId.ToString()).Value);
        }
        public async Task<IActionResult> Index()
        {
            return View(await _modelService.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Index(string companyName)
        {
            return View(await _modelService.Add(companyName));
        }
    }
}