
namespace FriendlyRegularExpressions.Subexpressions.Quantifiers
{
    internal class PlusQuantifier : QuantifiedSubexpression
    {
        public PlusQuantifier(Subexpression expression)
            : base(expression)
        {
            // Nothing to do here
        }

        public override string GetStringRepresentation()
        {
            return WrapExpressionInParenthesesIfNecessary() + "+";
        }
    }
}
