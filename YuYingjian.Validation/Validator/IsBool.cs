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
        /// 判断字符串是否可以转换为bool类型
        /// </summary>
        /// <param name="v" type="string"></param>
        /// <returns>将转换后的bool值存入ValidationContext的Value中</returns>
        public static ValidationContext IsBool(this object v)
        {
            bool result = false;
            bool state = v != null && bool.TryParse(v.ToString(), out result);
            return new ValidationContext
            {
                IsValid = state,
                Value = state ? result : v,
                Message = "必须是布尔型[bool]"
            };
        }

        public static ValidationContext IsBool(this ValidationContext vc)
        {
            if (!vc.IsValid) return vc;
            return vc.Value.ToString().IsBool();
        }
    }
}
