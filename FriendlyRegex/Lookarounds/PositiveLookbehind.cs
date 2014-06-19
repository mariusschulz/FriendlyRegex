namespace FriendlyRegularExpressions.Lookarounds
{
    internal class PositiveLookbehind : RegularExpression
    {
        private readonly IRegularExpression _expression;

        private PositiveLookbehind(IRegularExpression expression)
        {
            _expression = expression;
        }

        public override string GetStringRepresentation()
        {
            return "(?<=" + _expression + ")";
        }

        public static RegularExpression At(IRegularExpression expression)
        {
            if (expression.IsEmpty)
            {
                return Epsilon.Instance;
            }

            return new PositiveLookbehind(expression);
        }
    }
}
