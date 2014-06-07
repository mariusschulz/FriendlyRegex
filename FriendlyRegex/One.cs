using FriendlyRegularExpressions.CharacterClasses;

namespace FriendlyRegularExpressions
{
    public static class One
    {
        public static readonly RegularExpression ArbitraryCharacter;

        public static readonly RegularExpression Digit;
        public static readonly RegularExpression NonDigit;

        public static readonly RegularExpression WhiteSpaceCharacter;
        public static readonly RegularExpression NonWhiteSpaceCharacter;

        public static readonly RegularExpression WordCharacter;
        public static readonly RegularExpression NonWordCharacter;

        public static readonly RegularExpression WordBoundary;
        public static readonly RegularExpression NonWordBoundary;

        static One()
        {
            ArbitraryCharacter = new Dot();

            Digit = new ShorthandCharacterClass(@"\d");
            NonDigit = new ShorthandCharacterClass(@"\D");

            WhiteSpaceCharacter = new ShorthandCharacterClass(@"\s");
            NonWhiteSpaceCharacter = new ShorthandCharacterClass(@"\S");

            WordCharacter = new ShorthandCharacterClass(@"\w");
            NonWordCharacter = new ShorthandCharacterClass(@"\W");

            WordBoundary = new ShorthandCharacterClass(@"\b");
            NonWordBoundary = new ShorthandCharacterClass(@"\B");
        }
    }
}
