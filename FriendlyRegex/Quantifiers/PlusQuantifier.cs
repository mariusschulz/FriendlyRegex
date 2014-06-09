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

        public static RegularExpression GreedilyQuantify(RegularExpression expression)
        {
            return expression.IsEmpty
                ? Epsilon
                : new PlusQuantifier(expression, Greediness.Greedy);
        }

        public static RegularExpression LazilyQuantify(RegularExpression expression)
        {
            return expression.IsEmpty
                ? Epsilon
                : new PlusQuantifier(expression);
        }
    }
}
