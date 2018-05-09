using System;
using System.Collections.Generic;

namespace TemporalDeserializer
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
    }
}
