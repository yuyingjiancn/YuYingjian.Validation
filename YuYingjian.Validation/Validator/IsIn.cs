using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuYingjian.Validation.Validator
{
    public static partial class Validator
    {
        public static ValidationContext IsIn(this object v, object[] arr)
        {
            bool state = false;
            if (v != null)
            {
                state = arr.Contains(v);
            }
            
            return new ValidationContext
            {
                IsValid = state,
                Value = v,
                Message = ""
            };
        }

        public static ValidationContext IsIn(this ValidationContext vc, object[] arr)
        {
            if (!vc.IsValid) return vc;
            return vc.Value.IsIn(arr);
        }
    }
}
