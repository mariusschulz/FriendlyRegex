namespace FriendlyRegularExpressions
{
    internal class Anchor : RegularExpression
    {
        public static readonly Anchor StartOfStringOrLine;
        public static readonly Anchor EndOfStringOrLine;

        public static readonly Anchor WordBoundary;
        public static readonly Anchor NonWordBoundary;

        private readonly string _symbol;

        private Anchor(string symbol)
        {
            _symbol = symbol;
        }

        static Anchor()
        {
            StartOfStringOrLine = new Anchor("^");
            EndOfStringOrLine = new Anchor("$");

            WordBoundary = new Anchor(@"\b");
            NonWordBoundary = new Anchor(@"\B");
        }

        public override string GetStringRepresentation()
        {
            return _symbol;
        }
    }
}
