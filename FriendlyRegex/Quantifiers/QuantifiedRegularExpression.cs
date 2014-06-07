using FriendlyRegularExpressions.CharacterClasses;

namespace FriendlyRegularExpressions.Quantifiers
{
    internal abstract class QuantifiedRegularExpression : RegularExpression
    {
        private readonly RegularExpression _expression;
        private readonly Greediness _greediness;

        protected abstract string GreedyQuantifierSymbol { get; }

        protected QuantifiedRegularExpression(RegularExpression expression, Greediness greediness)
        {
            _expression = expression;
            _greediness = greediness;
        }

        protected string WrapExpressionInParenthesesIfNecessary()
        {
            return GroupingParenthesesCanBeOmitted()
                ? _expression.ToString()
                : "(?:" + _expression + ")";
        }

        public override string GetStringRepresentation()
        {
            string expression = WrapExpressionInParenthesesIfNecessary();
            string quantifiedExpression = expression + GreedyQuantifierSymbol;

            if (_greediness == Greediness.Lazy)
            {
                quantifiedExpression += "?";
            }

            return quantifiedExpression;
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