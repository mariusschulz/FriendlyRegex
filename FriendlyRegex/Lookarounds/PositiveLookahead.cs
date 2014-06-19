namespace FriendlyRegularExpressions.Lookarounds
{
    internal class PositiveLookahead : RegularExpression
    {
        private readonly IRegularExpression _expression;

        private PositiveLookahead(IRegularExpression expression)
        {
            _expression = expression;
        }

        public override string GetStringRepresentation()
        {
            return "(?=" + _expression + ")";
        }

        public static IRegularExpression At(IRegularExpression expression)
        {
            if (expression.IsEmpty)
            {
                return Epsilon.Instance;
            }

            return new PositiveLookahead(expression);
        }
    }
}
