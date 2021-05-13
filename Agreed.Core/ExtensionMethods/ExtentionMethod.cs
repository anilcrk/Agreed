using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Agreed.Core.ExtensionMethods
{
    public static class ExtentionMethod
    {
        public static decimal ExConvertToDecimal(this object value)
        {
            if(value == null)
            {
                return 0.0m;
            }

            return Convert.ToDecimal(value.ToString().Replace('.', ','));
        }
    }
}
