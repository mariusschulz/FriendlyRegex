using FriendlyRegularExpressions.Quantifiers;

namespace FriendlyRegularExpressions
{
    internal class EpsilonRepetition : QuantifiedRegularExpression
    {
        public static EpsilonRepetition Instance;

        static EpsilonRepetition()
        {
            Instance = new EpsilonRepetition();
        }

        public EpsilonRepetition(RegularExpression expression, Greediness greediness)
            : base(expression, greediness)
        {

        }

        private EpsilonRepetition()
            : base(Epsilon.Instance, Greediness.Lazy)
        {

        }

        protected override string GreedyQuantifierSymbol
        {
            get { return string.Empty; }
        }

        public override string GetStringRepresentation()
        {
            return string.Empty;
        }
    }
}
