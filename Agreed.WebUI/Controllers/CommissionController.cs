﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agreed.Core.Constants;
using Agreed.WebUI.Authorize;
using Agreed.WebUI.DTOs;
using Agreed.WebUI.Helpers.ExcelModelHelper;
using Agreed.WebUI.Models.ViewModels;
using Agreed.WebUI.ModelServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agreed.WebUI.Controllers
{
    [Authorize]
    [AuthorizeRoles(Role.Administrator)]
    public class CommissionController : Controller
    {
        private readonly CommissionModelService _modelService;

        public CommissionController(CommissionModelService modelService)
        {
            _modelService = modelService;
        }
        public IActionResult Index()
        {
            var model = new CommissionViewModel();
            model.ResultModel = null;

            return View(model);
        }

        [HttpPost]
        [Obsolete]
        public async Task<IActionResult> Index(IFormFile commissionReportFile, [FromServices] IHostingEnvironment hostingEnvironment)
        {
            var model = new CommissionViewModel();

            if (commissionReportFile == null)
            {
                return View(model);
            }

            string fileName = $"{hostingEnvironment.WebRootPath}\\files\\";
            var commissions = new List<CommissionDto>();

            try
            {
                commissions = await CommissionModelHelper.ReadCommision(commissionReportFile, fileName);
            }
            catch (Exception ex)
            {
                model.ResultModel.Success = false;
                model.ResultModel.Message = ex.Message;
                return View(model);
            }


            return View(await _modelService.AddRange(commissions));
        }
    }
}