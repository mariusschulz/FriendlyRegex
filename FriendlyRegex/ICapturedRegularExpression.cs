namespace FriendlyRegularExpressions
{
    public interface ICapturedRegularExpression : IRegularExpression
    {
        IRegularExpression As(string groupName);
    }
}
