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
    [AuthorizeRoles(Role.Administrator)]
    public class OrderController : Controller
    {
        private readonly IOrderService _service;
        private readonly IMapper _mapper;
        private readonly OrderModelService _modelService;

        public OrderController(IOrderService service, IMapper mapper, OrderModelService modelService)
        {
            _service = service;
            _mapper = mapper;
            _modelService = modelService;
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

            if(orderReportFile == null)
            {
                return View(model);
            }

            string fileName = $"{hostingEnvironment.WebRootPath}\\files\\";
            var orders = new List<OrderDto>();

            try
            {
                orders = await OrderModelHelper.ReadOrder(orderReportFile, fileName);
            }
            catch(Exception ex)
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