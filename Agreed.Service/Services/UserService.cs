using Agreed.Core.Entities;
using Agreed.Core.Helpers.Cryption;
using Agreed.Core.Repositories;
using Agreed.Core.Services;
using Agreed.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Agreed.Service.Services
{
    public class UserService:Service<User>, IUserService
    {
        public UserService(IUnitOfWork unitOfWork, IRepository<User> repository) : base(unitOfWork, repository)
        {

        }

        public async Task<User> LoginControlAsync(User userLogin)
        {
            try
            {
                var user = await _unitOfWork.Users.SingleOrDefaultAsync(u => u.Email == AES256.EncryptAndEncode(userLogin.Email) && u.Password == AES256.EncryptAndEncode(userLogin.Password));

                return user;
            }
            catch
            {
                return null;
            }
            
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _unitOfWork.Users.GetClaims(user);
        }
    }
}
