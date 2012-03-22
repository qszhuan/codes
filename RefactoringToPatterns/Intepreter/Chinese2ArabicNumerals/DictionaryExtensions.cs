using System.Collections.Generic;

namespace Chinese2ArabicNumerals
{
    public static class DictionaryExtensions
    {
        public static TValue Get<TKey,TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue = default(TValue)) where TKey:class 
        {
            if (key != null && dictionary.ContainsKey(key))
            {
                return dictionary[key];
            }
            return defaultValue;
        }

    }
}