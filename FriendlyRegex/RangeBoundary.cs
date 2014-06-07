using System.Globalization;

namespace FriendlyRegularExpressions
{
    internal class RangeBoundary
    {
        private readonly string _symbol;
        public string Symbol { get { return _symbol; } }

        private RangeBoundary(string symbol)
        {
            _symbol = symbol;
        }

        public static RangeBoundary FromCharacter(char character)
        {
            return new RangeBoundary(character.ToString(CultureInfo.InvariantCulture));
        }

        public override string ToString()
        {
            return _symbol;
        }
    }
}
