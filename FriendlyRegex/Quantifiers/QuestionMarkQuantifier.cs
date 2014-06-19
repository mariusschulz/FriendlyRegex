namespace FriendlyRegularExpressions.Quantifiers
{
    internal class QuestionMarkQuantifier : QuantifiedRegularExpression
    {
        protected override string GreedyQuantifierSymbol
        {
            get { return "?"; }
        }

        private QuestionMarkQuantifier(IRegularExpression expression)
            : base(expression, Greediness.Greedy)
        {
            // Nothing to do here
        }

        public static IRegularExpression GreedilyQuantify(IRegularExpression expression)
        {
            if (expression.IsEmpty)
            {
                return Epsilon.Instance;
            }

            return new QuestionMarkQuantifier(expression);
        }
    }
}
