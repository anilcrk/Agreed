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
        private UserRepository _userRepository;
        public IOrderRepository Orders => _orderRepository = _orderRepository ?? new OrderRepository(_appContext);
        public IUserRepository Users => _userRepository = _userRepository ?? new UserRepository(_appContext);

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
