
namespace FriendlyRegularExpressions.Subexpressions.Quantifiers
{
    internal class PlusQuantifier : Subexpression
    {
        private readonly Subexpression _expression;
        public Subexpression Expression { get { return _expression; } }

        public PlusQuantifier(Subexpression expression)
        {
            _expression = expression;
        }

        public override string GetStringRepresentation()
        {
            return "(?:" + _expression + ")+";
        }
    }
}
