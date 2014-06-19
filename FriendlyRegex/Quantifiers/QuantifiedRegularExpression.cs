using FriendlyRegularExpressions.CharacterClasses;
using FriendlyRegularExpressions.Groups;

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
            return GroupingParenthesesCanBeOmitted(_expression)
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

        private static bool GroupingParenthesesCanBeOmitted(RegularExpression expression)
        {
            return ExpressionDoesNotRequireParentheses(expression)
                || ExpressionIsSingleCharacterLiteral(expression);
        }

        private static bool ExpressionDoesNotRequireParentheses(RegularExpression expression)
        {
            return expression is Dot
                || expression is GroupingConstruct
                || expression is NegatedCharacterClass
                || expression is ShorthandCharacterClass;
        }

        private static bool ExpressionIsSingleCharacterLiteral(RegularExpression expression)
        {
            var literal = expression as Literal;

            return literal != null
                && literal.LiteralPattern.Length == 1;
        }
    }
}