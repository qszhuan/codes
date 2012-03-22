using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chinese2ArabicNumerals
{
    public class ChiniseDigit
    {
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
                                                                             {"九", "9"},
                                                                             {"十", "10"},
                                                                         };

        private readonly string Origin;

        public ChiniseDigit(string s)
        {
            Origin = s;
        }

        public string Transform()
        {
            var stringBuilder = new StringBuilder();
            var reverse = Origin.Reverse();
            foreach (var digit in reverse)
            {
                if (digit.ToString() == "十")
                {
                    stringBuilder.Insert(0, stringBuilder.Length == 0 ? mapping["十"] : mapping["一"]);
                }
                else
                {
                    if (stringBuilder.Length == 0)
                    {
                        stringBuilder.Insert(0, mapping[digit.ToString()]);
                    }
                    else
                    {
                        stringBuilder.Remove(0, 1);
                        stringBuilder.Insert(0, mapping[digit.ToString()]);
                    }
                }
            }

            return stringBuilder.ToString();
        }
    }
}