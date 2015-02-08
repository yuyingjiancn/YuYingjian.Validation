using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuYingjian.Validation.Validator
{
    public static partial class Validator
    {
        private static readonly string _mobilePhone = @"^(\+?0?86\-?)?1[345789][0-9]{9}$";

        public static ValidationContext IsMobilePhoneChina(this object v)
        {
            bool state = false;
            var s = v as string;
            state = s != null && System.Text.RegularExpressions.Regex.IsMatch(s, _mobilePhone);
            return new ValidationContext
            {
                IsValid = state,
                Value = v,
                Message = string.Format("手机号码格式不正确")
            };
        }

        public static ValidationContext IsMobilePhoneChina(this ValidationContext vc)
        {
            if (!vc.IsValid) return vc;
            return vc.Value.IsMobilePhoneChina();
        }
    }
}
