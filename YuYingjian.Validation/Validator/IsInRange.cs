using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using YuYingjian.Validation.Internal;

namespace YuYingjian.Validation.Validator
{
    public static partial class Validator
    {
        /// <summary>
        /// 大于等于min 小于等于max
        /// </summary>
        /// <param name="v"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static ValidationContext IsInRange(this object v, IComparable min, IComparable max)
        {
            var value = v as IComparable;
            bool state = value != null && Comparer.GetComparisonResult(value, min) >= 0 && Comparer.GetComparisonResult(value, max) <= 0;
            
            return new ValidationContext
            {
                IsValid = state,
                Value = v,
                Message = string.Format("必须大于等于{0},小于等于{1}", min, max)
            };
        }

        public static ValidationContext IsInRange(this ValidationContext vc, IComparable min, IComparable max)
        {
            if (!vc.IsValid) return vc;
            return vc.Value.IsInRange(min, max);
        }
    }
}
