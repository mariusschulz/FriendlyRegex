namespace FriendlyRegularExpressions.Quantifiers
{
    internal class QuestionMarkQuantifier : QuantifiedRegularExpression
    {
        protected override string GreedyQuantifierSymbol
        {
            get { return "?"; }
        }

        private QuestionMarkQuantifier(RegularExpression expression)
            : base(expression, Greediness.Greedy)
        {
            // Nothing to do here
        }

        public static RegularExpression GreedilyQuantify(RegularExpression expression)
        {
            return expression.IsEmpty
                ? Epsilon
                : new QuestionMarkQuantifier(expression);
        }
    }
}
