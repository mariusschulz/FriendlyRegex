using FriendlyRegularExpressions.Quantifiers;

namespace FriendlyRegularExpressions
{
    public static class OneOrMore
    {
        public static readonly RegularExpression ArbitraryCharacters;

        public static readonly RegularExpression Digits;
        public static readonly RegularExpression NonDigits;

        public static readonly RegularExpression WhiteSpaceCharacters;
        public static readonly RegularExpression NonWhiteSpaceCharacters;

        public static readonly RegularExpression WordCharacters;
        public static readonly RegularExpression NonWordCharacters;

        static OneOrMore()
        {
            ArbitraryCharacters = PlusQuantifier.GreedilyQuantify(One.ArbitraryCharacter);

            Digits = PlusQuantifier.GreedilyQuantify(One.Digit);
            NonDigits = PlusQuantifier.GreedilyQuantify(One.NonDigit);

            WhiteSpaceCharacters = PlusQuantifier.GreedilyQuantify(One.WhiteSpaceCharacter);
            NonWhiteSpaceCharacters = PlusQuantifier.GreedilyQuantify(One.NonWhiteSpaceCharacter);

            WordCharacters = PlusQuantifier.GreedilyQuantify(One.WordCharacter);
            NonWordCharacters = PlusQuantifier.GreedilyQuantify(One.NonWordCharacter);
        }
    }
}
