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
        /// 对象不能为null
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static ValidationContext IsNull(this object v)
        {
            bool state = v == null;
            return new ValidationContext
            {
                IsValid = state,
                Value = v,
                Message = "对象不能为null"
            };
        }

        public static ValidationContext IsNull(this ValidationContext vc)
        {
            if (!vc.IsValid) return vc;
            return vc.Value.IsNull();
        }
    }
}
