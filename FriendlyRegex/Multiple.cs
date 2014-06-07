using FriendlyRegularExpressions.Quantifiers;

namespace FriendlyRegularExpressions
{
    public static class Multiple
    {
        public static readonly RegularExpression ArbitraryCharacters;

        public static readonly RegularExpression Digits;
        public static readonly RegularExpression NonDigits;

        public static readonly RegularExpression WhiteSpaceCharacters;
        public static readonly RegularExpression NonWhiteSpaceCharacters;

        public static readonly RegularExpression WordCharacters;
        public static readonly RegularExpression NonWordCharacters;

        static Multiple()
        {
            ArbitraryCharacters = PlusQuantifier.Quantify(One.ArbitraryCharacter);

            Digits = PlusQuantifier.Quantify(One.Digit);
            NonDigits = PlusQuantifier.Quantify(One.NonDigit);

            WhiteSpaceCharacters = PlusQuantifier.Quantify(One.WhiteSpaceCharacter);
            NonWhiteSpaceCharacters = PlusQuantifier.Quantify(One.NonWhiteSpaceCharacter);

            WordCharacters = PlusQuantifier.Quantify(One.WordCharacter);
            NonWordCharacters = PlusQuantifier.Quantify(One.NonWordCharacter);
        }
    }
}
