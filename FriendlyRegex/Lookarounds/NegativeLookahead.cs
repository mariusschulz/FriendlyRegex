namespace FriendlyRegularExpressions.Lookarounds
{
    internal class NegativeLookahead : RegularExpression
    {
        private readonly IRegularExpression _expression;

        private NegativeLookahead(IRegularExpression expression)
        {
            _expression = expression;
        }

        public override string GetStringRepresentation()
        {
            return "(?!" + _expression + ")";
        }

        public static IRegularExpression At(IRegularExpression expression)
        {
            if (expression.IsEmpty)
            {
                return Epsilon.Instance;
            }

            return new NegativeLookahead(expression);
        }
    }
}
