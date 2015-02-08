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
        /// 判断字符串是否可以转换为decimal类型
        /// </summary>
        /// <param name="v" type="string"></param>
        /// <returns>将转换后的decimal值存入ValidationContext的Value中</returns>
        public static ValidationContext IsDecimal(this string v)
        {
            decimal result = 0;
            bool state = decimal.TryParse(v.ToString(), out result);
            
            return new ValidationContext
            {
                IsValid = state,
                Value = state ? (object)result : v,
                Message = "必须是[decimal]"
            };
        }

        public static ValidationContext IsDecimal(this ValidationContext vc)
        {
            if (!vc.IsValid) return vc;
            return vc.Value.ToString().IsDecimal();
        }
    }
}
