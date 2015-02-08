using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuYingjian.Validation
{
    public class ValidationContext
    {
        public bool IsValid { get; set; }
        public object Value { get; set; }
        public string Message { get; set; }
    }
}
