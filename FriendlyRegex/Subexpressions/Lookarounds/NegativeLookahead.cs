
namespace FriendlyRegularExpressions.Subexpressions.Lookarounds
{
    internal class NegativeLookahead : Subexpression
    {
        private readonly Subexpression _expression;
        public Subexpression Expression { get { return _expression; } }

        public NegativeLookahead(Subexpression expression)
        {
            _expression = expression;
        }

        public override string GetStringRepresentation()
        {
            return "(?!" + _expression + ")";
        }
    }
}
