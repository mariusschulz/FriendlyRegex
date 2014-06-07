using System.Collections.Generic;

namespace FriendlyRegularExpressions
{
    internal class CharacterClass : RegularExpression
    {
        private readonly IEnumerable<RegularExpression> _RegularExpressions;

        public CharacterClass(params RegularExpression[] RegularExpressions)
        {
            _RegularExpressions = RegularExpressions;
        }

        public override string GetStringRepresentation()
        {
            return "[" + string.Join(string.Empty, _RegularExpressions) + "]";
        }
    }
}
