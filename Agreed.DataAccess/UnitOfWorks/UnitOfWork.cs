using Agreed.Core.Repositories;
using Agreed.Core.UnitOfWorks;
using Agreed.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Agreed.DataAccess.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appContext;
        private OrderRepository _orderRepository;
        public IOrderRepository Orders => _orderRepository = _orderRepository ?? new OrderRepository(_appContext);

        public UnitOfWork(AppDbContext appDbContext)
        {
            _appContext = appDbContext;
        }
        public void Commit()
        {
            _appContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _appContext.SaveChangesAsync();
        }
    }
}
