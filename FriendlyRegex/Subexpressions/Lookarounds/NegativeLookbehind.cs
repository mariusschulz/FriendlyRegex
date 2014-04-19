
namespace FriendlyRegularExpressions.Subexpressions.Lookarounds
{
    internal class NegativeLookbehind : Subexpression
    {
        private readonly Subexpression _expression;
        public Subexpression Expression { get { return _expression; } }

        public NegativeLookbehind(Subexpression expression)
        {
            _expression = expression;
        }

        public override string GetStringRepresentation()
        {
            return "(?<!" + _expression + ")";
        }
    }
}
