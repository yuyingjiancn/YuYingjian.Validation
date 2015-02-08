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
        /// 判断字符串是否可以转换为char类型
        /// </summary>
        /// <param name="v"></param>
        /// <returns>将转换后的char值存入ValidationContext的Value中</returns>
        public static ValidationContext IsChar(this object v)
        {
            char result = 'Y';
            bool state = v != null && char.TryParse(v.ToString(), out result);
            
            return new ValidationContext
            {
                IsValid = state,
                Value = state ? result : v,
                Message = "必须是整型[int]"
            };
        }

        public static ValidationContext IsChar(this ValidationContext vc)
        {
            if (!vc.IsValid) return vc;
            return vc.Value.IsChar();
        }
    }
}
