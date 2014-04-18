
namespace FriendlyRegex.Subexpressions.Lookarounds
{
    internal class PositiveLookbehind : Subexpression
    {
        private readonly string _pattern;
        public string Pattern { get { return _pattern; } }

        public PositiveLookbehind(string pattern)
        {
            _pattern = pattern;
        }

        public override string GetStringRepresentation()
        {
            return "(?<=" + _pattern + ")";
        }
    }
}
