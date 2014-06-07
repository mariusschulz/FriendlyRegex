

namespace FriendlyRegularExpressions.Backreferences
{
    internal class NumberedBackreference : RegularExpression
    {
        private readonly int _groupIndex;
        public int GroupIndex { get { return _groupIndex; } }

        public NumberedBackreference(int groupIndex)
        {
            _groupIndex = groupIndex;
        }

        public override string GetStringRepresentation()
        {
            return @"\" + _groupIndex;
        }
    }
}
