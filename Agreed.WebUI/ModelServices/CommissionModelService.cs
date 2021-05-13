using Agreed.Core.Entities;
using Agreed.Core.Service;
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
    public class CommissionModelService
    {
        private readonly IService<Commission> _service;
        private readonly IMapper _mapper;
        private readonly IOrderService _orderService;
        public CommissionModelService(IService<Commission> service, IMapper mapper, IOrderService orderService)
        {
            _service = service;
            _mapper = mapper;
            _orderService = orderService;
        }

        public async Task<CommissionViewModel> AddRange(List<CommissionDto> commissions, int companyId)
        {
            var model = new CommissionViewModel();

            try
            {
                if (commissions?.Count == 0)
                {
                    model.ResultModel.Success = false;
                    model.ResultModel.Message = "Hiç Kayıt Bulunamadı !";

                    return model;
                }

                var commissionResult = await _service.AddRangeAsync(_mapper.Map<IEnumerable<Commission>>(commissions));

                if(commissionResult.Any())
                {
                    IEnumerable<Order> orders = null;

                    foreach (var item in commissionResult)
                    {
                        orders = await _orderService.Where(o => o.CompanyId == companyId && o.OrderNumber == item.OrderNumber);

                        if (orders != null)
                        {
                            foreach (var orderItem in orders)
                            {
                                orderItem.CommissionId = item.Id;
                                orderItem.CommissionStatus = true;

                                _orderService.Update(orderItem);
                            }
                        }
                    }
                }

                model.ResultModel.Success = true;
                model.ResultModel.Message = $"{commissions.Count} adet komisyon detayı başarılı bir şekilde yüklendi.";

                return model;
            }
            catch (Exception ex)
            {
                model.ResultModel.Success = false;
                model.ResultModel.Message = $"HATA ! - HATA MESAJI : {ex.Message}";
                return model;
            }
        }
    }
}
