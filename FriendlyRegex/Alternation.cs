using System.Collections.Generic;

namespace FriendlyRegularExpressions
{
    public class Alternation : RegularExpression
    {
        private readonly IEnumerable<RegularExpression> _alternatives;

        public Alternation(IEnumerable<RegularExpression> alternatives)
        {
            _alternatives = alternatives;
        }

        public override string GetStringRepresentation()
        {
            return "(?:" + _alternatives.StringJoin("|") + ")";
        }

        public override string Hierarchy
        {
            get { return "Alternation:" + GetStringRepresentation(); }
        }

        public static RegularExpression Between(RegularExpression[] expressions)
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
