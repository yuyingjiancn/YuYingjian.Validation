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
        /// 判断是否匹配正则表达式
        /// </summary>
        /// <param name="v"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static ValidationContext IsMatch(this object v, string pattern)
        {
            bool state = false;
            var s = v as string;
            if(s != null)
                state = System.Text.RegularExpressions.Regex.IsMatch(s, pattern);
            return new ValidationContext
            {
                IsValid = state,
                Value = v,
                Message = "正则表达式不匹配"
            };
        }

        public static ValidationContext IsMatch(this ValidationContext vc, string pattern)
        {
            if (!vc.IsValid) return vc;
            return vc.Value.ToString().IsMatch(pattern);
        }
    }
}
