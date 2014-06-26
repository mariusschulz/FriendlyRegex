using System.Collections.Generic;

namespace FriendlyRegularExpressions.Extensions
{
    internal static class StringExtensions
    {
        public static string StringJoin(this IEnumerable<object> items, string separator = "")
        {
            return string.Join(separator, items);
        }
    }
}
