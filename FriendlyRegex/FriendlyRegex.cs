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
        private readonly ICollection<Subexpression> _subexpressions;

        public FriendlyRegex()
        {
            _subexpressions = new LinkedList<Subexpression>();
        }

        public override string ToString()
        {
            return string.Join(string.Empty, _subexpressions);
        }

        public Regex ToRegex()
        {
            return new Regex(ToString());
        }

        public FriendlyRegex ThenZeroOrMore(string literal)
        {
            return ThenZeroOrMore(new Literal(literal));
        }

        public FriendlyRegex ThenZeroOrMore(Subexpression expression)
        {
            return Append(new StarQuantifier(expression));
        }

        public FriendlyRegex ThenOneOrMore(string literal)
        {
            return ThenOneOrMore(new Literal(literal));
        }

        public FriendlyRegex ThenOneOrMore(Subexpression expression)
        {
            return Append(new PlusQuantifier(expression));
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
            return ThenMaybe(new Literal(literal));
        }

        public FriendlyRegex ThenMaybe(Subexpression expression)
        {
            return Append(new QuestionMarkQuantifier(expression));
        }

        public FriendlyRegex Then(string literal)
        {
            return Then(new Literal(literal));
        }

        public FriendlyRegex Then(Subexpression expression)
        {
            return Append(expression);
        }

        public FriendlyRegex ThenRaw(string pattern)
        {
            return Append(new RawPattern(pattern));
        }

        public FriendlyRegex ThenSomething()
        {
            return Append(new PlusQuantifier(new Dot()));
        }

        public FriendlyRegex ThenMaybeSomething()
        {
            return Append(new StarQuantifier(new Dot()));
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

        public FriendlyRegex LookingAheadAt(string literal)
        {
            return LookingAheadAt(new Literal(literal));
        }

        public FriendlyRegex LookingAheadAt(Subexpression expression)
        {
            return Append(new PositiveLookahead(expression));
        }

        public FriendlyRegex NotLookingAheadAt(string literal)
        {
            return NotLookingAheadAt(new Literal(literal));
        }

        public FriendlyRegex NotLookingAheadAt(Subexpression expression)
        {
            return Append(new NegativeLookahead(expression));
        }

        public FriendlyRegex LookingBehindAt(string literal)
        {
            return LookingBehindAt(new Literal(literal));
        }

        public FriendlyRegex LookingBehindAt(Subexpression expression)
        {
            return Append(new PositiveLookbehind(expression));
        }

        public FriendlyRegex NotLookingBehindAt(string literal)
        {
            return NotLookingBehindAt(new Literal(literal));
        }

        public FriendlyRegex NotLookingBehindAt(Subexpression expression)
        {
            return Append(new NegativeLookbehind(expression));
        }

        private FriendlyRegex Append(Subexpression subexpression)
        {
            _subexpressions.Add(subexpression);

            return this;
        }
    }
}
