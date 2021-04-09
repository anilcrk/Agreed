using Agreed.Core.Entities;
using Agreed.Core.Services;
using Agreed.WebUI.DTOs;
using Agreed.WebUI.Models.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agreed.WebUI.ModelServices
{
    public class OrderModelService
    {
        private readonly IOrderService _service;
        private readonly IMapper _mapper;
        public OrderModelService(IOrderService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<OrderViewModel> AddRange(List<OrderDto> orders)
        {
            var model = new OrderViewModel();

            if(orders?.Count == 0)
            {
                model.ResultModel.Success = false;
                model.ResultModel.Message = "Hiç Kayıt Bulunamadı !";

                return model;
            }

            await _service.AddRangeAndControlAsync(_mapper.Map<IEnumerable<Order>>(orders));

            model.ResultModel.Success = true;
            model.ResultModel.Message = $"{orders.Count} adet sipariş başarılı bir şekilde yüklendi.";

            return model;
        }
    }
}
