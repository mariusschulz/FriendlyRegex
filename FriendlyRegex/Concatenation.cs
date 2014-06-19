using System.Collections.Generic;
using System.Linq;

namespace FriendlyRegularExpressions
{
    class Concatenation : RegularExpression
    {
        private readonly IEnumerable<RegularExpression> _expressions;

        private Concatenation(RegularExpression left, RegularExpression right)
            : this(new[] { left, right })
        {
            // Nothing to do here
        }

        private Concatenation(IEnumerable<RegularExpression> expressions)
        {
            _expressions = expressions;
        }

        public override string GetStringRepresentation()
        {
            return _expressions.StringJoin();
        }

        public RegularExpression[] CreateExpressionsArray()
        {
            return _expressions.ToArray();
        }

        public static RegularExpression Concatenate(params RegularExpression[] expressions)
        {
            return expressions.Aggregate(Concatenate);
        }

        public static RegularExpression Concatenate(RegularExpression left, RegularExpression right)
        {
            return new Concatenation(left, right);
        }
    }
}
