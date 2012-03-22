using System.Collections.Generic;
using Xunit;
using Xunit.Extensions;

namespace Chinese2ArabicNumerals
{
    public class Chinese2AribicNumeralsFacts
    {
        [Theory]
        [InlineData("零", "0")]
        [InlineData("一", "1")]
        [InlineData("二", "2")]
        [InlineData("三", "3")]
        [InlineData("四", "4")]
        [InlineData("五", "5")]
        [InlineData("六", "6")]
        [InlineData("七", "7")]
        [InlineData("八", "8")]
        [InlineData("九", "9")]
        public void should_transform_single_chinese_digit_to_arabic(string chineseDigit, string arabicDigit)
        {
            var chiniseDigit = new ChiniseDigit(chineseDigit);
            var transform = chiniseDigit.Transform();
            Assert.Equal(arabicDigit, transform);
        }

        [Theory]
        [InlineData("十", "10")]
        [InlineData("十一", "11")]
        [InlineData("一十", "10")]
        [InlineData("二十", "20")]
        [InlineData("二十一", "21")]
        public void should_transform_chinese_tens_digit_to_arabic(string chineseDigit, string arabicDigit)
        {
            var chiniseDigit = new ChiniseDigit(chineseDigit);
            var transform = chiniseDigit.Transform();
            Assert.Equal(arabicDigit, transform);
        }

        [Theory]
        [InlineData("一百", "100")]
        [InlineData("二百", "200")]
        [InlineData("二百一十", "210")]
        [InlineData("二百一十一", "211")]
        [InlineData("二百零一", "201")]
        public void should_transform_the_chinese_hundreds_to_arbic(string chineseDigit, string arabicDigit)
        {
            var chiniseDigit = new ChiniseDigit(chineseDigit);
            var transform = chiniseDigit.Transform();
            Assert.Equal(arabicDigit, transform);
        }


      
    }
}
