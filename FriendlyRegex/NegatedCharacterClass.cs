using FriendlyRegularExpressions.Extensions;

namespace FriendlyRegularExpressions
{
    internal class NegatedCharacterClass : RegularExpression
    {
        private readonly Range[] _blacklist;

        public NegatedCharacterClass(params Range[] blacklist)
        {
            _blacklist = blacklist;
        }

        public override string GetStringRepresentation()
        {
            return "[^" + _blacklist.StringJoin() + "]";
        }
    }
}
