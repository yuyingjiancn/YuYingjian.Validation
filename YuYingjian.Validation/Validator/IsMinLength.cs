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
        /// 字符串长度最少是min
        /// </summary>
        /// <param name="v"></param>
        /// <param name="min"></param>
        /// <returns></returns>
        public static ValidationContext IsMinLength(this object v, int min)
        {
            bool state = false;
            var s = v as string;
            if (s != null)
            {
                var len = s.Length;
                state = len >= min;
            }
            
            return new ValidationContext
            {
                IsValid = state,
                Value = v,
                Message = string.Format("长度至少是{0}个字符", min)
            };
        }

        public static ValidationContext IsMinLength(this ValidationContext vc, int min)
        {
            if (!vc.IsValid) return vc;
            return vc.Value.IsMinLength(min);
        }
    }
}
