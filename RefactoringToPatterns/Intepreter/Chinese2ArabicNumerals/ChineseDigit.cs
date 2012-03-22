using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chinese2ArabicNumerals
{
    public class ChineseDigit
    {
        private static readonly Dictionary<string, string> mapping = new Dictionary<string, string>
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
        private bool IsTenLeading;
        private bool TouchedWan;

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
                IsTenLeading = key == "十";

                var zeroCount = GetZeroCount(stringBuilder, key);

                switch (key)
                {
                    case "万":
                        TouchedWan = true;
                        stringBuilder.Insert(0, mapping.Get("零"), zeroCount);
                        break;
                    case "千":
                        stringBuilder.Insert(0, mapping.Get("零"), zeroCount);
                        break;
                    case "百":
                        stringBuilder.Insert(0, mapping.Get("零"), zeroCount);
                        break;
                    case "十":
                        stringBuilder.Insert(0, mapping.Get("零"), zeroCount);
                        break;
                    default:
                        stringBuilder.Insert(0, mapping.Get(key));
                        break;
                }
            }

            if (IsTenLeading)
            {
                stringBuilder.Insert(0, 1);
            }
            return stringBuilder.ToString();
        }

        private int GetZeroCount(StringBuilder stringBuilder, string key)
        {
            var currentDigit = mapping.Get(key).Length + (TouchedWan? 4: 0);
            var prevDigit = stringBuilder.Length;
            return currentDigit - prevDigit - 1;
        }
    }
}