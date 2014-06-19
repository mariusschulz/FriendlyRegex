using System.Text.RegularExpressions;

namespace FriendlyRegularExpressions
{
    public interface IRegularExpression
    {
        string GetStringRepresentation();
        bool IsEmpty { get; }
        string ToString();
        Regex ToRegex();

        IQuantifiableRegularExpression Then(char character);
        IQuantifiableRegularExpression Then(string literal);
        IQuantifiableRegularExpression Then(IRegularExpression expression);
        Concatenation ThenOptionally(char character);
        Concatenation ThenOptionally(string literal);
        Concatenation ThenOptionally(IRegularExpression expression);
        Concatenation ThenOptionallyAnything();
        IQuantifiableRegularExpression ThenOneOf(params string[] literals);
        IQuantifiableRegularExpression ThenOneOf(params IRegularExpression[] expressions);
        Concatenation ThenOptionallyOneOf(params string[] literals);
        Concatenation ThenOptionallyOneOf(params IRegularExpression[] expressions);
        IQuantifiableRegularExpression ThenPattern(string pattern);
        IQuantifiableRegularExpression ThenAtomicPattern(string pattern);
        Concatenation ThenZeroOrMore(IRegularExpression expression);
        Concatenation ThenOneOrMore(IRegularExpression expression);
        Concatenation ThenWhitespace();
        Concatenation ThenOptionalWhitespace();
        Concatenation ThenAnything();
        IQuantifiableRegularExpression ThenAnythingBut(params char[] blacklist);
        IQuantifiableRegularExpression ThenAnythingBut(params Range[] blacklist);
        IQuantifiableRegularExpression ThenFromRange(char from, char to);
        Concatenation StartOfLine();
        Concatenation EndOfLine();
        Concatenation After(IRegularExpression expression);
        Concatenation Before(IRegularExpression expression);
        Concatenation NotBefore(IRegularExpression expression);
        Concatenation NotAfter(IRegularExpression expression);
        Concatenation BeginCapture();
        Concatenation BeginCapture(string groupName);
        Concatenation EndCapture();
        ICapturedRegularExpression ThenCapture(IRegularExpression expression);
        IQuantifiableRegularExpression ThenValueOfCapture(int groupIndex);
        IQuantifiableRegularExpression ThenValueOfCapture(string groupName);
    }
}
