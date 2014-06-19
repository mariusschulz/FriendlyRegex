namespace FriendlyRegularExpressions.CharacterClasses
{
    internal class ShorthandCharacterClass : RegularExpression
    {
        private readonly string _shorthandNotation;

        internal ShorthandCharacterClass(string shorthandNotation)
        {
            _shorthandNotation = shorthandNotation;
        }

        public override string GetStringRepresentation()
        {
            return _shorthandNotation;
        }
    }
}
