using Agreed.Core.Entities;
using Agreed.Core.Repositories;
using Agreed.Core.Services;
using Agreed.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agreed.Service.Services
{
    public class CompanyService:Service<Company>, ICompanyService
    {
        public CompanyService(IUnitOfWork unitOfWork, IRepository<Company> repository) : base(unitOfWork, repository)
        {

        }
    }
}
