using Agreed.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Agreed.Core.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}
