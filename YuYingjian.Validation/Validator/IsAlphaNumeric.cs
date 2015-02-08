using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuYingjian.Validation.Validator
{
    public static partial class Validator
    {
        private static readonly string _alphaNumeric = "^[a-zA-Z0-9]+$";

        /// <summary>
        /// 判断是否是数字
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static ValidationContext IsAlphaNumeric(this object v)
        {
            bool state = false;
            var s = v as string;
            if (s != null)
            {
                state = System.Text.RegularExpressions.Regex.IsMatch(s, _alphaNumeric);
            }           
            return new ValidationContext
            {
                IsValid = state,
                Value = v,
                Message = "必须是大小写英文字母数字"
            };
        }

        public static ValidationContext IsAlphaNumeric(this ValidationContext vc)
        {
            if (!vc.IsValid) return vc;
            return vc.Value.IsAlphaNumeric();
        }
    }
}
