
namespace FriendlyRegularExpressions
{
    internal class Range : RegularExpression
    {
        private readonly RangeBoundary _from;
        public RangeBoundary From { get { return _from; } }

        private readonly RangeBoundary _to;
        public RangeBoundary To { get { return _to; } }

        public Range(RangeBoundary from, RangeBoundary to)
        {
            _from = from;
            _to = to;
        }

        public override string GetStringRepresentation()
        {
            return _from + "-" + _to;
        }
    }
}
