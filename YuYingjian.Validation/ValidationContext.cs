using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuYingjian.Validation
{
    /// <summary>
    /// 验证上下文类
    /// </summary>
    public class ValidationContext
    {
        /// <summary>
        /// 验证是否通过
        /// </summary>
        public bool IsValid { get; set; }

        /// <summary>
        /// 存储验证的值，如果是值类型如int、double则验证通过后会自动转换为相应类型
        /// </summary>
        public object Value { get; set; }

        /// <summary>
        /// 验证未通过的错误信息
        /// </summary>
        public string Message { get; set; }
    }
}
