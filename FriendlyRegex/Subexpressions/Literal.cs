using System.Text.RegularExpressions;

namespace FriendlyRegularExpressions.Subexpressions
{
    internal class Literal : Subexpression
    {
        private readonly string _literalPattern;
        public string LiteralPattern { get { return _literalPattern; } }

        private readonly string _escapedPattern;
        public string EscapedPattern { get { return _escapedPattern; } }

        public Literal(string pattern)
        {
            _literalPattern = pattern;
            _escapedPattern = Regex.Escape(pattern);
        }

        public override string GetStringRepresentation()
        {
            return _escapedPattern;
        }
    }
}
