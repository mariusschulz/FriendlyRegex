
namespace FriendlyRegularExpressions.Subexpressions.Lookarounds
{
    internal class PositiveLookahead : Subexpression
    {
        private readonly Subexpression _expression;
        public Subexpression Expression { get { return _expression; } }

        public PositiveLookahead(Subexpression expression)
        {
            _expression = expression;
        }

        public override string GetStringRepresentation()
        {
            return "(?=" + _expression + ")";
        }
    }
}
