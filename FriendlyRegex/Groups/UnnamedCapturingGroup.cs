namespace FriendlyRegularExpressions.Groups
{
    public class UnnamedCapturingGroup : GroupingConstruct
    {
        private readonly IRegularExpression _expression;

        public UnnamedCapturingGroup(IRegularExpression expression)
        {
            _expression = expression;
        }

        public override string GetStringRepresentation()
        {
            return "(" + _expression + ")";
        }

        public IRegularExpression As(string groupName)
        {
            return new NamedCapturingGroup(_expression, groupName);
        }
    }
}
