namespace FriendlyRegularExpressions
{
    public class CharacterClass : RegularExpression
    {
        private readonly Range[] _ranges;

        public CharacterClass(params Range[] ranges)
        {
            _ranges = ranges;
        }

        public override string GetStringRepresentation()
        {
            return "[" + _ranges.StringJoin() + "]";
        }
    }
}
