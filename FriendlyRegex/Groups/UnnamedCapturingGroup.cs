namespace FriendlyRegularExpressions.Groups
{
    public class UnnamedCapturingGroup : RegularExpression
    {
        private readonly RegularExpression _expression;

        public UnnamedCapturingGroup(RegularExpression expression)
        {
            _expression = expression;
        }

        public override string GetStringRepresentation()
        {
            return "(" + _expression + ")";
        }

        public RegularExpression As(string groupName)
        {
            return new NamedCapturingGroup(_expression, groupName);
        }
    }
}
