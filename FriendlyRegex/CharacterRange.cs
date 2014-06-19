using System.Text.RegularExpressions;

namespace FriendlyRegularExpressions
{
    public class CharacterRange
    {
        private readonly string _from;
        private readonly string _to;

        public CharacterRange(char from, char to)
        {
            if (from < to)
            {
                _from = Escape(from);
                _to = Escape(to);
            }
            else if (from == to)
            {
                _from = Escape(from);
            }
            else
            {
                _from = Escape(to);
                _to = Escape(from);
            }
        }

        private CharacterRange(char character)
        {
            _from = Escape(character);
        }

        private static string Escape(char character)
        {
            return Regex.Escape(character.ToString());
        }

        public override string ToString()
        {
            return _from + (string.IsNullOrEmpty(_to) ? string.Empty : "-" + _to);
        }

        public static implicit operator CharacterRange(char character)
        {
            return new CharacterRange(character);
        }
    }
}
