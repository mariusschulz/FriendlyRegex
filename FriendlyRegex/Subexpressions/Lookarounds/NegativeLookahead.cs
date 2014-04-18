
namespace FriendlyRegex.Subexpressions.Lookarounds
{
    internal class NegativeLookahead : Subexpression
    {
        private readonly string _pattern;
        public string Pattern { get { return _pattern; } }

        public NegativeLookahead(string pattern)
        {
            _pattern = pattern;
        }

        public override string GetStringRepresentation()
        {
            return "(?!" + _pattern + ")";
        }
    }
}
