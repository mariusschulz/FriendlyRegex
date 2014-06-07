namespace FriendlyRegularExpressions.Quantifiers
{
    internal class QuestionMarkQuantifier : QuantifiedRegularExpression
    {
        private QuestionMarkQuantifier(RegularExpression expression)
            : base(expression)
        {
            // Nothing to do here
        }

        public override string GetStringRepresentation()
        {
            return WrapExpressionInParenthesesIfNecessary() + "?";
        }

        public static RegularExpression Quantify(RegularExpression expression)
        {
            if (string.IsNullOrEmpty(expression.ToString()))
            {
                return Epsilon.Instance;
            }

            return new QuestionMarkQuantifier(expression);
        }
    }
}
