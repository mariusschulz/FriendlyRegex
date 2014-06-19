namespace FriendlyRegularExpressions
{
    internal class Anchor : RegularExpression
    {
        public static readonly Anchor StartOfStringOrLine;
        public static readonly Anchor StartOfString;

        public static readonly Anchor EndOfStringOrLine;
        public static readonly Anchor EndOfString;
        public static readonly Anchor VeryEndOfString;

        public static readonly Anchor WordBoundary;
        public static readonly Anchor NonWordBoundary;
        public static readonly Anchor EndPositionOfPreviousMatch;

        private readonly string _symbol;

        private Anchor(string symbol)
        {
            _symbol = symbol;
        }

        static Anchor()
        {
            StartOfStringOrLine = new Anchor("^");
            StartOfString = new Anchor(@"\A");

            EndOfStringOrLine = new Anchor("$");
            EndOfString = new Anchor(@"\Z");
            VeryEndOfString = new Anchor(@"\z");

            WordBoundary = new Anchor(@"\b");
            NonWordBoundary = new Anchor(@"\B");

            EndPositionOfPreviousMatch = new Anchor(@"\G");
        }

        public override string GetStringRepresentation()
        {
            return _symbol;
        }
    }
}
