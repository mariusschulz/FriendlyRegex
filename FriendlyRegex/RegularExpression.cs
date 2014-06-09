using System;
using System.Globalization;
using System.Text.RegularExpressions;
using FriendlyRegularExpressions.Backreferences;
using FriendlyRegularExpressions.Groups;
using FriendlyRegularExpressions.Lookarounds;
using FriendlyRegularExpressions.Quantifiers;

namespace FriendlyRegularExpressions
{
    public abstract class RegularExpression
    {
        public abstract string GetStringRepresentation();

        public static readonly RegularExpression Epsilon;

        static RegularExpression()
        {
            Epsilon = FriendlyRegularExpressions.Epsilon.Instance;
        }

        public bool IsEmpty
        {
            get { return GetStringRepresentation() == String.Empty; }
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

        public override string ToString()
        {
            return GetStringRepresentation();
        }

        public Regex ToRegex()
        {
            return new Regex(GetStringRepresentation());
        }

        public RegularExpression Then(RegularExpression expression)
        {
            return ConcatenateThisWith(expression);
        }

        public RegularExpression ThenOptionally(RegularExpression expression)
        {
            if (expression.IsEmpty)
            {
                return this;
            }

            var optionalExpression = QuestionMarkQuantifier.GreedilyQuantify(expression);

            return ConcatenateThisWith(optionalExpression);
        }

        public RegularExpression ThenOneOf(params string[] literals)
        {
            RegularExpression[] expressions = Array.ConvertAll(literals, literal => (RegularExpression)literal);

            return ThenOneOf(expressions);
        }

        public RegularExpression ThenOneOf(params RegularExpression[] expressions)
        {
            RegularExpression alternation = Alternation.Between(expressions);

            return ConcatenateThisWith(alternation);
        }

        public RegularExpression ThenOptionallyOneOf(params string[] literals)
        {
            RegularExpression[] expressions = Array.ConvertAll(literals, literal => (RegularExpression)literal);

            return ThenOptionallyOneOf(expressions);
        }

        public RegularExpression ThenOptionallyAnything()
        {
            var optionalAnything = StarQuantifier.LazilyQuantify(One.ArbitraryCharacter);

            return ConcatenateThisWith(optionalAnything);
        }

        public RegularExpression ThenOptionallyOneOf(params RegularExpression[] expressions)
        {
            RegularExpression alternation = Alternation.Between(expressions);
            RegularExpression optionalAlternation = QuestionMarkQuantifier.GreedilyQuantify(alternation);

            return ConcatenateThisWith(optionalAlternation);
        }

        public RegularExpression ThenPattern(string pattern)
        {
            return ConcatenateThisWith(new RawPattern(pattern));
        }

        public RegularExpression ThenZeroOrMore(RegularExpression expression)
        {
            return ConcatenateThisWith(StarQuantifier.GreedilyQuantify(expression));
        }

        public RegularExpression ThenOneOrMore(RegularExpression expression)
        {
            return ConcatenateThisWith(PlusQuantifier.GreedilyQuantify(expression));
        }

        public RegularExpression ThenWhitespace()
        {
            return ConcatenateThisWith(OneOrMore.WhiteSpaceCharacters);
        }

        public RegularExpression ThenOptionalWhitespace()
        {
            return ConcatenateThisWith(ZeroOrMore.WhiteSpaceCharacters);
        }

        public RegularExpression ThenAnything()
        {
            var anything = PlusQuantifier.LazilyQuantify(One.ArbitraryCharacter);

            return ConcatenateThisWith(anything);
        }

        public RegularExpression StartOfLine()
        {
            return ConcatenateThisWith(Anchor.StartOfStringOrLine);
        }

        public RegularExpression EndOfLine()
        {
            return ConcatenateThisWith(Anchor.EndOfStringOrLine);
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

        public RegularExpression BeginCapture()
        {
            return ConcatenateThisWith(new OpeningCapturingGroup());
        }

        public RegularExpression BeginCapture(string groupName)
        {
            return ConcatenateThisWith(new OpeningCapturingGroup(groupName));
        }

        public RegularExpression EndCapture()
        {
            return ConcatenateThisWith(new ClosingCapturingGroup());
        }

        public RegularExpression ThenCapture(RegularExpression expression)
        {
            return BeginCapture().ConcatenateThisWith(expression).EndCapture();
        }

        public RegularExpression ThenNamedCapture(string groupName, RegularExpression expression)
        {
            return ConcatenateThisWith(new OpeningCapturingGroup(groupName))
                .ConcatenateThisWith(expression)
                .EndCapture();
        }

        public RegularExpression ThenValueOfCapture(int groupIndex)
        {
            return ConcatenateThisWith(new NumberedBackreference(groupIndex));
        }

        public RegularExpression ThenValueOfCapture(string groupName)
        {
            return ConcatenateThisWith(new NamedBackreference(groupName));
        }

        private RegularExpression ConcatenateThisWith(RegularExpression expression)
        {
            return Concatenation.Concatenate(this, expression);
        }

        //public FriendlyRegex Or(RegularExpression expression)
        //{
        //    var lastToken = _RegularExpressions.Last();
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

        //    _RegularExpressions.Remove(lastToken);

        //    return Then(new Alternation(newAlternatives));
        //}

        //public FriendlyRegex OrPattern(string pattern)
        //{
        //    return Or(new RawPattern(pattern));
        //}

        public static RegularExpression New()
        {
            return Epsilon;
        }
    }
}
