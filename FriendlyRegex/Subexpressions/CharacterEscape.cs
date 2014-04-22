
namespace FriendlyRegularExpressions.Subexpressions
{
    internal class CharacterEscape : Subexpression
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
