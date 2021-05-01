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
    public class CargoModelService
    {
        private readonly IService<Cargo> _service;
        private readonly IMapper _mapper;
        public CargoModelService(IService<Cargo> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<CargoViewModel> AddRange(List<CargoDto> cargoes)
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

                await _service.AddRangeAsync(_mapper.Map<IEnumerable<Cargo>>(cargoes));

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
