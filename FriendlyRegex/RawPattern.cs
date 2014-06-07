namespace FriendlyRegularExpressions
{
    internal class RawPattern : RegularExpression
    {
        private readonly string _pattern;
        public string Pattern { get { return _pattern; } }

        public RawPattern(string pattern)
        {
            _pattern = pattern;
        }

        public override string GetStringRepresentation()
        {
            return _pattern;
        }
    }
}
