using Agreed.Core.Entities;
using Agreed.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agreed.DataAccess.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private AppDbContext appDbContext { get => _dbContext as AppDbContext; }
        public UserRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public List<OperationClaim> GetClaims(User user)
        {
            var result = from operationClaim in appDbContext.OperationClaims
                         join userOperationClaim in appDbContext.UserOperationClaims
                         on operationClaim.Id equals userOperationClaim.OperationClaimId
                         where userOperationClaim.UserId == user.Id
                         select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };

            return result.ToList();
        }
    }
}
