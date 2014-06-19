namespace FriendlyRegularExpressions.Quantifiers
{
    internal class PlusQuantifier : QuantifiedRegularExpression
    {
        protected override string GreedyQuantifierSymbol
        {
            get { return "+"; }
        }

        private PlusQuantifier(IRegularExpression expression, Greediness greediness = Greediness.Lazy)
            : base(expression, greediness)
        {
            // Nothing to do here
        }

        public static QuantifiedRegularExpression GreedilyQuantify(IRegularExpression expression)
        {
            if (expression.IsEmpty)
            {
                return EpsilonRepetition.Instance;
            }

            return new PlusQuantifier(expression, Greediness.Greedy);
        }

        public static QuantifiedRegularExpression LazilyQuantify(IRegularExpression expression)
        {
            if (expression.IsEmpty)
            {
                return EpsilonRepetition.Instance;
            }

            return new PlusQuantifier(expression);
        }
    }
}
