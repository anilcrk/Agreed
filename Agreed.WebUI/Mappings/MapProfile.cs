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
        }
    }
}
