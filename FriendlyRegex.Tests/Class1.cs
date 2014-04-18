using System;
using NUnit.Framework;

namespace FriendlyRegularExpressions.Tests
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void FluentSyntax()
        {
            var expression = new FriendlyRegex()
                .StartOfLine()
                .Then(One.Digit)
                .Then(One.WordCharacter)
                .EndOfLine();

            Console.WriteLine(expression);
        }
    }
}
