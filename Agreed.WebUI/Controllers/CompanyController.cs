using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agreed.Core.Constants;
using Agreed.WebUI.Authorize;
using Agreed.WebUI.Models.ViewModels;
using Agreed.WebUI.ModelServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Agreed.WebUI.Controllers
{
    [Authorize]
    [AuthorizeRoles(Role.Administrator)]
    public class CompanyController : Controller
    {
        private readonly CompanyModelService _modelService;
        public CompanyController(CompanyModelService modelService)
        {
            _modelService = modelService;
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