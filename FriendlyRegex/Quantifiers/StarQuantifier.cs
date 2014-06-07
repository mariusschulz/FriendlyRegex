namespace FriendlyRegularExpressions.Quantifiers
{
    internal class StarQuantifier : QuantifiedRegularExpression
    {
        private StarQuantifier(RegularExpression expression)
            : base(expression)
        {
            // Nothing to do here
        }

        public override string GetStringRepresentation()
        {
            return WrapExpressionInParenthesesIfNecessary() + "*";
        }

        public static RegularExpression Quantify(RegularExpression expression)
        {
            if (string.IsNullOrEmpty(expression.ToString()))
            {
                return Epsilon.Instance;
            }

            return new StarQuantifier(expression);
        }
    }
}
