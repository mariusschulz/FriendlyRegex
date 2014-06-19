namespace FriendlyRegularExpressions
{
    public interface IQuantifiableRegularExpression : IRegularExpression
    {
        IRegularExpression AtLeast(int repetitions);
        IRegularExpression AtMost(int repetitions);
        IRegularExpression Exactly(int repetitions);
    }
}
