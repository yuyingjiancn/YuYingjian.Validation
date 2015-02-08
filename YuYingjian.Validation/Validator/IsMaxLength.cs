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
        /// 字符串长度最多是max
        /// </summary>
        /// <param name="v"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static ValidationContext IsMaxLength(this object v, int max)
        {
            bool state = false;
            var s = v as string;
            if (s != null)
            {
                var len = s.Length;
                state = len <= max;
            }
            
            return new ValidationContext
            {
                IsValid = state,
                Value = v,
                Message = string.Format("长度至少是{0}个字符", max)
            };
        }

        public static ValidationContext IsMaxLength(this ValidationContext vc, int max)
        {
            if (!vc.IsValid) return vc;
            return vc.Value.ToString().IsMaxLength(max);
        }
    }
}
