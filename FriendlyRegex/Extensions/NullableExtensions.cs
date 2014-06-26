namespace FriendlyRegularExpressions.Extensions
{
    internal static class NullableExtensions
    {
        public static string ToStringOrEmpty<T>(this T? nullable) where T : struct
        {
            return nullable.HasValue
                ? nullable.ToString()
                : string.Empty;
        }
    }
}
