namespace FriendlyRegularExpressions.Lookarounds
{
    internal class PositiveLookbehind : RegularExpression
    {
        private readonly RegularExpression _expression;

        private PositiveLookbehind(RegularExpression expression)
        {
            _expression = expression;
        }

        public override string GetStringRepresentation()
        {
            return "(?<=" + _expression + ")";
        }

        public static RegularExpression At(RegularExpression expression)
        {
            if (expression.IsEmpty)
            {
                return Epsilon;
            }

            return new PositiveLookbehind(expression);
        }
    }
}
