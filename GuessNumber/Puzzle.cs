using System.Collections.Generic;
using System.Linq;

namespace GuessNumber
{
    public class Puzzle
    {
        private const int TimesLimit = 6;
        private readonly List<int> numbers;
        private int _times = 0;

        public Puzzle(int a, int b, int c, int d)
        {
            numbers = new List<int> {a,b,c,d};
        }

        public string Peek()
        {
            return string.Join(string.Empty, numbers);
        }

        public string Judge(int a, int b, int c, int d)
        {

            var guess = new List<int>{a,b,c,d};
            var matches = numbers.Where((t, i) => numbers.ElementAt(i) == guess.ElementAt(i)).ToList();
            var A = matches.Count();

            var left = numbers.Except(matches).OrderBy(n => n);
            var right = guess.Except(matches).OrderBy(n => n);
            var B = left.Intersect(right).Count();

            if(A<TimesLimit)
            {
                _times++;
            }
            if (_times >= TimesLimit) return "FAIL";

            return string.Format("{0}A{1}B", A, B);
        }
    }
}