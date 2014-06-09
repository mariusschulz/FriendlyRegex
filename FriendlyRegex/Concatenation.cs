using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace FriendlyRegularExpressions
{
    class Concatenation : RegularExpression
    {
        private readonly IEnumerable<RegularExpression> _expressions;

        private Concatenation(RegularExpression left, RegularExpression right)
        {
            _expressions = new[] { left, right };
        }

        private Concatenation(IEnumerable<RegularExpression> expressions)
        {
            _expressions = expressions;
        }

        public override string GetStringRepresentation()
        {
            return string.Join(string.Empty, _expressions);
        }

        public override string Hierarchy
        {
            get
            {
                return "Concatenation["
                    + string.Join(string.Empty, _expressions.Select(x => x.Hierarchy))
                    + "]";
            }
        }

        public static RegularExpression Concatenate(params RegularExpression[] expressions)
        {
            return expressions.Aggregate(Concatenate);
        }

        public static RegularExpression Concatenate(RegularExpression left, RegularExpression right)
        {
            bool leftIsEmpty = string.IsNullOrEmpty(left.ToString());
            bool rightIsEmpty = string.IsNullOrEmpty(right.ToString());

            if (leftIsEmpty && rightIsEmpty)
            {
                return Epsilon;
            }

            if (leftIsEmpty)
            {
                return right;
            }

            if (rightIsEmpty)
            {
                return left;
            }

            return MergeIfPossible(left, right);
        }

        private static RegularExpression MergeIfPossible(RegularExpression left, RegularExpression right)
        {
            Concatenation leftConcatenation = left as Concatenation;
            Concatenation rightConcatenation = right as Concatenation;

            if (leftConcatenation != null && rightConcatenation != null)
            {
                var combinedExpressions = leftConcatenation._expressions
                    .Concat(rightConcatenation._expressions);

                return new Concatenation(combinedExpressions);
            }

            if (leftConcatenation != null)
            {
                var combinedExpressions = leftConcatenation._expressions
                    .Concat(new[] { right });

                return new Concatenation(combinedExpressions);
            }

            if (rightConcatenation != null)
            {
                var combinedExpressions = rightConcatenation._expressions
                    .Concat(new[] { left });

                return new Concatenation(combinedExpressions);
            }

            return new Concatenation(left, right);
        }
    }
}
