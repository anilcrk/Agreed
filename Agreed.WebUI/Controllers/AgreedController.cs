using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agreed.WebUI.Models.ViewModels;
using Agreed.WebUI.ModelServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agreed.WebUI.Controllers
{
    public class AgreedController : Controller
    {
        private readonly AgreedModelService _modelService;
        private readonly int _userCompanyId;

        public AgreedController(AgreedModelService modelService, IHttpContextAccessor contextAccessor)
        {
            _modelService = modelService;
            _userCompanyId = Convert.ToInt32(contextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == Core.Enums.ClaimTypes.CompanyId.ToString()).Value);
        }

        public async Task<IActionResult> Index()
        {
            var model = new AgreedViewModel();

            var orders = await _modelService.GetAgrrededOrders(_userCompanyId);
            model.Orders = orders;

            return View(model);
        }
    }
}