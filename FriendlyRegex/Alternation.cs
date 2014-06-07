using System.Collections.Generic;

namespace FriendlyRegularExpressions
{
    internal class Alternation : RegularExpression
    {
        private readonly IEnumerable<RegularExpression> _alternatives;

        public Alternation(IEnumerable<RegularExpression> alternatives)
        {
            _alternatives = alternatives;
        }

        public override string GetStringRepresentation()
        {
            return "(?:" + string.Join("|", _alternatives) + ")";
        }

        public override string Hierarchy
        {
            get { return "Alternation:" + GetStringRepresentation(); }
        }

        public static RegularExpression CreateFrom(RegularExpression[] expressions)
        {
            if (expressions.Length == 0)
            {
                return Epsilon.Instance;
            }

            if (expressions.Length == 1)
            {
                return expressions[0];
            }

            return new Alternation(expressions);
        }
    }
}
