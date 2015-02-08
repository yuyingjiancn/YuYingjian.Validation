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
        /// 为ValidatorValidationContext的Error Message设置验证错误的信息
        /// </summary>
        /// <param name="vc"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static ValidationContext Msg(this ValidationContext vc, string msg)
        {
            vc.Message = msg;
            return vc;
        }
    }
}
