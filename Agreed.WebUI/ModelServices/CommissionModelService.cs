using Agreed.Core.Entities;
using Agreed.Core.Service;
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
        public CommissionModelService(IService<Commission> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<CommissionViewModel> AddRange(List<CommissionDto> orders)
        {
            var model = new CommissionViewModel();

            try
            {
                if (orders?.Count == 0)
                {
                    model.ResultModel.Success = false;
                    model.ResultModel.Message = "Hiç Kayıt Bulunamadı !";

                    return model;
                }

                await _service.AddRangeAsync(_mapper.Map<IEnumerable<Commission>>(orders));

                model.ResultModel.Success = true;
                model.ResultModel.Message = $"{orders.Count} adet komisyon detayı başarılı bir şekilde yüklendi.";

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
