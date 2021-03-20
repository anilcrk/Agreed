using Agreed.Core.Entities;
using Agreed.Core.Repositories;
using Agreed.Core.Services;
using Agreed.Core.UnitOfWorks;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Agreed.Service.Services
{
    public class OrderService : Service<Order>, IOrderService
    {
        public OrderService(IUnitOfWork unitOfWork, IRepository<Order> repository) : base(unitOfWork, repository)
        {

        }
    }
}
