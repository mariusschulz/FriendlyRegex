using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using FriendlyRegularExpressions.Subexpressions;
using FriendlyRegularExpressions.Subexpressions.Backreferences;
using FriendlyRegularExpressions.Subexpressions.Groups;
using FriendlyRegularExpressions.Subexpressions.Lookarounds;
using FriendlyRegularExpressions.Subexpressions.Quantifiers;

namespace FriendlyRegularExpressions
{
    public class FriendlyRegex
    {
        private readonly IList<Subexpression> _subexpressions;

        public FriendlyRegex()
        {
            _subexpressions = new List<Subexpression>();
        }

        public override string ToString()
        {
            int nestingDepth = 0;

            foreach (var expression in _subexpressions)
            {
                if (expression is OpeningCapturingGroup)
                {
                    nestingDepth++;
                }
                else if (expression is ClosingCapturingGroup)
                {
                    nestingDepth--;
                }

                if (nestingDepth < 0)
                {
                    throw new InvalidOperationException("Encountered unexpected closing parenthesis. "
                        + "Did you attempt to close a capturing group that hasn't been openend before?");
                }
            }

            if (nestingDepth > 0)
            {
                throw new InvalidOperationException("Encountered too few closing parentheses (" + nestingDepth + " unclosed)");
            }

            return string.Join(string.Empty, _subexpressions);
        }

        public string ToPrettyString()
        {
            var outputBuilder = new StringBuilder();

            using (var outputWriter = new StringWriter(outputBuilder))
            using (var output = new IndentedTextWriter(outputWriter))
            {
                foreach (var expression in _subexpressions)
                {
                    if (expression is ClosingCapturingGroup)
                        output.Indent--;

                    output.WriteLine(expression);

                    if (expression is OpeningCapturingGroup)
                        output.Indent++;
                }
            }

            return outputBuilder.ToString();
        }

        public Regex ToRegex()
        {
            return new Regex(ToString());
        }

        public FriendlyRegex Then(Subexpression subexpression)
        {
            _subexpressions.Add(subexpression);

            return this;
        }

        public FriendlyRegex ThenZeroOrMore(Subexpression expression)
        {
            return Then(new StarQuantifier(expression));
        }

        public FriendlyRegex ThenOneOrMore(Subexpression expression)
        {
            return Then(new PlusQuantifier(expression));
        }

        public FriendlyRegex ThenEither(params Subexpression[] alternatives)
        {
            return Then(new Alternation(alternatives));
        }

        public FriendlyRegex StartOfLine()
        {
            return Then(new StartAnchor());
        }

        public FriendlyRegex EndOfLine()
        {
            return Then(new EndAnchor());
        }

        public FriendlyRegex ThenMaybe(Subexpression expression)
        {
            return Then(new QuestionMarkQuantifier(expression));
        }

        public FriendlyRegex ThenRaw(string pattern)
        {
            return Then(new RawPattern(pattern));
        }

        public FriendlyRegex ThenSomething()
        {
            return Then(new PlusQuantifier(new Dot()));
        }

        public FriendlyRegex ThenMaybeSomething()
        {
            return Then(new StarQuantifier(new Dot()));
        }

        public FriendlyRegex BeginCapture()
        {
            return Then(new OpeningCapturingGroup());
        }

        public FriendlyRegex BeginCapture(string name)
        {
            return Then(new OpeningCapturingGroup(name));
        }

        public FriendlyRegex EndCapture()
        {
            return Then(new ClosingCapturingGroup());
        }

        public FriendlyRegex LookingAheadAt(Subexpression expression)
        {
            return Then(new PositiveLookahead(expression));
        }

        public FriendlyRegex NotLookingAheadAt(Subexpression expression)
        {
            return Then(new NegativeLookahead(expression));
        }

        public FriendlyRegex LookingBehindAt(Subexpression expression)
        {
            return Then(new PositiveLookbehind(expression));
        }

        public FriendlyRegex NotLookingBehindAt(Subexpression expression)
        {
            return Then(new NegativeLookbehind(expression));
        }

        public FriendlyRegex ThenValueOfCapture(int groupIndex)
        {
            return Then(new NumberedBackreference(groupIndex));
        }

        public FriendlyRegex ThenValueOfCapture(string groupName)
        {
            return Then(new NamedBackreference(groupName));
        }

        public FriendlyRegex Or(Subexpression expression)
        {
            var lastToken = _subexpressions.Last();
            var newAlternatives = new List<Subexpression>();

            var alternation = lastToken as Alternation;
            if (alternation != null)
            {
                newAlternatives.AddRange(alternation.Alternatives);
                newAlternatives.Add(expression);
            }
            else
            {
                newAlternatives.Add(lastToken);
                newAlternatives.Add(expression);
            }

            _subexpressions.Remove(lastToken);

            return Then(new Alternation(newAlternatives));
        }
    }
}
