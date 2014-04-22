using FriendlyRegularExpressions.Subexpressions;
using FriendlyRegularExpressions.Subexpressions.CharacterClasses;

namespace FriendlyRegularExpressions
{
    public static class One
    {
        public static Subexpression ArbitraryCharacter { get; private set; }

        public static Subexpression Digit { get; private set; }
        public static Subexpression NonDigit { get; private set; }

        public static Subexpression WhiteSpaceCharacter { get; private set; }
        public static Subexpression NonWhiteSpaceCharacter { get; private set; }

        public static Subexpression WordCharacter { get; private set; }
        public static Subexpression NonWordCharacter { get; private set; }

        public static Subexpression WordBoundary { get; private set; }
        public static Subexpression NonWordBoundary { get; private set; }

        static One()
        {
            ArbitraryCharacter = new Dot();

            Digit = new ShorthandCharacterClass(@"\d");
            NonDigit = new ShorthandCharacterClass(@"\D");

            WhiteSpaceCharacter = new ShorthandCharacterClass(@"\s");
            NonWhiteSpaceCharacter = new ShorthandCharacterClass(@"\S");

            WordCharacter = new ShorthandCharacterClass(@"\w");
            NonWordCharacter = new ShorthandCharacterClass(@"\W");

            WordBoundary = new Anchor(@"\b");
            NonWordBoundary = new Anchor(@"\B");
        }
    }
}
