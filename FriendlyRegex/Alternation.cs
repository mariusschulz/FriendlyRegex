using System.Collections.Generic;

namespace FriendlyRegularExpressions
{
    public class Alternation : RegularExpression
    {
        private readonly IEnumerable<IRegularExpression> _alternatives;

        public Alternation(IEnumerable<IRegularExpression> alternatives)
        {
            _alternatives = alternatives;
        }

        public override string GetStringRepresentation()
        {
            return "(?:" + _alternatives.StringJoin("|") + ")";
        }

        public static IRegularExpression Between(IRegularExpression[] expressions)
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
