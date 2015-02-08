using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuYingjian.Validation.Validator
{
    public static partial class Validator
    {
        private static readonly string _hexcolor = "^#?([0-9a-fA-F]{3}|[0-9a-fA-F]{6})$";

        /// <summary>
        /// 判断是否是16进制颜色代码 #ccc000 #ccc ccc ff0000
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static ValidationContext IsHexcolor(this object v)
        {
            bool state = false;
            var s = v as string;
            if (s != null)
            {
                state = System.Text.RegularExpressions.Regex.IsMatch(s, _hexcolor);
            }           
            return new ValidationContext
            {
                IsValid = state,
                Value = v,
                Message = "必须是16进制颜色代码"
            };
        }

        public static ValidationContext IsHexcolor(this ValidationContext vc)
        {
            if (!vc.IsValid) return vc;
            return vc.Value.IsHexcolor();
        }
    }
}
