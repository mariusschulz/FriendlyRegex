
namespace FriendlyRegularExpressions.Subexpressions.Quantifiers
{
    internal class QuestionMarkQuantifier : Subexpression
    {
        private readonly Subexpression _expression;
        public Subexpression Expression { get { return _expression; } }

        public QuestionMarkQuantifier(Subexpression expression)
        {
            _expression = expression;
        }

        public override string GetStringRepresentation()
        {
            return "(?:" + _expression + ")?";
        }
    }
}
