
namespace FriendlyRegularExpressions.Subexpressions
{
    internal class RawPattern : Subexpression
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
