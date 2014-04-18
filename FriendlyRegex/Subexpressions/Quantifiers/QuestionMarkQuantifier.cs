
namespace FriendlyRegularExpressions.Subexpressions.Quantifiers
{
    internal class QuestionMarkQuantifier : Subexpression
    {
        private readonly string _pattern;
        public string Pattern { get { return _pattern; } }

        public QuestionMarkQuantifier(string pattern)
        {
            _pattern = pattern;
        }

        public override string GetStringRepresentation()
        {
            return "(?:" + _pattern + ")?";
        }
    }
}
