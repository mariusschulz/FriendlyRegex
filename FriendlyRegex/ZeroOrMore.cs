using FriendlyRegularExpressions.Quantifiers;

namespace FriendlyRegularExpressions
{
    public static class ZeroOrMore
    {
        public static readonly IRegularExpression ArbitraryCharacters;

        public static readonly IRegularExpression Digits;
        public static readonly IRegularExpression NonDigits;

        public static readonly IRegularExpression WhiteSpaceCharacters;
        public static readonly IRegularExpression NonWhiteSpaceCharacters;

        public static readonly IRegularExpression WordCharacters;
        public static readonly IRegularExpression NonWordCharacters;

        static ZeroOrMore()
        {
            ArbitraryCharacters = StarQuantifier.LazilyQuantify(One.ArbitraryCharacter);

            Digits = StarQuantifier.GreedilyQuantify(One.Digit);
            NonDigits = StarQuantifier.GreedilyQuantify(One.NonDigit);

            WhiteSpaceCharacters = StarQuantifier.GreedilyQuantify(One.WhiteSpaceCharacter);
            NonWhiteSpaceCharacters = StarQuantifier.GreedilyQuantify(One.NonWhiteSpaceCharacter);

            WordCharacters = StarQuantifier.GreedilyQuantify(One.WordCharacter);
            NonWordCharacters = StarQuantifier.GreedilyQuantify(One.NonWordCharacter);
        }
    }
}
