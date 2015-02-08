using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuYingjian.Validation.Validator
{
    public static partial class Validator
    {
        private static readonly string _hexadecimal = "^[0-9a-fA-F]+$";

        /// <summary>
        /// 判断是否是16进制数
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static ValidationContext IsHexadecimal(this object v)
        {
            bool state = false;
            var s = v as string;
            if (s != null)
            {
                state = System.Text.RegularExpressions.Regex.IsMatch(s, _hexadecimal);
            }           
            return new ValidationContext
            {
                IsValid = state,
                Value = v,
                Message = "必须是16进制数"
            };
        }

        public static ValidationContext IsHexadecimal(this ValidationContext vc)
        {
            if (!vc.IsValid) return vc;
            return vc.Value.IsHexadecimal();
        }
    }
}
