
namespace FriendlyRegex.Subexpressions
{
    internal abstract class Subexpression
    {
        public abstract string GetStringRepresentation();

        public override string ToString()
        {
            return GetStringRepresentation();
        }
    }
}
