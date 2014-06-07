namespace FriendlyRegularExpressions.Lookarounds
{
    internal class NegativeLookbehind : RegularExpression
    {
        private readonly RegularExpression _expression;

        private NegativeLookbehind(RegularExpression expression)
        {
            _expression = expression;
        }

        public override string GetStringRepresentation()
        {
            return "(?<!" + _expression + ")";
        }

        public static RegularExpression At(RegularExpression expression)
        {
            if (expression.IsEmpty)
            {
                return Epsilon.Instance;
            }

            return new NegativeLookbehind(expression);
        }
    }
}
