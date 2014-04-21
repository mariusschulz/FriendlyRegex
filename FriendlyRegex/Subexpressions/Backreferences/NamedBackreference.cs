
namespace FriendlyRegularExpressions.Subexpressions.Backreferences
{
    internal class NamedBackreference : Subexpression
    {
        private readonly string _captureGroupName;
        public string CaptureGroupName { get { return _captureGroupName; } }

        public NamedBackreference(string captureGroupName)
        {
            _captureGroupName = captureGroupName;
        }

        public override string GetStringRepresentation()
        {
            return @"\k<" + _captureGroupName + ">";
        }
    }
}
