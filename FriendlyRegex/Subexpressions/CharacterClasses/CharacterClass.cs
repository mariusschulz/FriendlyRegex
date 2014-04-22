using System.Collections.Generic;

namespace FriendlyRegularExpressions.Subexpressions.CharacterClasses
{
    internal class CharacterClass : Subexpression
    {
        private readonly IEnumerable<Subexpression> _subexpressions;

        public CharacterClass(params Subexpression[] subexpressions)
        {
            _subexpressions = subexpressions;
        }

        public override string GetStringRepresentation()
        {
            return "[" + string.Join(string.Empty, _subexpressions) + "]";
        }
    }
}
