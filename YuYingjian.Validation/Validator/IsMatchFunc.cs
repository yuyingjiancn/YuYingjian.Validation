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
        /// 判断是否匹配方法验证结果
        /// </summary>
        /// <param name="v"></param>
        /// <param name="matchFunc"></param>
        /// <returns></returns>
        public static ValidationContext IsMatchFunc(this object v, Func<object, bool> matchFunc )
        {
            bool state = v != null && matchFunc.Invoke(v);

            return new ValidationContext
            {
                IsValid = state,
                Value = v,
                Message = "无法通过方法验证"
            };
        }

        public static ValidationContext IsMatchFunc(this ValidationContext vc, Func<object, bool> matchFunc)
        {
            if (!vc.IsValid) return vc;
            return vc.Value.IsMatchFunc(matchFunc);
        }
    }
}
