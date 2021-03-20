using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agreed.Core.Entities;
using Agreed.Core.Services;
using Agreed.WebUI.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Agreed.WebUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _service;
        private readonly IMapper _mapper;

        public OrderController(IOrderService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetAll()
        {
            var orders = await _service.GetAllAsync();

            return View(_mapper.Map<IEnumerable<OrderDto>>(orders));
        }
    }
}