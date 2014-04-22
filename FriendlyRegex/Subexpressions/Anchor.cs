
namespace FriendlyRegularExpressions.Subexpressions
{
    internal class Anchor : Subexpression
    {
        private readonly string _symbol;
        public string Symbol { get { return _symbol; } }

        public Anchor(string symbol)
        {
            _symbol = symbol;
        }

        public override string GetStringRepresentation()
        {
            return _symbol;
        }
    }
}
