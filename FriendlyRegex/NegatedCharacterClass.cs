namespace FriendlyRegularExpressions
{
    internal class NegatedCharacterClass : RegularExpression
    {
        private readonly CharacterRange[] _blacklist;

        public NegatedCharacterClass(params CharacterRange[] blacklist)
        {
            _blacklist = blacklist;
        }

        public override string GetStringRepresentation()
        {
            return "[^" + _blacklist.StringJoin() + "]";
        }
    }
}
