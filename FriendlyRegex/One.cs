using FriendlyRegularExpressions.Subexpressions.CharacterClasses;

namespace FriendlyRegularExpressions
{
    public static class One
    {
        public static ShorthandCharacterClass Digit { get; private set; }
        public static ShorthandCharacterClass NonDigit { get; private set; }

        public static ShorthandCharacterClass WhiteSpaceCharacter { get; private set; }
        public static ShorthandCharacterClass NonWhiteSpaceCharacter { get; private set; }

        public static ShorthandCharacterClass WordCharacter { get; private set; }
        public static ShorthandCharacterClass NonWordCharacter { get; private set; }

        public static ShorthandCharacterClass WordBoundary { get; private set; }
        public static ShorthandCharacterClass NonWordBoundary { get; private set; }

        static One()
        {
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
