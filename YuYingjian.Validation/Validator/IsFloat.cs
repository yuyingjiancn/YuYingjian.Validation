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
        /// 判断字符串是否可以转换为float类型
        /// </summary>
        /// <param name="v" type="string"></param>
        /// <returns>将转换后的float值存入ValidationContext的Value中</returns>
        public static ValidationContext IsFloat(this string v)
        {
            float result = 0;
            bool state = float.TryParse(v.ToString(), out result);       
            return new ValidationContext
            {
                IsValid = state,
                Value = state ? (object)result : v,
                Message = "必须是[float]"
            };
        }

        public static ValidationContext IsFloat(this ValidationContext vc)
        {
            if (!vc.IsValid) return vc;
            return vc.Value.ToString().IsFloat();
        }
    }
}
