namespace FriendlyRegularExpressions.Quantifiers
{
    internal class RangeQuantifier : QuantifiedRegularExpression
    {
        private readonly int? _minRepetitions;
        private readonly int? _maxRepetitions;

        protected override string GreedyQuantifierSymbol
        {
            get
            {
                return "{"
                    + (_minRepetitions.HasValue ? _minRepetitions.ToString() : string.Empty)
                    + ","
                    + (_maxRepetitions.HasValue ? _maxRepetitions.ToString() : string.Empty)
                    + "}";
            }
        }

        public RangeQuantifier(RegularExpression expression, int? minRepetions, int? maxRepetitions)
            : base(expression, Greediness.Greedy)
        {
            _minRepetitions = minRepetions;
            _maxRepetitions = maxRepetitions;
        }

        public static RangeQuantifier AtLeast(RegularExpression expression, int repetitions)
        {
            return new RangeQuantifier(expression, repetitions, null);
        }
    }
}
