using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuYingjian.Validation.Validator
{
    public static partial class Validator
    {
        private static readonly string _alpha = "^[a-zA-Z]+$";

        /// <summary>
        /// 判断是否是大小写英文字母
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static ValidationContext IsAlpha(this object v)
        {
            bool state = false;
            var s = v as string;
            if (s != null)
            {
                state = System.Text.RegularExpressions.Regex.IsMatch(s, _alpha);
            }           
            return new ValidationContext
            {
                IsValid = state,
                Value = v,
                Message = "必须是大小写英文字母"
            };
        }

        public static ValidationContext IsAlpha(this ValidationContext vc)
        {
            if (!vc.IsValid) return vc;
            return vc.Value.IsAlpha();
        }
    }
}
