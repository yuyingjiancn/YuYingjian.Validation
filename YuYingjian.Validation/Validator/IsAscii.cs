using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuYingjian.Validation.Validator
{
    public static partial class Validator
    {
        private static readonly string _ascii = "^[\x00-\x7F]+$";

        /// <summary>
        /// 判断是否是ascii码
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static ValidationContext IsAscii(this object v)
        {
            bool state = false;
            var s = v as string;
            if (s != null)
            {
                state = System.Text.RegularExpressions.Regex.IsMatch(s, _ascii);
            }           
            return new ValidationContext
            {
                IsValid = state,
                Value = v,
                Message = "必须是ascii码"
            };
        }

        public static ValidationContext IsAscii(this ValidationContext vc)
        {
            if (!vc.IsValid) return vc;
            return vc.Value.IsAscii();
        }
    }
}
