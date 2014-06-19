namespace FriendlyRegularExpressions.Groups
{
    public class NamedCapturingGroup : RegularExpression
    {
        private readonly RegularExpression _expression;
        private readonly string _groupName;

        public NamedCapturingGroup(RegularExpression expression, string groupName)
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
