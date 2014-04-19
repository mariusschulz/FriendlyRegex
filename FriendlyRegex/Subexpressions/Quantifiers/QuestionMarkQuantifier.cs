
namespace FriendlyRegularExpressions.Subexpressions.Quantifiers
{
    internal class QuestionMarkQuantifier : QuantifiedSubexpression
    {
        public QuestionMarkQuantifier(Subexpression expression)
            : base(expression)
        {
            // Nothing to do here
        }

        public override string GetStringRepresentation()
        {
            return WrapExpressionInParenthesesIfNecessary() + "?";
        }
    }
}
