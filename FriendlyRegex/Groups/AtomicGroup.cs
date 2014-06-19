namespace FriendlyRegularExpressions.Groups
{
    public class AtomicGroup : RegularExpression
    {
        private readonly RegularExpression _expression;

        public AtomicGroup(RegularExpression expression)
        {
            _expression = expression;
        }

        public override string GetStringRepresentation()
        {
            return "(?>" + _expression + ")";
        }
    }
}
