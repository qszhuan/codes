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
                                                                             {"万", "10000"},
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

                if (stringBuilder.Length == 0)
                {
                    stringBuilder.Append(mapping.Get(key));
                    continue;
                }

                if (key == "万")
                {
                    AddZero(key, stringBuilder);
                    stringBuilder.Insert(0, mapping["一"]);
                    continue;
                }
                if (key == "千")
                {
                    AddZero(key, stringBuilder);
                    stringBuilder.Insert(0, mapping["一"]);
                    continue;
                }
                if (key == "百")
                {
                    AddZero(key, stringBuilder);
                    stringBuilder.Insert(0, mapping["一"]);
                    continue;
                }
                if (key == "十")
                {
                    AddZero(key, stringBuilder);
                    stringBuilder.Insert(0, mapping["一"]);
                    continue;
                }
                if (key == "零")
                {
                    continue;
                }
                stringBuilder.Remove(0, 1);
                stringBuilder.Insert(0, mapping.Get(key));
            }

            return stringBuilder.ToString();
        }

        private static void AddZero(string key, StringBuilder stringBuilder)
        {
            var diffLen = mapping.Get(key).Length - stringBuilder.Length;
            for (var i = 0; i < diffLen - 1; i++)
            {
                stringBuilder.Insert(0, mapping.Get("零"));
            }
        }
    }
}