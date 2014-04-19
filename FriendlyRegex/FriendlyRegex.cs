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

        public FriendlyRegex ThenOneOrMore(string literal)
        {
            string escaped = Escape(literal);
            var literalExpression = new Literal(escaped);
            var repeatedExpression = new PlusQuantifier(literalExpression);

            return Append(repeatedExpression);
        }

        public FriendlyRegex ThenZeroOrMore(string literal)
        {
            string escaped = Escape(literal);
            var literalExpression = new Literal(escaped);
            var repeatedExpression = new StarQuantifier(literalExpression);

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

        public FriendlyRegex ThenMaybe(string literal)
        {
            string escaped = Escape(literal);
            var literalExpression = new Literal(escaped);
            var optionalExpression = new QuestionMarkQuantifier(literalExpression);

            return Append(optionalExpression);
        }

        public FriendlyRegex ThenMaybe(Subexpression expression)
        {
            var optionalExpression = new QuestionMarkQuantifier(expression);

            return Append(optionalExpression);
        }

        public FriendlyRegex Then(string pattern)
        {
            string escaped = Escape(pattern);
            var literalExpression = new Literal(escaped);

            return Append(literalExpression);
        }

        public FriendlyRegex Then(Subexpression expression)
        {
            return Append(expression);
        }

        public FriendlyRegex ThenRaw(string pattern)
        {
            var rawPattern = new RawPattern(pattern);

            return Append(rawPattern);
        }

        public FriendlyRegex ThenSomething()
        {
            var anythingExpression = new PlusQuantifier(new Dot());

            return Append(anythingExpression);
        }

        public FriendlyRegex ThenMaybeSomething()
        {
            var anythingExpression = new StarQuantifier(new Dot());

            return Append(anythingExpression);
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
