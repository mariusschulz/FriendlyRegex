using System.Collections.Generic;

namespace FriendlyRegularExpressions.Subexpressions
{
    internal class Alternation : Subexpression
    {
        private readonly IEnumerable<Subexpression> _alternatives;
        public IEnumerable<Subexpression> Alternatives { get { return _alternatives; } }

        public Alternation(IEnumerable<Subexpression> alternatives)
        {
            _alternatives = alternatives;
        }

        public override string GetStringRepresentation()
        {
            return "(?:" + string.Join("|", _alternatives) + ")";
        }
    }
}
