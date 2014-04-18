using System.Collections.Generic;
using System.Text.RegularExpressions;
using FriendlyRegex.Subexpressions;
using FriendlyRegex.Subexpressions.Groups;
using FriendlyRegex.Subexpressions.Lookarounds;
using FriendlyRegex.Subexpressions.Quantifiers;

namespace FriendlyRegex
{
    public class RegularExpression
    {
        private readonly List<Subexpression> _subexpressions;

        public RegularExpression()
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

        public RegularExpression OneOrMore(string pattern)
        {
            string escaped = Escape(pattern);
            var repeatedExpression = new PlusQuantifier(escaped);

            return Append(repeatedExpression);
        }

        public RegularExpression ZeroOrMore(string pattern)
        {
            string escaped = Escape(pattern);
            var repeatedExpression = new StarQuantifier(escaped);

            return Append(repeatedExpression);
        }

        public RegularExpression StartOfLine()
        {
            return Append(new StartAnchor());
        }

        public RegularExpression EndOfLine()
        {
            return Append(new EndAnchor());
        }

        public RegularExpression Optional(string pattern)
        {
            string escaped = Escape(pattern);
            var optionalExpression = new QuestionMarkQuantifier(escaped);

            return Append(optionalExpression);
        }

        public RegularExpression BeginCapture()
        {
            return Append(new OpeningCapturingGroup());
        }

        public RegularExpression BeginCapture(string name)
        {
            return Append(new OpeningCapturingGroup(name));
        }

        public RegularExpression EndCapture()
        {
            return Append(new ClosingCapturingGroup());
        }

        public RegularExpression LookingAheadAt(string pattern)
        {
            string escaped = Escape(pattern);
            var lookaheadExpression = new PositiveLookahead(escaped);

            return Append(lookaheadExpression);
        }

        public RegularExpression NotLookingAheadAt(string pattern)
        {
            string escaped = Escape(pattern);
            var lookaheadExpression = new NegativeLookahead(escaped);

            return Append(lookaheadExpression);
        }

        public RegularExpression LookingBehindAt(string pattern)
        {
            string escaped = Escape(pattern);
            var lookbehindExpression = new PositiveLookbehind(escaped);

            return Append(lookbehindExpression);
        }

        public RegularExpression NotLookingBehindAt(string pattern)
        {
            string escaped = Escape(pattern);
            var lookbehindExpression = new NegativeLookbehind(escaped);

            return Append(lookbehindExpression);
        }

        private static string Escape(string literal)
        {
            return Regex.Escape(literal);
        }

        private RegularExpression Append(Subexpression subexpression)
        {
            _subexpressions.Add(subexpression);

            return this;
        }
    }
}
