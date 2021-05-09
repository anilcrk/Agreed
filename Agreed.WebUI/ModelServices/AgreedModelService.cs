using Agreed.Core.Entities;
using Agreed.Core.Services;
using Agreed.WebUI.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agreed.WebUI.ModelServices
{
    public class AgreedModelService
    {
        private readonly IMapper _mapper;
        private readonly IOrderService _orderService;
        public AgreedModelService(IMapper mapper, IOrderService orderService)
        {
            _mapper = mapper;
            _orderService = orderService;
        }

        public async Task<List<Order>> GetAgrrededOrders(int companyId)
        {
            var orders = await _orderService.Where(o => o.CompanyId == companyId);

            return orders.ToList();
        }
    }
}
