using FriendlyRegularExpressions.Subexpressions;

namespace FriendlyRegularExpressions
{
    public static class Raw
    {
        public static Subexpression Pattern(string rawPattern)
        {
            return new RawPattern(rawPattern);
        }
    }
}
