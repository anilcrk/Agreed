using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agreed.WebUI.Controllers
{
    public class BaseController : Controller
    {
        protected int _userCompanyId;
        public BaseController(IHttpContextAccessor contextAccessor)
        {

            _userCompanyId =Convert.ToInt32(contextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "companyId").Value);
        }
    }
}