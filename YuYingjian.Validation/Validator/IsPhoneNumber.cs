using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace YuYingjian.Validation.Validator
{
    public static partial class Validator
    {
        //微软的源代码里面抄的，但是感觉这个好像不是很对啊
        private static readonly Regex RegPhoneNumber = new Regex(@"^(\+\s?)?((?<!\+.*)\(\+?\d+([\s\-\.]?\d+)?\)|\d+)([\s\-\.]?(\(\d+([\s\-\.]?\d+)?\)|\d+))*(\s?(x|ext\.?)\s?\d+)?$", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture);
        
        public static ValidationContext IsPhoneNumber(this object v)
        {
            bool state = false;
            var s = v as string;
            if(s != null)
                state = RegPhoneNumber.Match(s).Length > 0;
            return new ValidationContext
            {
                IsValid = state,
                Value = v,
                Message = "电话号码格式错误"
            };
        }

        public static ValidationContext IsPhoneNumber(this ValidationContext vc)
        {
            if (!vc.IsValid) return vc;
            return vc.Value.IsPhoneNumber();
        }
    }
}
