
namespace FriendlyRegularExpressions.Subexpressions.Backreferences
{
    internal class NumberedBackreference : Subexpression
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
