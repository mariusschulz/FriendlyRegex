using FriendlyRegularExpressions.CharacterClasses;

namespace FriendlyRegularExpressions.Quantifiers
{
    internal abstract class QuantifiedRegularExpression : RegularExpression
    {
        private readonly RegularExpression _expression;
        public RegularExpression Expression { get { return _expression; } }

        protected QuantifiedRegularExpression(RegularExpression expression)
        {
            _expression = expression;
        }

        protected string WrapExpressionInParenthesesIfNecessary()
        {
            return GroupingParenthesesCanBeOmitted()
                ? Expression.ToString()
                : "(?:" + Expression + ")";
        }

        private bool GroupingParenthesesCanBeOmitted()
        {
            if (_expression is Dot || _expression is ShorthandCharacterClass)
            {
                return true;
            }

            var literal = _expression as Literal;

            if (literal != null && literal.LiteralPattern.Length == 1)
            {
                return true;
            }

            return false;
        }
    }
}