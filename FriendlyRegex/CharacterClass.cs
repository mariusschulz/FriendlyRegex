using System.Collections.Generic;

namespace FriendlyRegularExpressions
{
    internal class CharacterClass : RegularExpression
    {
        private readonly IEnumerable<RegularExpression> _expressions;

        public CharacterClass(params RegularExpression[] RegularExpressions)
        {
            _expressions = RegularExpressions;
        }

        public override string GetStringRepresentation()
        {
            return "[" + string.Join(string.Empty, _expressions) + "]";
        }
    }
}
