using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuYingjian.Validation.Validator
{
    public static partial class Validator
    {
        private static readonly string _numeric = "^[-+]?[0-9]+$";

        /// <summary>
        /// 判断是否是数字
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static ValidationContext IsNumeric(this object v)
        {
            bool state = false;
            var s = v as string;
            if (s != null)
            {
                state = System.Text.RegularExpressions.Regex.IsMatch(s, _numeric);
            }           
            return new ValidationContext
            {
                IsValid = state,
                Value = v,
                Message = "必须是数字"
            };
        }

        public static ValidationContext IsNumeric(this ValidationContext vc)
        {
            if (!vc.IsValid) return vc;
            return vc.Value.IsNumeric();
        }
    }
}
