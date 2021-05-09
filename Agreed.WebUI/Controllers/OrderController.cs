using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Agreed.Core.Entities;
using Agreed.Core.Enums;
using Agreed.Core.Services;
using Agreed.WebUI.DTOs;
using AutoMapper;
using ExcelDataReader;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Agreed.WebUI.Models.ViewModels;
using Agreed.WebUI.Helpers.ExcelModelHelper;
using Agreed.WebUI.ModelServices;
using Agreed.WebUI.Authorize;
using Agreed.Core.Constants;
using Microsoft.AspNetCore.Authorization;

namespace Agreed.WebUI.Controllers
{
    [Authorize]
    [AuthorizeRoles(Role.Assistant, Role.Administrator)]
    public class OrderController : Controller
    {
        private readonly IOrderService _service;
        private readonly IMapper _mapper;
        private readonly OrderModelService _modelService;
        private readonly int _userCompanyId;

        public OrderController(IOrderService service, IMapper mapper, OrderModelService modelService, IHttpContextAccessor contextAccessor)
        {
            _service = service;
            _mapper = mapper;
            _modelService = modelService;
            _userCompanyId = Convert.ToInt32(contextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == Core.Enums.ClaimTypes.CompanyId.ToString()).Value);
        }
        public IActionResult Index()
        {
            var model = new OrderViewModel();
            model.ResultModel = null;

            return View(model);
        }

        [HttpPost]
        [Obsolete]
        public async Task<IActionResult> Index(IFormFile orderReportFile, [FromServices] IHostingEnvironment hostingEnvironment)
        {

            var model = new OrderViewModel();

            if (orderReportFile == null)
            {
                return View(model);
            }

            string fileName = $"{hostingEnvironment.WebRootPath}\\files\\";
            var orders = new List<OrderDto>();

            try
            {
                orders = await OrderModelHelper.ReadOrder(orderReportFile, fileName, _userCompanyId);
            }
            catch (Exception ex)
            {
                model.ResultModel.Success = false;
                model.ResultModel.Message = ex.Message;
                return View(model);
            }


            return View(await _modelService.AddRange(orders));
        }

        public async Task<IActionResult> GetAll()
        {
            var orders = await _service.GetAllAsync();

            return View(_mapper.Map<IEnumerable<OrderDto>>(orders));
        }

    }
}