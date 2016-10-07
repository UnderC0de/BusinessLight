namespace BusinessLight.Core.Extensions
{
    using System;
    using System.Collections.Generic;

    public static class ListExtensions
    {
        public static List<T> Apply<T>(this List<T> items, Action<T> actionToApply)
        {
            foreach (var item in items)
            {
                actionToApply(item);
            }

            return items;
        }
    }
}