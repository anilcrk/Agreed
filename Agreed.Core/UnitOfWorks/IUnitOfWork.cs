using Agreed.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Agreed.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IOrderRepository Orders { get; }
        Task CommitAsync();
        void Commit();
    }
}
