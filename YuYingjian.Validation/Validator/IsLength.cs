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
        /// 字符串长度最少是min,做多是max
        /// </summary>
        /// <param name="v"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static ValidationContext IsLength(this object v, int min, int max)
        {
            bool state = false;
            var s = v as string;
            if (s != null)
            {
                var len = s.Length;
                state = len >= min && len <= max;
            }
            return new ValidationContext
            {
                IsValid = state,
                Value = v,
                Message = string.Format("长度是{0}~{1}个字符", min, max)
            };
        }

        public static ValidationContext IsLength(this ValidationContext vc, int min, int max)
        {
            if (!vc.IsValid) return vc;
            return vc.Value.IsLength(min, max);
        }
    }
}
