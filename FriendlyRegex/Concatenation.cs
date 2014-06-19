using System.Collections.Generic;
using System.Linq;
using FriendlyRegularExpressions.Quantifiers;

namespace FriendlyRegularExpressions
{
    public class Concatenation : RegularExpression, IQuantifiableRegularExpression
    {
        private readonly IEnumerable<IRegularExpression> _expressions;

        private Concatenation(IRegularExpression left, IRegularExpression right)
            : this(new[] { left, right })
        {
            // Nothing to do here
        }

        private Concatenation(IEnumerable<IRegularExpression> expressions)
        {
            _expressions = expressions;
        }

        public override string GetStringRepresentation()
        {
            return _expressions.StringJoin();
        }

        public IRegularExpression[] CreateExpressionsArray()
        {
            return _expressions.ToArray();
        }

        public static Concatenation Concatenate(params IRegularExpression[] expressions)
        {
            return new Concatenation(expressions);
        }

        public static Concatenation Concatenate(IRegularExpression left, IRegularExpression right)
        {
            return new Concatenation(left, right);
        }

        IRegularExpression IQuantifiableRegularExpression.AtLeast(int repetitions)
        {
            return RangeQuantifier.AtLeast(this, repetitions);
        }
    }
}
