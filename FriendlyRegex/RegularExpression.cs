using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using FriendlyRegularExpressions.Backreferences;
using FriendlyRegularExpressions.Groups;
using FriendlyRegularExpressions.Lookarounds;
using FriendlyRegularExpressions.Quantifiers;

namespace FriendlyRegularExpressions
{
    public abstract class RegularExpression : ICapturedRegularExpression
    {
        public abstract string GetStringRepresentation();

        public bool IsEmpty
        {
            get { return GetStringRepresentation() == String.Empty; }
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

        public RegularExpression ThenOptionallyAnything()
        {
            var optionalAnything = StarQuantifier.LazilyQuantify(One.ArbitraryCharacter);

            return ConcatenateThisWith(optionalAnything);
        }

        public RegularExpression ThenOneOf(params string[] literals)
        {
            RegularExpression[] expressions = Array.ConvertAll(literals, literal => (RegularExpression)literal);

            return ThenOneOf(expressions);
        }

        public RegularExpression ThenOneOf(params RegularExpression[] expressions)
        {
            var alternation = Alternation.Between(expressions);

            return ConcatenateThisWith(alternation);
        }

        public RegularExpression ThenOptionallyOneOf(params string[] literals)
        {
            RegularExpression[] expressions = Array.ConvertAll(literals, literal => (RegularExpression)literal);

            return ThenOptionallyOneOf(expressions);
        }

        public RegularExpression ThenOptionallyOneOf(params RegularExpression[] expressions)
        {
            var alternation = Alternation.Between(expressions);
            var optionalAlternation = QuestionMarkQuantifier.GreedilyQuantify(alternation);

            return ConcatenateThisWith(optionalAlternation);
        }

        public RegularExpression ThenPattern(string pattern)
        {
            return ConcatenateThisWith(new RawPattern(pattern));
        }

        public RegularExpression ThenAtomicPattern(string pattern)
        {
            var rawPattern = new RawPattern(pattern);
            var atomicGroup = new AtomicGroup(rawPattern);

            return ConcatenateThisWith(atomicGroup);
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

        public RegularExpression ThenAnythingBut(params char[] blacklist)
        {
            Range[] blacklistedRanges = blacklist.Select(Range.FromSingle).ToArray();

            return ThenAnythingBut(blacklistedRanges);
        }

        public RegularExpression ThenAnythingBut(params Range[] blacklist)
        {
            var negatedCharacterClass = new NegatedCharacterClass(blacklist);
            var repetition = PlusQuantifier.LazilyQuantify(negatedCharacterClass);

            return ConcatenateThisWith(repetition);
        }

        public RegularExpression ThenCharacterInRange(char from, char to)
        {
            var range = new Range(from, to);
            var characterClass = new CharacterClass(range);

            return ConcatenateThisWith(characterClass);
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

        public RegularExpression NotBefore(RegularExpression expression)
        {
            return ConcatenateThisWith(NegativeLookahead.At(expression));
        }

        public RegularExpression NotAfter(RegularExpression expression)
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

        public ICapturedRegularExpression ThenCapture(RegularExpression expression)
        {
            return ConcatenateThisWith(new UnnamedCapturingGroup(expression));
        }

        public RegularExpression ThenValueOfCapture(int groupIndex)
        {
            return ConcatenateThisWith(new NumberedBackreference(groupIndex));
        }

        public RegularExpression ThenValueOfCapture(string groupName)
        {
            return ConcatenateThisWith(new NamedBackreference(groupName));
        }

        RegularExpression ICapturedRegularExpression.As(string groupName)
        {
            var capturingGroup = this as UnnamedCapturingGroup;

            if (capturingGroup != null)
            {
                return capturingGroup.As(groupName);
            }

            Concatenation concatenation = (Concatenation)this;
            RegularExpression[] expressions = concatenation.CreateExpressionsArray();

            capturingGroup = (UnnamedCapturingGroup)expressions.Last();
            expressions[expressions.Length - 1] = capturingGroup.As(groupName);

            return Concatenation.Concatenate(expressions);
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
            return Epsilon.Instance;
        }
    }
}
