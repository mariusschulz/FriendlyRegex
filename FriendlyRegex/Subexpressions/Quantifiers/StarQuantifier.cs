
namespace FriendlyRegularExpressions.Subexpressions.Quantifiers
{
    internal class StarQuantifier : Subexpression
    {
        private readonly Subexpression _expression;
        public Subexpression Expression { get { return _expression; } }

        public StarQuantifier(Subexpression expression)
        {
            _expression = expression;
        }

        public override string GetStringRepresentation()
        {
            return "(?:" + _expression + ")*";
        }
    }
}
