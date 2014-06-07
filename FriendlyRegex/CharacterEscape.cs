
namespace FriendlyRegularExpressions
{
    internal class CharacterEscape : RegularExpression
    {
        private readonly string _sequence;
        public string Sequence { get { return _sequence; } }

        public CharacterEscape(string sequence)
        {
            _sequence = sequence;
        }

        public override string GetStringRepresentation()
        {
            return _sequence;
        }
    }
}
