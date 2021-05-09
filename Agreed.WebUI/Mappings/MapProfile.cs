using Agreed.Core.Entities;
using Agreed.WebUI.DTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agreed.WebUI.Mappings
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Order, OrderDto>();
            CreateMap<OrderDto, Order>();

            CreateMap<Commission, CommissionDto>();
            CreateMap<CommissionDto, Commission>();

            CreateMap<Cargo, CargoDto>();
            CreateMap<CargoDto, Cargo>();

            CreateMap<UserDto, User>();
            CreateMap<User, UserDto>();

            CreateMap<Company, CompanyDto>();
            CreateMap<CompanyDto, Company>();
        }
    }
}
