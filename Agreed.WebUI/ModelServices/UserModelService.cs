using Agreed.Core.Constants;
using Agreed.Core.Entities;
using Agreed.Core.Helpers.Cryption;
using Agreed.Core.Service;
using Agreed.WebUI.DTOs;
using Agreed.WebUI.Models;
using Agreed.WebUI.Models.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Agreed.WebUI.ModelServices
{
    public class UserModelService
    {
        private readonly IService<User> _service;
        private readonly IMapper _mapper;
        private readonly IService<Company> _companyService;
        private readonly IService<OperationClaim> _operationClaimService;
        private readonly IService<UserOperationClaim> _userOperationClaimService;
        public UserModelService(IService<User> service, IMapper mapper, IService<Company> companyService, IService<OperationClaim> operationClaimService, IService<UserOperationClaim> userOperationClaimService)
        {
            _service = service;
            _mapper = mapper;
            _companyService = companyService;
            _operationClaimService = operationClaimService;
            _userOperationClaimService = userOperationClaimService;
        }

        public async Task<List<UserDto>> GetAll()
        {
            var users = await _service.GetAllAsync();
            var userDtos = new List<UserDto>();

            foreach (var item in users)
            {
                userDtos.Add(new UserDto
                {
                    Email = AES256.DecodeAndDecrypt(item.Email),
                    Password = AES256.DecodeAndDecrypt(item.Password),
                    CompanyId = item.CompanyId,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Status = item.Status,
                });
            }

            return userDtos;
        }

        public async Task<List<SelectListItem>> GetAllCompanies()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();

            var companies = await _companyService.GetAllAsync();


            foreach (var item in companies)
            {
                selectListItems.Add(new SelectListItem
                {

                    Value = item.Id.ToString(),
                    Text = item.CompanyName
                });
            }

            return selectListItems;
        }

        public async Task<List<SelectListItem>> GetAllRoles()
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();

            var roles = await _operationClaimService.GetAllAsync();


            foreach (var item in roles)
            {
                selectListItems.Add(new SelectListItem
                {

                    Value = item.Id.ToString(),
                    Text = item.Name
                });
            }

            return selectListItems;
        }

        public async Task<ResultModel> AddAsync(UserDto user)
        {
            ResultModel resultModel = new ResultModel();

            try
            {
                var userControl = _service.SingleOrDefaultAsync(u => u.Email == AES256.EncryptAndEncode(user.Email));

                if (userControl.Result != null)
                {
                    resultModel.Message = $"Bu email'e ait kullanıcı kayıdı zaten mevcut. Ad : {userControl.Result.FirstName}, Soyad : {userControl.Result.LastName}";
                    return resultModel;
                }

                user.Email = AES256.EncryptAndEncode(user.Email);
                user.Password = AES256.EncryptAndEncode(user.Password);

                var userResult = await _service.AddAsync(_mapper.Map<User>(user));

                await _userOperationClaimService.AddAsync(new UserOperationClaim
                {
                    OperationClaimId = user.RoleId,
                    UserId = userResult.Id
                });

                resultModel.Message = "Kullanıcı başarılı bir şekilde eklendi. (top ali)";
                resultModel.Success = true;
            }
            catch (Exception ex)
            {
                resultModel.Message = $"HATA ! - {ex.Message}";
                resultModel.Success = false;
            }

            return resultModel;
        }
    }
}
