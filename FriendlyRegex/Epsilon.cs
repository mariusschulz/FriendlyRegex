namespace FriendlyRegularExpressions
{
    public class Epsilon : RegularExpression
    {
        public static readonly Epsilon Instance;

        private Epsilon()
        {
            
        }

        static Epsilon()
        {
            Instance = new Epsilon();
        }

        public override string GetStringRepresentation()
        {
            return string.Empty;
        }
    }
}
