using System.Text.RegularExpressions;

namespace FriendlyRegularExpressions
{
    internal class Literal : RegularExpression
    {
        private readonly string _literalPattern;
        public string LiteralPattern { get { return _literalPattern; } }

        private readonly string _escapedPattern;
        public string EscapedPattern { get { return _escapedPattern; } }

        public Literal(string literal)
        {
            _literalPattern = literal;
            _escapedPattern = Regex.Escape(literal);
        }

        public override string GetStringRepresentation()
        {
            return _escapedPattern;
        }
    }
}
