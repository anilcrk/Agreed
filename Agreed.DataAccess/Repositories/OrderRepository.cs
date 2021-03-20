using Agreed.Core.Entities;
using Agreed.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agreed.DataAccess.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private AppDbContext appDbContext { get => _dbContext as AppDbContext; }
        public OrderRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
