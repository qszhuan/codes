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
                                                                             {"百", "100"},
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
                var key = digit.ToString();

                if (key == "百")
                {
                    stringBuilder.Insert(0, stringBuilder.Length == 0 ? mapping.Get(key) : mapping["一"]);
                }
                else if (key == "十")
                {
                    stringBuilder.Insert(0, stringBuilder.Length == 0 ? mapping[key] : mapping["一"]);
                }
                else if (key == "零")
                {
                    stringBuilder.Insert(0, mapping.Get(key));
                }
                else
                {
                    if (stringBuilder.Length == 0)
                    {
                        stringBuilder.Insert(0, mapping.Get(key));
                    }
                    else
                    {
                        stringBuilder.Remove(0, 1);
                        stringBuilder.Insert(0, mapping.Get(key));
                    }
                }
            }

            return stringBuilder.ToString();
        }
    }
}