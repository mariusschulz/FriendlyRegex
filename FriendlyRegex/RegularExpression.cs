﻿using System;
using System.Globalization;
using System.Text.RegularExpressions;
using FriendlyRegularExpressions.CharacterClasses;
using FriendlyRegularExpressions.Lookarounds;
using FriendlyRegularExpressions.Quantifiers;

namespace FriendlyRegularExpressions
{
    public abstract class RegularExpression
    {
        public abstract string GetStringRepresentation();

        public bool IsEmpty
        {
            get { return GetStringRepresentation() == string.Empty; }
        }

        public virtual string Hierarchy
        {
            get { return ""; }
        }

        public static implicit operator RegularExpression(char literalCharacter)
        {
            return new Literal(literalCharacter.ToString(CultureInfo.InvariantCulture));
        }

        public static implicit operator RegularExpression(string literal)
        {
            return new Literal(literal);
        }

        //public override string GetStringRepresentation()
        //{
        //    int nestingDepth = 0;

        //    foreach (var expression in _subexpressions)
        //    {
        //        if (expression is OpeningCapturingGroup)
        //        {
        //            nestingDepth++;
        //        }
        //        else if (expression is ClosingCapturingGroup)
        //        {
        //            nestingDepth--;
        //        }

        //        if (nestingDepth < 0)
        //        {
        //            throw new InvalidOperationException("Encountered unexpected closing parenthesis. "
        //                + "Did you attempt to close a capturing group that hasn't been openend before?");
        //        }
        //    }

        //    if (nestingDepth > 0)
        //    {
        //        throw new InvalidOperationException("Encountered too few closing parentheses (" + nestingDepth + " unclosed)");
        //    }

        //    return string.Join(string.Empty, _subexpressions);
        //}

        public override string ToString()
        {
            return GetStringRepresentation();
        }

        //public string ToPrettyString()
        //{
        //    var outputBuilder = new StringBuilder();

        //    using (var outputWriter = new StringWriter(outputBuilder))
        //    using (var output = new IndentedTextWriter(outputWriter))
        //    {
        //        foreach (var expression in _subexpressions)
        //        {
        //            if (expression is ClosingCapturingGroup)
        //                output.Indent--;

        //            output.WriteLine(expression);

        //            if (expression is OpeningCapturingGroup)
        //                output.Indent++;
        //        }
        //    }

        //    return outputBuilder.ToString();
        //}

        public Regex ToRegex()
        {
            return new Regex(GetStringRepresentation());
        }

        public RegularExpression Then(RegularExpression expression)
        {
            return ConcatenateThisWith(expression);
        }

        public RegularExpression ThenOptional(RegularExpression expression)
        {
            if (string.IsNullOrEmpty(expression.ToString()))
            {
                return this;
            }

            var optionalExpression = QuestionMarkQuantifier.Quantify(expression);

            return ConcatenateThisWith(optionalExpression);
        }

        public RegularExpression ThenOneOf(params string[] literals)
        {
            RegularExpression[] expressions = Array.ConvertAll(literals, literal => (RegularExpression)literal);

            return ThenOneOf(expressions);
        }

        public RegularExpression ThenOneOf(params RegularExpression[] expressions)
        {
            RegularExpression alternation = Alternation.CreateFrom(expressions);

            return ConcatenateThisWith(alternation);
        }

        public RegularExpression ThenOptionallyOneOf(params string[] literals)
        {
            RegularExpression[] expressions = Array.ConvertAll(literals, literal => (RegularExpression)literal);

            return ThenOptionallyOneOf(expressions);
        }

        public RegularExpression ThenOptionallyOneOf(params RegularExpression[] expressions)
        {
            RegularExpression alternation = Alternation.CreateFrom(expressions);
            RegularExpression optionalAlternation = QuestionMarkQuantifier.Quantify(alternation);

            return ConcatenateThisWith(optionalAlternation);
        }

        public RegularExpression ThenPattern(string pattern)
        {
            return ConcatenateThisWith(new RawPattern(pattern));
        }

        public RegularExpression ThenZeroOrMore(RegularExpression expression)
        {
            return ConcatenateThisWith(StarQuantifier.Quantify(expression));
        }

        public RegularExpression ThenOneOrMore(RegularExpression expression)
        {
            return ConcatenateThisWith(PlusQuantifier.Quantify(expression));
        }

        public RegularExpression ThenWhitespace()
        {
            var whitespace = new ShorthandCharacterClass(@"\s");
            var repeatedWhitespace = PlusQuantifier.Quantify(whitespace);

            return ConcatenateThisWith(repeatedWhitespace);
        }

        public RegularExpression ThenOptionalWhitespace()
        {
            var whitespace = new ShorthandCharacterClass(@"\s");
            var optionalWhitespace = StarQuantifier.Quantify(whitespace);

            return ConcatenateThisWith(optionalWhitespace);
        }

        //public RegularExpression ThenAtLeast(int minRepetitions, string literal)
        //{
        //    throw new NotImplementedException();
        //}

        public RegularExpression StartOfLine()
        {
            return ConcatenateThisWith(new StartAnchor());
        }

        public RegularExpression EndOfLine()
        {
            return ConcatenateThisWith(new EndAnchor());
        }

        public RegularExpression After(RegularExpression expression)
        {
            return ConcatenateThisWith(PositiveLookbehind.At(expression));
        }

        public RegularExpression Before(RegularExpression expression)
        {
            return ConcatenateThisWith(PositiveLookahead.At(expression));
        }

        public RegularExpression NotAheadOf(RegularExpression expression)
        {
            return ConcatenateThisWith(NegativeLookahead.At(expression));
        }

        public RegularExpression NotBehind(RegularExpression expression)
        {
            return ConcatenateThisWith(NegativeLookbehind.At(expression));
        }

        private RegularExpression ConcatenateThisWith(RegularExpression expression)
        {
            return Concatenation.Concatenate(this, expression);
        }

        //public FriendlyRegex EndOfLine()
        //{
        //    return Then(new EndAnchor());
        //}

        //public FriendlyRegex ThenMaybe(RegularExpression expression)
        //{
        //    return Then(new QuestionMarkQuantifier(expression));
        //}

        //public FriendlyRegex ThenSomething()
        //{
        //    return Then(new PlusQuantifier(new Dot()));
        //}

        //public FriendlyRegex ThenMaybeSomething()
        //{
        //    return Then(new StarQuantifier(new Dot()));
        //}

        //public FriendlyRegex BeginCapture()
        //{
        //    return Then(new OpeningCapturingGroup());
        //}

        //public FriendlyRegex BeginCapture(string name)
        //{
        //    return Then(new OpeningCapturingGroup(name));
        //}

        //public FriendlyRegex EndCapture()
        //{
        //    return Then(new ClosingCapturingGroup());
        //}

        //public FriendlyRegex ThenValueOfCapture(int groupIndex)
        //{
        //    return Then(new NumberedBackreference(groupIndex));
        //}

        //public FriendlyRegex ThenValueOfCapture(string groupName)
        //{
        //    return Then(new NamedBackreference(groupName));
        //}

        //public FriendlyRegex Or(RegularExpression expression)
        //{
        //    var lastToken = _subexpressions.Last();
        //    var newAlternatives = new List<RegularExpression>();

        //    var alternation = lastToken as Alternation;
        //    if (alternation != null)
        //    {
        //        newAlternatives.AddRange(alternation.Alternatives);
        //        newAlternatives.Add(expression);
        //    }
        //    else
        //    {
        //        newAlternatives.Add(lastToken);
        //        newAlternatives.Add(expression);
        //    }

        //    _subexpressions.Remove(lastToken);

        //    return Then(new Alternation(newAlternatives));
        //}

        //public FriendlyRegex OrPattern(string pattern)
        //{
        //    return Or(new RawPattern(pattern));
        //}

        public static RegularExpression New()
        {
            return Epsilon.Instance;
        }
    }
}