
namespace FriendlyRegularExpressions.Subexpressions
{
    public abstract class Subexpression
    {
        public abstract string GetStringRepresentation();

        public override string ToString()
        {
            return GetStringRepresentation();
        }

        public static implicit operator Subexpression(string literal)
        {
            return new Literal(literal);
        }
    }
}
