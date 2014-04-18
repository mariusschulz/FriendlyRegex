
namespace FriendlyRegex.Subexpressions.Quantifiers
{
    internal class StarQuantifier : Subexpression
    {
        private readonly string _pattern;
        public string Pattern { get { return _pattern; } }

        public StarQuantifier(string pattern)
        {
            _pattern = pattern;
        }

        public override string GetStringRepresentation()
        {
            return "(?:" + _pattern + ")*";
        }
    }
}
