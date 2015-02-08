using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuYingjian.Validation.Validator
{
    public static partial class Validator
    {
        /// <summary>
        /// 判断字符串v是否可以转换为指定format的datetime格式
        /// </summary>
        /// <param name="v">字符串</param>
        /// <param name="format">指定的日期格式</param>
        /// <returns>返回的时候v会被转换为DateTime类型存于ValidationContext的Value中</returns>
        public static ValidationContext IsDateTime(this string v, string format)
        {
            DateTime result = DateTime.Now;
            bool state = false;
            if (v != null)
            {
                state = DateTime.TryParseExact(
                v,
                format,
                CultureInfo.InvariantCulture, //The invariant culture is culture-insensitive; it is associated with the English language but not with any country/region.
                DateTimeStyles.None, //Indicates that the default formatting options must be used. This is the default style for DateTime.Parse and DateTime.ParseExact.
                out result);
            }
            
            return new ValidationContext
            {
                IsValid = state,
                Value = state ? (object)result : v,
                Message = "必须是日期时间类型"
            };
        }

        public static ValidationContext IsDateTime(this ValidationContext vc, string format)
        {
            if (!vc.IsValid) return vc;
            return vc.Value.ToString().IsDateTime(format);
        }
    }
}
