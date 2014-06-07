

namespace FriendlyRegularExpressions.Backreferences
{
    internal class NamedBackreference : RegularExpression
    {
        private readonly string _groupName;
        public string GroupName { get { return _groupName; } }

        public NamedBackreference(string groupName)
        {
            _groupName = groupName;
        }

        public override string GetStringRepresentation()
        {
            return @"\k<" + _groupName + ">";
        }
    }
}
