using Xunit;
using Xunit.Extensions;

namespace MaskExpression
{
    public class MaskExpressionFacts
    {
        [Theory]
        [InlineData("9", "1", "1")]
        [InlineData("99", "12", "12")]
        [InlineData("999", "123", "123")]
        [InlineData("999", "1-2", "1-2")]
        [InlineData("999", "1", "1")]
        public void should_be_get_for_digital(string mask, string input, string expected)
        {
            var context = new Context(input);
            new ExpressionBuilder(mask).Build().Interpret(context);
            Assert.Equal(expected, context.Result);
        }

        [Theory]
        [InlineData("9-9", "1-2", "12")]
        [InlineData("9-9", "12", "12")]
        [InlineData("9-9-9", "1-2-3", "123")]
        [InlineData("9-9-9", "12-3", "12-3")]
        [InlineData("999-999", "123-456", "123456")]
        public void should_be_get_for_digital_and_seperator(string mask, string input, string expected)
        {
            var context = new Context(input);
            new ExpressionBuilder(mask).Build().Interpret(context);
            Assert.Equal(expected, context.Result);
        }

        [Theory]
        [InlineData("a-a", "a-b", "ab")]
        [InlineData("a-a-a", "a-b-c", "abc")]
        [InlineData("aaa-aaa", "abc-def", "abcdef")]
        [InlineData("aaa-aaa", "a-bcdef", "a-bcdef")]
        public void should_be_get_for_alphabet(string mask, string input, string expected)
        {
            var context = new Context(input);
            new ExpressionBuilder(mask).Build().Interpret(context);
            Assert.Equal(expected, context.Result);
        }

        [Theory]
        [InlineData("a-9", "a-1", "a1")]
        [InlineData("9-a-9", "1-b-3", "1b3")]
        [InlineData("a9a-9a9", "a2c-4e6", "a2c4e6")]
        [InlineData("a9a-9a9", "a2c-4-e6", "a2c-4-e6")]
        public void should_be_get_for_alphanum_mix(string mask, string input, string expected)
        {
            var context = new Context(input);
            new ExpressionBuilder(mask).Build().Interpret(context);
            Assert.Equal(expected, context.Result);
        }

        [Theory]
        [InlineData("*", "a", "a")]
        [InlineData("*", "1", "1")]
        [InlineData("**", "1a", "1a")]
        [InlineData("**-**", "12-ab", "12ab")]
        [InlineData("*-*-9", "a-2-3", "a23")]
        [InlineData("*-*-9", "a-2-c", "a-2-c")]
        public void should_be_get_for_wildchar_for_alphanum(string mask, string input, string expected)
        {
            var context = new Context(input);
            new ExpressionBuilder(mask).Build().Interpret(context);
            Assert.Equal(expected, context.Result);
        }
    }
}
