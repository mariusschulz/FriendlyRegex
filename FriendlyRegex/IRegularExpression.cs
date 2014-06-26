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
        Concatenation Maybe(char character);
        Concatenation Maybe(string literal);
        Concatenation Maybe(IRegularExpression expression);
        Concatenation MaybeAnything();
        IQuantifiableRegularExpression OneOf(params string[] literals);
        IQuantifiableRegularExpression OneOf(params IRegularExpression[] expressions);
        Concatenation MaybeOneOf(params string[] literals);
        Concatenation MaybeOneOf(params IRegularExpression[] expressions);
        IQuantifiableRegularExpression Pattern(string pattern);
        IQuantifiableRegularExpression AtomicPattern(string pattern);
        Concatenation ZeroOrMore(IRegularExpression expression);
        Concatenation OneOrMore(IRegularExpression expression);
        Concatenation Whitespace();
        Concatenation MaybeWhitespace();
        Concatenation Anything();
        IQuantifiableRegularExpression AnythingBut(params char[] blacklist);
        IQuantifiableRegularExpression AnythingBut(params Range[] blacklist);
        IQuantifiableRegularExpression FromRange(char from, char to);
        Concatenation StartOfLine();
        Concatenation EndOfLine();
        Concatenation After(IRegularExpression expression);
        Concatenation Before(IRegularExpression expression);
        Concatenation NotBefore(IRegularExpression expression);
        Concatenation NotAfter(IRegularExpression expression);
        Concatenation BeginCapture();
        Concatenation BeginCapture(string groupName);
        Concatenation EndCapture();
        ICapturedRegularExpression Capture(IRegularExpression expression);
        IQuantifiableRegularExpression ValueOfCapture(int groupIndex);
        IQuantifiableRegularExpression ValueOfCapture(string groupName);
    }
}
