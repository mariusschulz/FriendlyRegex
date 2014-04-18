using System.Collections.Generic;
using System.Text.RegularExpressions;
using FriendlyRegularExpressions.Subexpressions;
using FriendlyRegularExpressions.Subexpressions.Groups;
using FriendlyRegularExpressions.Subexpressions.Lookarounds;
using FriendlyRegularExpressions.Subexpressions.Quantifiers;

namespace FriendlyRegularExpressions
{
    public class FriendlyRegex
    {
        private readonly List<Subexpression> _subexpressions;

        public FriendlyRegex()
        {
            _subexpressions = new List<Subexpression>();
        }

        public override string ToString()
        {
            return string.Join(string.Empty, _subexpressions);
        }

        public Regex ToRegex()
        {
            return new Regex(ToString());
        }

        public FriendlyRegex OneOrMore(string pattern)
        {
            string escaped = Escape(pattern);
            var repeatedExpression = new PlusQuantifier(escaped);

            return Append(repeatedExpression);
        }

        public FriendlyRegex ZeroOrMore(string pattern)
        {
            string escaped = Escape(pattern);
            var repeatedExpression = new StarQuantifier(escaped);

            return Append(repeatedExpression);
        }

        public FriendlyRegex StartOfLine()
        {
            return Append(new StartAnchor());
        }

        public FriendlyRegex EndOfLine()
        {
            return Append(new EndAnchor());
        }

        public FriendlyRegex Optional(string pattern)
        {
            string escaped = Escape(pattern);
            var optionalExpression = new QuestionMarkQuantifier(escaped);

            return Append(optionalExpression);
        }

        public FriendlyRegex Then(string pattern)
        {
            string escaped = Escape(pattern);
            var literalExpression = new Literal(escaped);

            return Append(literalExpression);
        }

        public FriendlyRegex ThenRaw(string pattern)
        {
            var rawPattern = new RawPattern(pattern);

            return Append(rawPattern);
        }

        public FriendlyRegex BeginCapture()
        {
            return Append(new OpeningCapturingGroup());
        }

        public FriendlyRegex BeginCapture(string name)
        {
            return Append(new OpeningCapturingGroup(name));
        }

        public FriendlyRegex EndCapture()
        {
            return Append(new ClosingCapturingGroup());
        }

        public FriendlyRegex LookingAheadAt(string pattern)
        {
            string escaped = Escape(pattern);
            var lookaheadExpression = new PositiveLookahead(escaped);

            return Append(lookaheadExpression);
        }

        public FriendlyRegex NotLookingAheadAt(string pattern)
        {
            string escaped = Escape(pattern);
            var lookaheadExpression = new NegativeLookahead(escaped);

            return Append(lookaheadExpression);
        }

        public FriendlyRegex LookingBehindAt(string pattern)
        {
            string escaped = Escape(pattern);
            var lookbehindExpression = new PositiveLookbehind(escaped);

            return Append(lookbehindExpression);
        }

        public FriendlyRegex NotLookingBehindAt(string pattern)
        {
            string escaped = Escape(pattern);
            var lookbehindExpression = new NegativeLookbehind(escaped);

            return Append(lookbehindExpression);
        }

        private static string Escape(string literal)
        {
            return Regex.Escape(literal);
        }

        private FriendlyRegex Append(Subexpression subexpression)
        {
            _subexpressions.Add(subexpression);

            return this;
        }
    }
}
