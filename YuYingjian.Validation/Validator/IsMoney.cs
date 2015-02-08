using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace YuYingjian.Validation.Validator
{
    public static partial class Validator
    {
        //货币正则
        private static readonly Regex RegMoney = new Regex(@"^\d+(?:\.\d{1,2})?$", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture);
        
        public static ValidationContext IsMoney(this object v)
        {
            //考虑到需要与decimal连缀，所以代码如下
            bool state = v != null && RegMoney.Match(v.ToString()).Length > 0;
            return new ValidationContext
            {
                IsValid = state,
                Value = v,
                Message = "币种格式错误"
            };
        }

        public static ValidationContext IsMoney(this ValidationContext vc)
        {
            if (!vc.IsValid) return vc;
            return vc.Value.IsMoney();
        }
    }
}
