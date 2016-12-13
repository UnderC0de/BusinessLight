namespace BusinessLight.Core.Extensions
{
    using System;
    using System.Collections.Generic;

    public static class CollectionExtensions
    {
        public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                collection.Add(item);
            }
        }

        public static ICollection<T> Apply<T>(this ICollection<T> items, Action<T> actionToApply)
        {
            foreach (var item in items)
            {
                actionToApply(item);
            }

            return items;
        }
    }
}
