using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using FriendlyRegularExpressions.Subexpressions;
using FriendlyRegularExpressions.Subexpressions.Backreferences;
using FriendlyRegularExpressions.Subexpressions.CharacterClasses;
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

        public FriendlyRegex ThenZeroOrMore(Subexpression expression)
        {
            return Append(new StarQuantifier(expression));
        }

        public FriendlyRegex ThenOneOrMore(Subexpression expression)
        {
            return Append(new PlusQuantifier(expression));
        }

        public FriendlyRegex ThenEither(params Subexpression[] alternatives)
        {
            return Append(new Alternation(alternatives));
        }

        public FriendlyRegex StartOfLine()
        {
            return Append(new Anchor("^"));
        }

        public FriendlyRegex EndOfLine()
        {
            return Append(new Anchor("$"));
        }

        public FriendlyRegex ThenMaybe(Subexpression expression)
        {
            return Append(new QuestionMarkQuantifier(expression));
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

        public FriendlyRegex ThenRange(char from, char to)
        {
            var fromBoundary = RangeBoundary.FromCharacter(from);
            var toBoundary = RangeBoundary.FromCharacter(to);

            var range = new Range(fromBoundary, toBoundary);

            return Append(new CharacterClass(range));
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

        public FriendlyRegex LookingAheadAt(Subexpression expression)
        {
            return Append(new PositiveLookahead(expression));
        }

        public FriendlyRegex NotLookingAheadAt(Subexpression expression)
        {
            return Append(new NegativeLookahead(expression));
        }

        public FriendlyRegex LookingBehindAt(Subexpression expression)
        {
            return Append(new PositiveLookbehind(expression));
        }

        public FriendlyRegex NotLookingBehindAt(Subexpression expression)
        {
            return Append(new NegativeLookbehind(expression));
        }

        public FriendlyRegex ThenValueOfCapture(int groupIndex)
        {
            return Append(new NumberedBackreference(groupIndex));
        }

        public FriendlyRegex ThenValueOfCapture(string groupName)
        {
            return Append(new NamedBackreference(groupName));
        }

        private FriendlyRegex Append(Subexpression subexpression)
        {
            _subexpressions.Add(subexpression);

            return this;
        }
    }
}
