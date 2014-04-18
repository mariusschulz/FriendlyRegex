﻿
namespace FriendlyRegularExpressions.Subexpressions
{
    internal class Literal : Subexpression
    {
        private readonly string _pattern;
        public string Pattern { get { return _pattern; } }

        public Literal(string pattern)
        {
            _pattern = pattern;
        }

        public override string GetStringRepresentation()
        {
            return _pattern;
        }
    }
}