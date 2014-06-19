namespace FriendlyRegularExpressions
{
    public interface IQuantifiableRegularExpression : IRegularExpression
    {
        IRegularExpression AtLeast(int repetitions);
    }
}
