using Agreed.Core.Entities;
using Agreed.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Agreed.Core.Services
{
    public interface IUserService : IService<User>
    {
        public Task<User> SingleOrDefaulEncryptAsync(Expression<Func<User, bool>> predicate);
    }
}
