using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Extensions;

namespace GuessNumber
{
    public class GuessNumberFacts
    {
        [Fact]
        public void should_get_the_result()
        {
            var puzzle = new Puzzle(1,2,3,4);

            var numbers = puzzle.Peek();

            Assert.Equal("1234", numbers);
        }

        [Theory]
        [InlineData("4A0B", 1,2,3,4)]
        [InlineData("0A0B", 5,6,7,8)]
        [InlineData("1A1B", 1,3,7,8)]
        [InlineData("0A4B", 4,3,2,1)]
        public void should_return_the_correct_result(string expected, int a, int b, int c, int d)
        {
            var puzzle = new Puzzle(1, 2, 3, 4);
            var result = puzzle.Judge(a,b,c,d);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void should_return_fail_after_6_try_and_not_guess_out()
        {
            var puzzle = new Puzzle(1,2,3,4);
            puzzle.Judge(2, 3, 4, 5);
            puzzle.Judge(2, 3, 4, 5);
            puzzle.Judge(2, 3, 4, 5);
            puzzle.Judge(2, 3, 4, 5);
            puzzle.Judge(2, 3, 4, 5);
            var result = puzzle.Judge(2, 3, 4, 5);
            Assert.Equal("FAIL", result);
        }

        [Fact]
        public void try_intersect()
        {
            var left = new List<int> {1, 2, 3, 4};
            var right = new List<int> {4, 3, 2, 1};
            Assert.Equal(4, left.Intersect(right).ToList().Count());
        }
    }
}
