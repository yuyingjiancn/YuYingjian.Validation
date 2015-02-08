using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using YuYingjian.Validation.Validator;

namespace YuYingjian.Validation.Test
{
    public class XUnitTest
    {
        [Fact]
        public void IsEmailTest()
        {
            Assert.True("yuyingjian@126.com".IsEmail().IsValid);
            Assert.True("414973551@qq.com".IsEmail().IsValid);
            Assert.False("414973551_qq.com".IsEmail().IsValid);
        }

        [Fact]
        public void IsInTest()
        {
            Assert.True("1".IsIn(new object[]{"1", "2", "3"}).IsValid);
            Assert.False("4".IsIn(new object[] { "1", "2", "3" }).IsValid);
            Assert.True(1.IsIn(new object[] { 1, 2, 3 }).IsValid);
        }

        [Fact]
        public void IsPasswordTest()
        {
            Assert.True("`~!@#$%^&*()-_=+\\|".IsPassword().IsValid);
            Assert.True("[{]};:\'\",<.>/?".IsPassword().IsValid);
            Assert.True("agbNJU567".IsPassword().IsValid);
            Assert.True("fa!@#FA:>,'{".IsPassword().IsValid);
            Assert.False("这是中文密码".IsPassword().IsValid);
            Assert.False("·“”》《11".IsPassword().IsValid);
        }

        [Fact]
        public void IsMobilePhoneTest()
        {
            Assert.True("13757378424".IsMobilePhoneChina().IsValid);
            Assert.False("12679342365".IsMobilePhoneChina().IsValid);
            Assert.False("87234152".IsMobilePhoneChina().IsValid);
            Assert.True("1".IsPhoneNumber().IsValid);
        }

        [Fact]
        public void IsLessThanTest()
        {
            Assert.True("1".LessThan("2").IsValid);
            Assert.True(1.LessThan(2).IsValid);
            Assert.True(1.1.LessThan(2).IsValid);
            Assert.True(2.LessThanOrEqual(2).IsValid);
        }

        [Fact]
        public void IsGreaterThanTest()
        {
            Assert.False("1".GreaterThan("2").IsValid);
            Assert.False(1.GreaterThan(2).IsValid);
            Assert.False(1.1.GreaterThan(2).IsValid);
            Assert.False(2.GreaterThan(2).IsValid);

            Assert.True(3.GreaterThan(2).IsValid);
        }

        [Fact]
        public void IsInRangeTest()
        {
            Assert.True("1".IsInRange("0","2").IsValid);
            //Assert.True("5".IsInRange(1, 10).IsValid);
            Assert.False("  ".IsCreditCard().IsValid);
            Assert.True("10".IsMoney().IsValid);
        }

        [Fact]
        public void MoneyTest()
        {
            Assert.True("10".IsMoney().IsValid);
            Assert.True("06".IsMoney().IsValid);
            Assert.False("6.".IsMoney().IsValid);
            Assert.True("6.6".IsMoney().IsValid);
            Assert.True("6.66".IsMoney().IsValid);
            Assert.False("6.666".IsMoney().IsValid);
        }
    }
}