namespace FriendlyRegularExpressions.Quantifiers
{
    internal class PlusQuantifier : QuantifiedRegularExpression
    {
        protected override string GreedyQuantifierSymbol
        {
            get { return "+"; }
        }

        private PlusQuantifier(RegularExpression expression)
            : base(expression, Greediness.Greedy)
        {
            // Nothing to do here
        }

        public static RegularExpression GreedilyQuantify(RegularExpression expression)
        {
            return expression.IsEmpty
                ? Epsilon
                : new PlusQuantifier(expression);
        }
    }
}
