using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuYingjian.Validation.Validator
{
    public static partial class Validator
    {
        /// <summary>
        /// 用户账号只能是大小写英文字母、数字、下划线
        /// </summary>
        private static readonly string _account = "^[a-zA-Z0-9_]+$";

        public static ValidationContext IsAccount(this object v)
        {
            bool state = false;
            var s = v as string;
            if (s != null)
            {
                state = System.Text.RegularExpressions.Regex.IsMatch(s, _account);
            }           
            return new ValidationContext
            {
                IsValid = state,
                Value = v,
                Message = string.Format("密码必须是大小写英文字母、数字、英文标点符号组成")
            };
        }

        public static ValidationContext IsAccount(this ValidationContext vc)
        {
            if (!vc.IsValid) return vc;
            return vc.Value.IsAccount();
        }
    }
}
