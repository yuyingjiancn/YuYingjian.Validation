﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuYingjian.Validation.Validator
{
    public static partial class Validator
    {
        /// <summary>
        /// 字符串不能为空
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static ValidationContext NotEmpty(this object v)
        {
            bool state = false;
            var s = v as string;
            if (s != null)
                state = s != string.Empty;
            return new ValidationContext
            {
                IsValid = state,
                Value = v,
                Message = "必填"
            };
        }

        public static ValidationContext NotEmpty(this ValidationContext vc)
        {
            if (!vc.IsValid) return vc;
            return vc.Value.NotEmpty();
        }
    }
}
