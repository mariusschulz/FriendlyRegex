using System.Text.RegularExpressions;

namespace FriendlyRegularExpressions
{
    public class Range
    {
        private readonly string _from;
        private readonly string _to;

        private Range(char from, char to)
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

        private Range(char character)
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

        public static implicit operator Range(char character)
        {
            return new Range(character);
        }

        public static Range Between(char from, char to)
        {
            return new Range(from, to);
        }

        public static Range FromSingle(char character)
        {
            return new Range(character);
        }
    }
}
