namespace FriendlyRegularExpressions.Quantifiers
{
    internal class PlusQuantifier : QuantifiedRegularExpression
    {
        protected override string GreedyQuantifierSymbol
        {
            get { return "+"; }
        }

        private PlusQuantifier(RegularExpression expression, Greediness greediness = Greediness.Lazy)
            : base(expression, greediness)
        {
            // Nothing to do here
        }

        public static QuantifiedRegularExpression GreedilyQuantify(RegularExpression expression)
        {
            if (expression.IsEmpty)
            {
                return EpsilonRepetition.Instance;
            }

            return new PlusQuantifier(expression, Greediness.Greedy);
        }

        public static QuantifiedRegularExpression LazilyQuantify(RegularExpression expression)
        {
            if (expression.IsEmpty)
            {
                return EpsilonRepetition.Instance;
            }

            return new PlusQuantifier(expression);
        }
    }
}
