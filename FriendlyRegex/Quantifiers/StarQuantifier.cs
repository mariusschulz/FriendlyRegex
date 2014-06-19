namespace FriendlyRegularExpressions.Quantifiers
{
    internal class StarQuantifier : QuantifiedRegularExpression
    {
        protected override string GreedyQuantifierSymbol
        {
            get { return "*"; }
        }

        private StarQuantifier(IRegularExpression expression, Greediness greediness = Greediness.Lazy)
            : base(expression, greediness)
        {
            // Nothing to do here
        }

        public static IRegularExpression GreedilyQuantify(IRegularExpression expression)
        {
            if (expression.IsEmpty)
            {
                return Epsilon.Instance;
            }

            return new StarQuantifier(expression, Greediness.Greedy);
        }

        public static IRegularExpression LazilyQuantify(IRegularExpression expression)
        {
            if (expression.IsEmpty)
            {
                return Epsilon.Instance;
            }

            return new StarQuantifier(expression);
        }
    }
}
