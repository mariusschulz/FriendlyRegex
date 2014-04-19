
namespace FriendlyRegularExpressions.Subexpressions.Quantifiers
{
    internal class StarQuantifier : QuantifiedSubexpression
    {
        public StarQuantifier(Subexpression expression)
            : base(expression)
        {
            // Nothing to do here
        }

        public override string GetStringRepresentation()
        {
            return WrapExpressionInParenthesesIfNecessary() + "*";
        }
    }
}
