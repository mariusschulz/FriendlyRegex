namespace FriendlyRegularExpressions.Quantifiers
{
    internal class StarQuantifier : QuantifiedRegularExpression
    {
        protected override string GreedyQuantifierSymbol
        {
            get { return "*"; }
        }

        private StarQuantifier(RegularExpression expression, Greediness greediness = Greediness.Lazy)
            : base(expression, greediness)
        {
            // Nothing to do here
        }

        public static RegularExpression GreedilyQuantify(RegularExpression expression)
        {
            if (expression.IsEmpty)
            {
                return Epsilon.Instance;
            }

            return new StarQuantifier(expression, Greediness.Greedy);
        }

        public static RegularExpression LazilyQuantify(RegularExpression expression)
        {
            if (expression.IsEmpty)
            {
                return Epsilon.Instance;
            }

            return new StarQuantifier(expression);
        }
    }
}
