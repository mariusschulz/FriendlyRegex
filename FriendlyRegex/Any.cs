using FriendlyRegularExpressions.Subexpressions.CharacterClasses;

namespace FriendlyRegularExpressions
{
    public static class Any
    {
        public static ShorthandCharacterClass Digit { get; private set; }

        static Any()
        {
            Digit = new ShorthandCharacterClass(@"\d");
        }
    }
}
