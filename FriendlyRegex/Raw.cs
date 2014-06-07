namespace FriendlyRegularExpressions
{
    public static class Raw
    {
        public static RegularExpression Pattern(string rawPattern)
        {
            return new RawPattern(rawPattern);
        }
    }
}
