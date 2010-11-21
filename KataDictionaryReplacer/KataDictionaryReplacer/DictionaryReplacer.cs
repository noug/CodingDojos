using System;
using System.Collections.Generic;
using System.Text;

namespace KataDictionaryReplacer
{
    public static class DictionaryReplacer
    {
        public static string Replace(string text, Dictionary<string, string> dictionary)
        {
            var newText = string.Empty;
            while (text!=newText)
            {
                newText = text;
                text = ReplaceKeysWithValues(newText, dictionary);  
            }
            ThrowExceptionIfKeyRecursion(newText, dictionary);
            return newText;
        }

        private static void ThrowExceptionIfKeyRecursion(string text, Dictionary<string, string> dictionary)
        {
            foreach (var key in dictionary.Keys)
            {
                if (text.Contains(CreateKey(key)))
                    throw new ArgumentException(string.Format("{0} is a recursion", CreateKey(key)), "dictionary");
            }
        }

        private static string CreateKey(string key)
        {
            return string.Format("${0}$", key);
        }

        private static string ReplaceKeysWithValues(string text, Dictionary<string, string> dictionary)
        {
            StringBuilder sb = new StringBuilder(text);
            foreach (var pair in dictionary)
            {
                sb.Replace(string.Format("${0}$", pair.Key), pair.Value);
            }
            return sb.ToString();
        }
    }
}