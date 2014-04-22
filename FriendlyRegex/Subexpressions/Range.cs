
namespace FriendlyRegularExpressions.Subexpressions
{
    internal class Range : Subexpression
    {
        private readonly string _from;
        public string From { get { return _from; } }

        private readonly string _to;
        public string To { get { return _to; } }

        public Range(string from, string to)
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
