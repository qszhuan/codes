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
        public void should_be_able_to_transform_single_chinese_digit_to_arabic(string chineseDigit, string arabicDigit)
        {
            var chiniseDigit = new ChiniseDigit(chineseDigit);
            var transform = chiniseDigit.Transform();
            Assert.Equal(arabicDigit, transform);
        }
    }

    public class ChiniseDigit
    {
        private readonly string _s;
        private static readonly Dictionary<string, string> mapping = new Dictionary<string, string>()
                                                                {
                                                                    {"零", "0"},
                                                                    {"一", "1"},
                                                                    {"二", "2"},
                                                                    {"三", "3"},
                                                                    {"四", "4"},
                                                                    {"五", "5"},
                                                                    {"六", "6"},
                                                                    {"七", "7"},
                                                                    {"八", "8"},
                                                                    {"九", "9"}
                                                                };

        public ChiniseDigit(string s)
        {
            _s = s;
        }

        public string Transform()
        {
            string result;
            mapping.TryGetValue(_s, out result);
            return result;
        }
    }
}
