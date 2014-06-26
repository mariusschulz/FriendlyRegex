using FriendlyRegularExpressions.Extensions;

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
                if (MinEqualsMax())
                {
                    return "{" + _minRepetitions + "}";
                }

                return "{"
                    + _minRepetitions.ToStringOrEmpty()
                    + ","
                    + _minRepetitions.ToStringOrEmpty()
                    + "}";
            }
        }

        private bool MinEqualsMax()
        {
            return _minRepetitions.HasValue
                && _maxRepetitions.HasValue
                && _minRepetitions == _maxRepetitions;
        }

        public RangeQuantifier(IRegularExpression expression, int? minRepetions, int? maxRepetitions)
            : base(expression, Greediness.Greedy)
        {
            _minRepetitions = minRepetions;
            _maxRepetitions = maxRepetitions;
        }

        public static RangeQuantifier AtLeast(IRegularExpression expression, int repetitions)
        {
            return new RangeQuantifier(expression, repetitions, null);
        }

        public static RangeQuantifier AtMost(IRegularExpression expression, int repetitions)
        {
            return new RangeQuantifier(expression, null, repetitions);
        }

        public static RangeQuantifier Exactly(IRegularExpression expression, int repetitions)
        {
            return new RangeQuantifier(expression, repetitions, repetitions);
        }
    }
}
