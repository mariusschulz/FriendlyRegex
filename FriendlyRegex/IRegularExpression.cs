using System.Text.RegularExpressions;

namespace FriendlyRegularExpressions
{
    public interface IRegularExpression
    {
        string GetStringRepresentation();
        bool IsEmpty { get; }
        string ToString();
        Regex ToRegex();

        RegularExpression Then(RegularExpression expression);
        RegularExpression ThenOptionally(RegularExpression expression);
        RegularExpression ThenOptionallyAnything();
        RegularExpression ThenOneOf(params string[] literals);
        RegularExpression ThenOneOf(params RegularExpression[] expressions);
        RegularExpression ThenOptionallyOneOf(params string[] literals);
        RegularExpression ThenOptionallyOneOf(params RegularExpression[] expressions);
        RegularExpression ThenPattern(string pattern);
        RegularExpression ThenAtomicPattern(string pattern);
        RegularExpression ThenZeroOrMore(RegularExpression expression);
        RegularExpression ThenOneOrMore(RegularExpression expression);
        RegularExpression ThenWhitespace();
        RegularExpression ThenOptionalWhitespace();
        RegularExpression ThenAnything();
        RegularExpression ThenAnythingBut(params char[] blacklist);
        RegularExpression ThenAnythingBut(params Range[] blacklist);
        RegularExpression StartOfLine();
        RegularExpression EndOfLine();
        RegularExpression After(RegularExpression expression);
        RegularExpression Before(RegularExpression expression);
        RegularExpression NotBefore(RegularExpression expression);
        RegularExpression NotAfter(RegularExpression expression);
        RegularExpression BeginCapture();
        RegularExpression BeginCapture(string groupName);
        RegularExpression EndCapture();
        ICapturedRegularExpression ThenCapture(RegularExpression expression);
        RegularExpression ThenValueOfCapture(int groupIndex);
        RegularExpression ThenValueOfCapture(string groupName);
    }
}
