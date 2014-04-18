
namespace FriendlyRegex.Subexpressions.Quantifiers
{
    internal class PlusQuantifier : Subexpression
    {
        private readonly string _pattern;
        public string Pattern { get { return _pattern; } }

        public PlusQuantifier(string pattern)
        {
            _pattern = pattern;
        }

        public override string GetStringRepresentation()
        {
            return "(?:" + _pattern + ")+";
        }
    }
}
