﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using YuYingjian.Validation.Internal;

namespace YuYingjian.Validation.Validator
{
    public static partial class Validator
    {
        /// <summary>
        /// 小于 c
        /// </summary>
        /// <param name="v"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static ValidationContext LessThan(this object v, IComparable c)
        {
            var value = v as IComparable;
            bool state = value != null && Comparer.GetComparisonResult(value, c) < 0;
            
            return new ValidationContext
            {
                IsValid = state,
                Value = v,
                Message = string.Format("必须小于{0}", c)
            };
        }

        public static ValidationContext LessThan(this ValidationContext vc, IComparable c)
        {
            if (!vc.IsValid) return vc;
            return vc.Value.LessThan(c);
        }
    }
}
