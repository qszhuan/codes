using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chinese2ArabicNumerals
{
    public class ChineseDigit
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
                                                                             {"千", "1000"},
                                                                         };

        private readonly string Origin;

        public ChineseDigit(string s)
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
                if (key == "千")
                {
                    stringBuilder.Insert(0, stringBuilder.Length == 0 ? mapping.Get(key) : string.Empty);
                    var diffLen = mapping.Get(key).Length - stringBuilder.Length;
                    for (var i = 0; i < diffLen; i++)
                    {
                        InsertZero(stringBuilder);
                    }
                }
                else if (key == "百")
                {
                    stringBuilder.Insert(0, stringBuilder.Length == 0 ? mapping.Get(key) : mapping["一"]);
                }
                else if (key == "十")
                {
                    stringBuilder.Insert(0, stringBuilder.Length == 0 ? mapping[key] : mapping["一"]);
                }
                else if (key == "零")
                {
                    InsertZero(stringBuilder);
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

        private static StringBuilder InsertZero(StringBuilder stringBuilder)
        {
            return stringBuilder.Insert(0, mapping.Get("零"));
        }
    }
}