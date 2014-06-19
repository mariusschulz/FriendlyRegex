namespace FriendlyRegularExpressions.Groups
{
    public class NamedCapturingGroup : GroupingConstruct
    {
        private readonly IRegularExpression _expression;
        private readonly string _groupName;

        public NamedCapturingGroup(IRegularExpression expression, string groupName)
        {
            _expression = expression;
            _groupName = groupName;
        }

        public override string GetStringRepresentation()
        {
            return "(?<" + _groupName + ">" + _expression + ")";
        }
    }
}
