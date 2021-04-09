using Agreed.Core.Entities;
using Agreed.Core.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Agreed.Core.Services
{
    public interface IOrderService : IService<Order>
    {
        Task<IEnumerable<Order>> AddRangeAndControlAsync(IEnumerable<Order> entities);
    }
}
