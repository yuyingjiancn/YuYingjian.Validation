using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuYingjian.Validation.Validator
{
    public static partial class Validator
    {
        private static readonly string _password = "^[a-zA-Z0-9`~!@#\\$%\\^&\\*\\(\\)\\-_\\+=\\\\\\|\\\\[\\{\\]\\}:;\"\',<.>/\\?]+$";

        public static ValidationContext IsPassword(this object v)
        {
            bool state = false;
            if (v is string)
            {
                state = System.Text.RegularExpressions.Regex.IsMatch(v.ToString(), _password);
            }           
            return new ValidationContext
            {
                IsValid = state,
                Value = v,
                Message = string.Format("密码必须是大小写英文字母、数字、英文标点符号组成")
            };
        }

        public static ValidationContext IsPassword(this ValidationContext vc)
        {
            if (!vc.IsValid) return vc;
            return vc.Value.ToString().IsPassword();
        }
    }
}
