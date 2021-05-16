using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;
using Agreed.Core.Entities;
using Agreed.WebUI.Models.ViewModels;
using Agreed.WebUI.ModelServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Dynamic.Core;
using Agreed.Core.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Agreed.DataAccess;

namespace Agreed.WebUI.Controllers
{
    public class AgreedController : Controller
    {
        private readonly AgreedModelService _modelService;
        private readonly int _userCompanyId;
        private readonly DbContext _dbContext;
        public readonly DbSet<Order> _orderDbSet;

        public AgreedController(AgreedModelService modelService, IHttpContextAccessor contextAccessor, AppDbContext dbContext)
        {
            _modelService = modelService;
            _userCompanyId = Convert.ToInt32(contextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == Core.Enums.ClaimTypes.CompanyId.ToString()).Value);
            _dbContext = dbContext;
            _orderDbSet = dbContext.Set<Order>();
        }

        public async Task<IActionResult> Index()
        {
            var model = new AgreedViewModel();

            var orders = await _modelService.GetAgrrededOrders(_userCompanyId);
            model.Orders = orders;

            return View(model);
        }

        [HttpPost]
        public IActionResult GetAgreedItems()
        {
            var pageSize = int.Parse(Request.Form["length"]);
            var skip = int.Parse(Request.Form["start"]);

            var searchValue = Request.Form["search[value]"];

            var sortColumn = Request.Form[string.Concat("columns[", Request.Form["order[0][column]"], "][name]")];
            var sortColumnDirection = Request.Form["order[0][dir]"];


            IQueryable<Order> ordersFilter = _orderDbSet.Where(m => string.IsNullOrEmpty(searchValue) && m.CompanyId == _userCompanyId
                ? true
                : (m.OrderNumber.Contains(searchValue) 
                || m.Receiver.Contains(searchValue) 
                || m.PackageNumber.Contains(searchValue) 
                || m.Email.Contains(searchValue)) && m.CompanyId == _userCompanyId).ToList().AsQueryable();

            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
            {
                ordersFilter = ordersFilter.OrderBy(string.Concat(sortColumn, " ", sortColumnDirection));
            }

            var data = ordersFilter.Skip(skip).Take(pageSize).ToList();

            var recordsTotal = ordersFilter.Count();

            var jsonData = new { recordsFiltered = recordsTotal, recordsTotal, data };

            return Ok(jsonData);
        }
    }
}