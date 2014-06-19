namespace FriendlyRegularExpressions
{
    public interface ICapturedRegularExpression : IRegularExpression
    {
        RegularExpression As(string groupName);
    }
}
