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
            var chinese = new ChineseDigit(chineseDigit);
            var transform = chinese.Transform();
            Assert.Equal(arabicDigit, transform);
        }

        [Theory]
        [InlineData("十", "10")]
        [InlineData("一十", "10")]
        [InlineData("十一", "11")]
        [InlineData("二十", "20")]
        [InlineData("二十一", "21")]
        public void should_transform_chinese_tens_digit_to_arabic(string chineseDigit, string arabicDigit)
        {
            var chinese = new ChineseDigit(chineseDigit);
            var transform = chinese.Transform();
            Assert.Equal(arabicDigit, transform);
        }

        [Theory]
        [InlineData("一百", "100")]
        [InlineData("二百", "200")]
        [InlineData("二百一十", "210")]
        [InlineData("二百一十一", "211")]
        [InlineData("二百零一", "201")]
        public void should_transform_the_chinese_hundreds_to_arabic(string chineseDigit, string arabicDigit)
        {
            var chinese = new ChineseDigit(chineseDigit);
            var transform = chinese.Transform();
            Assert.Equal(arabicDigit, transform);
        }

        [Theory]
        [InlineData("一千", "1000")]
        [InlineData("一千一百", "1100")]
        [InlineData("一千一百一十", "1110")]
        [InlineData("一千一百一十一", "1111")]
        [InlineData("一千一百零一", "1101")]
        [InlineData("一千零一", "1001")]
        [InlineData("一千零一十一", "1011")]
        public void should_transform_the_chinese_thousands_to_arabic(string chineseDigit, string arabicDigit)
        {
            var chinese = new ChineseDigit(chineseDigit);
            var transform = chinese.Transform();
            Assert.Equal(arabicDigit, transform);
        }

        [Theory]
        [InlineData("一万", "10000")]
        [InlineData("一万一千一百一十一", "11111")]
        [InlineData("一万零五", "10005")]
        [InlineData("一万零五十", "10050")]
//        [InlineData("十万", "100000")]
        public void should_transform_the_chinese_Wan_digit_to_arabic(string chineseDigit, string arabicDigit)
        {
            var chinese = new ChineseDigit(chineseDigit);
            var transform = chinese.Transform();
            Assert.Equal(arabicDigit, transform);
        }
    }
}
