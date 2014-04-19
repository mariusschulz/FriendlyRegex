
namespace FriendlyRegularExpressions.Subexpressions.Lookarounds
{
    internal class PositiveLookbehind : Subexpression
    {
        private readonly Subexpression _expression;
        public Subexpression Expression { get { return _expression; } }

        public PositiveLookbehind(Subexpression expression)
        {
            _expression = expression;
        }

        public override string GetStringRepresentation()
        {
            return "(?<=" + _expression + ")";
        }
    }
}
