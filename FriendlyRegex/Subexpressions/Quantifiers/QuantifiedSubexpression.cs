using System.Text.RegularExpressions;
using FriendlyRegularExpressions.Subexpressions.CharacterClasses;

namespace FriendlyRegularExpressions.Subexpressions.Quantifiers
{
    internal abstract class QuantifiedSubexpression : Subexpression
    {
        private readonly Subexpression _expression;
        public Subexpression Expression { get { return _expression; } }

        protected QuantifiedSubexpression(Subexpression expression)
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

            if (literal != null && Regex.Unescape(literal.Pattern).Length == 1)
            {
                return true;
            }

            return false;
        }
    }
}