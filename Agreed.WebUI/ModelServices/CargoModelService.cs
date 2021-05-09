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
    public class CargoModelService
    {
        private readonly IService<Cargo> _service;
        private readonly IMapper _mapper;
        private readonly IOrderService _orderService;
        public CargoModelService(IService<Cargo> service, IMapper mapper, IOrderService orderService)
        {
            _service = service;
            _mapper = mapper;
            _orderService = orderService;
        }

        public async Task<CargoViewModel> AddRange(List<CargoDto> cargoes, int companyId)
        {
            var model = new CargoViewModel();

            try
            {
                if (cargoes?.Count == 0)
                {
                    model.ResultModel.Success = false;
                    model.ResultModel.Message = "Hiç Kayıt Bulunamadı !";

                    return model;
                }

                var cargoResult = await _service.AddRangeAsync(_mapper.Map<IEnumerable<Cargo>>(cargoes));

                cargoResult = cargoResult.Where(c => c.ShipmentIsReturns.ToUpper() == "Gönderi".ToUpper()).ToList();

                if (cargoResult.Any())
                {
                    IEnumerable<Order> orders = null;

                    foreach (var item in cargoResult)
                    {
                        orders = await _orderService.Where(o => o.CompanyId == companyId && o.OrderNumber == item.OrderNo);

                        if (orders != null)
                        {
                            foreach (var orderItem in orders)
                            {
                                orderItem.CargoId = item.Id;
                                orderItem.CargoStatus = true;

                                _orderService.Update(orderItem);
                            }
                        }
                    }
                }

                model.ResultModel.Success = true;
                model.ResultModel.Message = $"{cargoes.Count} adet kargo detayı başarılı bir şekilde yüklendi.";

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
