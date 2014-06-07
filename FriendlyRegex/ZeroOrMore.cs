using FriendlyRegularExpressions.Quantifiers;

namespace FriendlyRegularExpressions
{
    public static class ZeroOrMore
    {
        public static readonly RegularExpression ArbitraryCharacters;

        public static readonly RegularExpression Digits;
        public static readonly RegularExpression NonDigits;

        public static readonly RegularExpression WhiteSpaceCharacters;
        public static readonly RegularExpression NonWhiteSpaceCharacters;

        public static readonly RegularExpression WordCharacters;
        public static readonly RegularExpression NonWordCharacters;

        static ZeroOrMore()
        {
            ArbitraryCharacters = StarQuantifier.GreedilyQuantify(One.ArbitraryCharacter);

            Digits = StarQuantifier.GreedilyQuantify(One.Digit);
            NonDigits = StarQuantifier.GreedilyQuantify(One.NonDigit);

            WhiteSpaceCharacters = StarQuantifier.GreedilyQuantify(One.WhiteSpaceCharacter);
            NonWhiteSpaceCharacters = StarQuantifier.GreedilyQuantify(One.NonWhiteSpaceCharacter);

            WordCharacters = StarQuantifier.GreedilyQuantify(One.WordCharacter);
            NonWordCharacters = StarQuantifier.GreedilyQuantify(One.NonWordCharacter);
        }
    }
}
