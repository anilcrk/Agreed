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
    public class CompanyModelService
    {
        private readonly ICompanyService _service;
        private readonly IMapper _mapper;
        public CompanyModelService(ICompanyService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<CompanyViewModel> GetAllAsync()
        {
            var model = new CompanyViewModel();

            var companies = await _service.GetAllAsync();
            // Geçici olarak yazıldı düzeltilecek
            List<CompanyDto> companyDtos = new List<CompanyDto>();
            foreach (var item in companies)
            {
                companyDtos.Add(new CompanyDto { CompanyName = item.CompanyName, Id=item.Id });
            }

            model.Companies = companyDtos;
            model.ResultModel = null;

            return model;
        }

        public async Task<CompanyViewModel> Add(string companyName)
        {
            var model = new CompanyViewModel();

            await _service.AddAsync(new Company { CompanyName = companyName });

            var companies = await _service.GetAllAsync();
            // Geçici olarak yazıldı düzeltilecek
            List<CompanyDto> companyDtos = new List<CompanyDto>(); ;
            foreach (var item in companies)
            {
                companyDtos.Add(new CompanyDto { CompanyName = item.CompanyName, Id=item.Id });
            }

            model.Companies = companyDtos;

            model.ResultModel.Success = true;
            model.ResultModel.Message = $"Şirket Başarılı bir şekilde eklendi.";

            return model;
        }
    }
}
