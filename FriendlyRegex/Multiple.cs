using FriendlyRegularExpressions.Subexpressions;
using FriendlyRegularExpressions.Subexpressions.Quantifiers;

namespace FriendlyRegularExpressions
{
    public static class Multiple
    {
        public static Subexpression ArbitraryCharacters { get; private set; }

        public static Subexpression Digits { get; private set; }
        public static Subexpression NonDigits { get; private set; }

        public static Subexpression WhiteSpaceCharacters { get; private set; }
        public static Subexpression NonWhiteSpaceCharacters { get; private set; }

        public static Subexpression WordCharacters { get; private set; }
        public static Subexpression NonWordCharacters { get; private set; }

        public static Subexpression Tabs { get; private set; }
        public static Subexpression NewLines { get; private set; }
        public static Subexpression CarriageReturns { get; private set; }

        static Multiple()
        {
            ArbitraryCharacters = new PlusQuantifier(One.ArbitraryCharacter);

            Digits = new PlusQuantifier(One.Digit);
            NonDigits = new PlusQuantifier(One.NonDigit);

            WhiteSpaceCharacters = new PlusQuantifier(One.WhiteSpaceCharacter);
            NonWhiteSpaceCharacters = new PlusQuantifier(One.NonWhiteSpaceCharacter);

            WordCharacters = new PlusQuantifier(One.WordCharacter);
            NonWordCharacters = new PlusQuantifier(One.NonWordCharacter);

            Tabs = new PlusQuantifier(One.Tab);
            NewLines = new PlusQuantifier(One.NewLine);
            CarriageReturns = new PlusQuantifier(One.CarriageReturn);
        }
    }
}
