using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Agreed.Core.Enums
{
    public enum OrderStatus
    {
        Created
    }

    public enum ClaimTypes
    {
        [Description("CompanyId")]
        CompanyId = 0,
        UserId
    }
}
