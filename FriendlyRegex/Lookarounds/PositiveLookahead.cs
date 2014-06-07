namespace FriendlyRegularExpressions.Lookarounds
{
    internal class PositiveLookahead : RegularExpression
    {
        private readonly RegularExpression _expression;

        private PositiveLookahead(RegularExpression expression)
        {
            _expression = expression;
        }

        public override string GetStringRepresentation()
        {
            return "(?=" + _expression + ")";
        }

        public static RegularExpression At(RegularExpression expression)
        {
            if (expression.IsEmpty)
            {
                return Epsilon;
            }

            return new PositiveLookahead(expression);
        }
    }
}
