using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agreed.Core.Constants;
using Agreed.Core.Entities;
using Agreed.Core.Service;
using Agreed.WebUI.Authorize;
using Agreed.WebUI.DTOs;
using Agreed.WebUI.Models.ViewModels;
using Agreed.WebUI.ModelServices;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agreed.WebUI.Controllers
{
    [Authorize]
    [AuthorizeRoles(Role.Administrator)]
    public class UserController : Controller
    {
        private readonly int _userCompanyId;
        private readonly int _userId;
        private readonly IService<User> _service;
        private readonly IMapper _mapper;
        private readonly UserModelService _modelService;
        private readonly IService<Company> _companyModelService;

        public UserController(IService<User> service, IService<Company> companyService, IMapper mapper, IHttpContextAccessor contextAccessor, UserModelService modelService)
        {
            _service = service;
            _mapper = mapper;
            _userCompanyId = Convert.ToInt32(contextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == Core.Enums.ClaimTypes.CompanyId.ToString()).Value);
            _userId = Convert.ToInt32(contextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == Core.Enums.ClaimTypes.UserId.ToString()).Value);
            _modelService = modelService;
            _companyModelService = companyService;
        }
        public async Task<IActionResult> Index()
        {
            var model = new UserViewModel();
            var users = await _service.GetAllAsync();
            var companies = await _companyModelService.GetAllAsync();

            model.ResultModel = null;
            model.Users = await _modelService.GetAll();
            model.Companies = await _modelService.GetAllCompanies();
            model.UserRoles = await _modelService.GetAllRoles();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserViewModel userViewModel)
        {
            userViewModel.ResultModel = await _modelService.AddAsync(userViewModel.User);
            userViewModel.Companies = await _modelService.GetAllCompanies();
            userViewModel.Users = await _modelService.GetAll();
            userViewModel.UserRoles = await _modelService.GetAllRoles();

            return View(userViewModel);
        }

    }
}