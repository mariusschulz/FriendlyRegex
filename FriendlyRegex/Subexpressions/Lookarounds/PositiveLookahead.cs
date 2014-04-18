
namespace FriendlyRegularExpressions.Subexpressions.Lookarounds
{
    internal class PositiveLookahead : Subexpression
    {
        private readonly string _pattern;
        public string Pattern { get { return _pattern; } }

        public PositiveLookahead(string pattern)
        {
            _pattern = pattern;
        }

        public override string GetStringRepresentation()
        {
            return "(?=" + _pattern + ")";
        }
    }
}
