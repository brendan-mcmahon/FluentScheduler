using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Common
{
    public static class Extensions
    {
        public static void ForEach<T>(this ICollection<T> collection, Action<T> action)
        {
            foreach (var item in collection)
            {
                action(item);
            }
        }

        public static ICollection<U> ResolveToNewList<T, U>(this ICollection<T> collection, Func<T, U> resolver)
        {
            var list = new List<U>();

            collection.ForEach(i => list.Add(resolver(i)));

            return list;
        }

        public static string ListToString(this ICollection<string> list, string delimeter = null)
        {
            return String.Join((delimeter ?? ", "), list);
        }

        public static string Prettify(this string message)
        {
            message = Regex.Replace(message, @"\s+", " ");
            message = message.CapitalizeFirst();

            return $"{message}.";
        }

        public static string CapitalizeFirst(this string s)
        {
            bool isNewSentence = true;
            var result = new StringBuilder(s.Length);
            for (int i = 0; i < s.Length; i++)
            {
                if (isNewSentence && char.IsLetter(s[i]))
                {
                    result.Append(char.ToUpper(s[i]));
                    isNewSentence = false;
                }
                else
                    result.Append(s[i]);

                if (s[i] == '!' || s[i] == '?' || s[i] == '.')
                {
                    isNewSentence = true;
                }
            }

            return result.ToString();
        }
    }
}
