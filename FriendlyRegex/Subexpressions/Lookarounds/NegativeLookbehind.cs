
namespace FriendlyRegularExpressions.Subexpressions.Lookarounds
{
    internal class NegativeLookbehind : Subexpression
    {
        private readonly string _pattern;
        public string Pattern { get { return _pattern; } }

        public NegativeLookbehind(string pattern)
        {
            _pattern = pattern;
        }

        public override string GetStringRepresentation()
        {
            return "(?<!" + _pattern + ")";
        }
    }
}
