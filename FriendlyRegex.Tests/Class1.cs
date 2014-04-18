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
                .Then("hi")
                .EndOfLine();

            Console.WriteLine(expression);
        }
    }
}
