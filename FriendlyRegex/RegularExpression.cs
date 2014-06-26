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

        public override string ToString()
        {
            return GetStringRepresentation();
        }

        public Regex ToRegex()
        {
            return new Regex(GetStringRepresentation());
        }

        public IQuantifiableRegularExpression Then(char character)
        {
            return ConcatenateThisWith(AsLiteral(character));
        }

        public IQuantifiableRegularExpression Then(string literal)
        {
            return ConcatenateThisWith(AsLiteral(literal));
        }

        public IQuantifiableRegularExpression Then(IRegularExpression expression)
        {
            return ConcatenateThisWith(expression);
        }

        public Concatenation Maybe(char character)
        {
            return Maybe(AsLiteral(character));
        }

        public Concatenation Maybe(string literal)
        {
            return Maybe(AsLiteral(literal));
        }

        public Concatenation Maybe(IRegularExpression expression)
        {
            var optionalExpression = QuestionMarkQuantifier.GreedilyQuantify(expression);

            return ConcatenateThisWith(optionalExpression);
        }

        public Concatenation MaybeAnything()
        {
            var optionalAnything = StarQuantifier.LazilyQuantify(One.ArbitraryCharacter);

            return ConcatenateThisWith(optionalAnything);
        }

        public IQuantifiableRegularExpression OneOf(params string[] literals)
        {
            var expressions = literals
                .Select(AsLiteral)
                .ToArray();

            return OneOf(expressions);
        }

        public IQuantifiableRegularExpression OneOf(params IRegularExpression[] expressions)
        {
            var alternation = Alternation.Between(expressions);

            return ConcatenateThisWith(alternation);
        }

        public Concatenation MaybeOneOf(params string[] literals)
        {
            var expressions = literals
                .Select(AsLiteral)
                .ToArray();

            return MaybeOneOf(expressions);
        }

        public Concatenation MaybeOneOf(params IRegularExpression[] expressions)
        {
            var alternation = Alternation.Between(expressions);
            var optionalAlternation = QuestionMarkQuantifier.GreedilyQuantify(alternation);

            return ConcatenateThisWith(optionalAlternation);
        }

        public IQuantifiableRegularExpression Pattern(string pattern)
        {
            return ConcatenateThisWith(new RawPattern(pattern));
        }

        public IQuantifiableRegularExpression AtomicPattern(string pattern)
        {
            var rawPattern = new RawPattern(pattern);
            var atomicGroup = new AtomicGroup(rawPattern);

            return ConcatenateThisWith(atomicGroup);
        }

        public Concatenation ZeroOrMore(IRegularExpression expression)
        {
            return ConcatenateThisWith(StarQuantifier.GreedilyQuantify(expression));
        }

        public Concatenation OneOrMore(IRegularExpression expression)
        {
            return ConcatenateThisWith(PlusQuantifier.GreedilyQuantify(expression));
        }

        public Concatenation Whitespace()
        {
            return ConcatenateThisWith(FriendlyRegularExpressions.OneOrMore.WhiteSpaceCharacters);
        }

        public Concatenation MaybeWhitespace()
        {
            return ConcatenateThisWith(FriendlyRegularExpressions.ZeroOrMore.WhiteSpaceCharacters);
        }

        public Concatenation Anything()
        {
            var anything = PlusQuantifier.LazilyQuantify(One.ArbitraryCharacter);

            return ConcatenateThisWith(anything);
        }

        public IQuantifiableRegularExpression AnythingBut(params char[] blacklist)
        {
            Range[] blacklistedRanges = blacklist.Select(Range.FromSingle).ToArray();

            return AnythingBut(blacklistedRanges);
        }

        public IQuantifiableRegularExpression AnythingBut(params Range[] blacklist)
        {
            var negatedCharacterClass = new NegatedCharacterClass(blacklist);
            var repetition = PlusQuantifier.LazilyQuantify(negatedCharacterClass);

            return ConcatenateThisWith(repetition);
        }

        public IQuantifiableRegularExpression FromRange(char from, char to)
        {
            var range = new Range(from, to);
            var characterClass = new CharacterClass(range);

            return ConcatenateThisWith(characterClass);
        }

        public Concatenation StartOfLine()
        {
            return ConcatenateThisWith(Anchor.StartOfStringOrLine);
        }

        public Concatenation EndOfLine()
        {
            return ConcatenateThisWith(Anchor.EndOfStringOrLine);
        }

        public Concatenation After(IRegularExpression expression)
        {
            return ConcatenateThisWith(PositiveLookbehind.At(expression));
        }

        public Concatenation Before(IRegularExpression expression)
        {
            return ConcatenateThisWith(PositiveLookahead.At(expression));
        }

        public Concatenation NotBefore(IRegularExpression expression)
        {
            return ConcatenateThisWith(NegativeLookahead.At(expression));
        }

        public Concatenation NotAfter(IRegularExpression expression)
        {
            return ConcatenateThisWith(NegativeLookbehind.At(expression));
        }

        public Concatenation BeginCapture()
        {
            return ConcatenateThisWith(new OpeningCapturingGroup());
        }

        public Concatenation BeginCapture(string groupName)
        {
            return ConcatenateThisWith(new OpeningCapturingGroup(groupName));
        }

        public Concatenation EndCapture()
        {
            return ConcatenateThisWith(new ClosingCapturingGroup());
        }

        public ICapturedRegularExpression Capture(IRegularExpression expression)
        {
            return ConcatenateThisWith(new UnnamedCapturingGroup(expression));
        }

        public IQuantifiableRegularExpression ValueOfCapture(int groupIndex)
        {
            return ConcatenateThisWith(new NumberedBackreference(groupIndex));
        }

        public IQuantifiableRegularExpression ValueOfCapture(string groupName)
        {
            return ConcatenateThisWith(new NamedBackreference(groupName));
        }

        IRegularExpression ICapturedRegularExpression.As(string groupName)
        {
            var capturingGroup = this as UnnamedCapturingGroup;

            if (capturingGroup != null)
            {
                return capturingGroup.As(groupName);
            }

            Concatenation concatenation = (Concatenation)this;
            IRegularExpression[] expressions = concatenation.CreateExpressionsArray();

            capturingGroup = (UnnamedCapturingGroup)expressions.Last();
            expressions[expressions.Length - 1] = capturingGroup.As(groupName);

            return Concatenation.Concatenate(expressions);
        }

        private static IRegularExpression AsLiteral(char character)
        {
            return AsLiteral(character.ToString(CultureInfo.InvariantCulture));
        }

        private static IRegularExpression AsLiteral(string literal)
        {
            return new Literal(literal);
        }

        private Concatenation ConcatenateThisWith(IRegularExpression expression)
        {
            return Concatenation.Concatenate(this, expression);
        }

        //public FriendlyRegex Or(IRegularExpression expression)
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
