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
        /// 必须大于 c
        /// </summary>
        /// <param name="v" type="object">考虑到不一定是string类型传入，可能还有其它类型如int, double等</param>
        /// <param name="c" interface="IComparable"></param>
        /// <returns></returns>
        public static ValidationContext GreaterThan(this object v, IComparable c)
        {
            bool state = false;

            if (v is IComparable)
            {
                state = Comparer.GetComparisonResult((IComparable)v, c) > 0;
            }
            
            return new ValidationContext
            {
                IsValid = state,
                Value = v,
                Message = string.Format("必须大于{0}", c)
            };
        }

        public static ValidationContext GreaterThan(this ValidationContext vc, IComparable c)
        {
            if (!vc.IsValid) return vc;
            return vc.Value.GreaterThan(c);
        }
    }
}
