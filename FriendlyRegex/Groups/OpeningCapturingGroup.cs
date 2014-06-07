

namespace FriendlyRegularExpressions.Groups
{
    internal class OpeningCapturingGroup : RegularExpression
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
