namespace FriendlyRegularExpressions.Lookarounds
{
    internal class NegativeLookbehind : RegularExpression
    {
        private readonly IRegularExpression _expression;

        private NegativeLookbehind(IRegularExpression expression)
        {
            _expression = expression;
        }

        public override string GetStringRepresentation()
        {
            return "(?<!" + _expression + ")";
        }

        public static IRegularExpression At(IRegularExpression expression)
        {
            if (expression.IsEmpty)
            {
                return Epsilon.Instance;
            }

            return new NegativeLookbehind(expression);
        }
    }
}
