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
        /// 判断字符串是否可以转换为short类型
        /// </summary>
        /// <param name="v"></param>
        /// <returns>将转换后的short值存入ValidationContext的Value中</returns>
        public static ValidationContext IsShort(this object v)
        {
            short result = 0;
            bool state = v != null && short.TryParse(v.ToString(), out result);
            
            return new ValidationContext
            {
                IsValid = state,
                Value = state ? (object)result : v,
                Message = "必须是整型[int]"
            };
        }

        public static ValidationContext IsShort(this ValidationContext vc)
        {
            if (!vc.IsValid) return vc;
            return vc.Value.IsShort();
        }
    }
}
