﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agreed.WebUI.Authorize;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Agreed.Core.Constants;
using Agreed.WebUI.ModelServices;
using Agreed.WebUI.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Agreed.WebUI.DTOs;
using Agreed.WebUI.Helpers.ExcelModelHelper;

namespace Agreed.WebUI.Controllers
{
    [Authorize]
    [AuthorizeRoles(Role.Administrator)]
    public class CargoController : Controller
    {
        private readonly CargoModelService _modelService;

        public CargoController(CargoModelService modelService)
        {
            _modelService = modelService;
        }
        public IActionResult Index()
        {
            var model = new CargoViewModel();
            model.ResultModel = null;

            return View(model);
        }

        [HttpPost]
        [Obsolete]
        public async Task<IActionResult> Index(IFormFile cargoReportFile, [FromServices] IHostingEnvironment hostingEnvironment)
        {
            var model = new CargoViewModel();

            if (cargoReportFile == null)
            {
                return View(model);
            }

            string fileName = $"{hostingEnvironment.WebRootPath}\\files\\";
            var cargoes = new List<CargoDto>();

            try
            {
                cargoes = await CargoModelHelper.ReadCargo(cargoReportFile, fileName);
            }
            catch (Exception ex)
            {
                model.ResultModel.Success = false;
                model.ResultModel.Message = ex.Message;
                return View(model);
            }


            return View(await _modelService.AddRange(cargoes));
        }
    }
}