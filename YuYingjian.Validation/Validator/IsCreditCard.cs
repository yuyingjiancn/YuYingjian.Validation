using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YuYingjian.Validation.Validator
{
    public static partial class Validator
    {
        private static bool _isCreditCard(string s)
        {
            s = s.Replace("-", "").Replace(" ", "");

            int checksum = 0;
            bool evenDigit = false;
            // http://www.beachnet.com/~hstiles/cardtype.html
            foreach (char digit in s.ToCharArray().Reverse())
            {
                if (!char.IsDigit(digit))
                {
                    return false;
                }

                int digitValue = (digit - '0') * (evenDigit ? 2 : 1);
                evenDigit = !evenDigit;

                while (digitValue > 0)
                {
                    checksum += digitValue % 10;
                    digitValue /= 10;
                }
            }

            return (checksum % 10) == 0;
        }

        /// <summary>
        /// 判断是否是信用卡账号
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static ValidationContext IsCreditCard(this object v)
        {
            bool state = false;
            var s = v as string;
            if (s != null)
            {
                if(s.Trim() != string.Empty)
                    state = _isCreditCard(s.Trim());
            }           
            return new ValidationContext
            {
                IsValid = state,
                Value = v,
                Message = "必须是信用卡账号"
            };
        }

        public static ValidationContext IsCreditCard(this ValidationContext vc)
        {
            if (!vc.IsValid) return vc;
            return vc.Value.IsCreditCard();
        }
    }
}
