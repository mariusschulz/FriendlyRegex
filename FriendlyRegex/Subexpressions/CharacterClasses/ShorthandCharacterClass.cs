
namespace FriendlyRegularExpressions.Subexpressions.CharacterClasses
{
    internal class ShorthandCharacterClass : Subexpression
    {
        private readonly string _shorthandNotation;
        public string ShorthandNotation { get { return _shorthandNotation; } }

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
