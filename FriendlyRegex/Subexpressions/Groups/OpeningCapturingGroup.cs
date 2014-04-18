
namespace FriendlyRegularExpressions.Subexpressions.Groups
{
    internal class OpeningCapturingGroup : Subexpression
    {
        private readonly bool _isNamed;

        private readonly string _name;
        public string Name { get { return _name; } }

        public OpeningCapturingGroup()
        {
            _isNamed = false;
        }

        public OpeningCapturingGroup(string name)
        {
            _name = name;
            _isNamed = true;
        }

        public override string GetStringRepresentation()
        {
            return _isNamed
                ? "(?<" + _name + ">"
                : "(";
        }
    }
}
