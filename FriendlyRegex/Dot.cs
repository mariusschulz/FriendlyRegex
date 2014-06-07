namespace FriendlyRegularExpressions
{
    internal class Dot : RegularExpression
    {
        public static readonly Dot Instance;

        private Dot()
        {
            
        }

        static Dot()
        {
            Instance = new Dot();
        }

        public override string GetStringRepresentation()
        {
            return ".";
        }
    }
}
