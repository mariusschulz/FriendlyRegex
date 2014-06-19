namespace FriendlyRegularExpressions.Lookarounds
{
    internal class NegativeLookahead : RegularExpression
    {
        private readonly RegularExpression _expression;

        private NegativeLookahead(RegularExpression expression)
        {
            _expression = expression;
        }

        public override string GetStringRepresentation()
        {
            return "(?!" + _expression + ")";
        }

        public static RegularExpression At(RegularExpression expression)
        {
            if (expression.IsEmpty)
            {
                return Epsilon.Instance;
            }

            return new NegativeLookahead(expression);
        }
    }
}
