using System;
using System.Text.RegularExpressions;
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
                .Then(One.WordBoundary)
                .BeginCapture()
                    .Then(Multiple.WordCharacters)
                .EndCapture()
                .Then(One.WordBoundary)
                .Then(Multiple.NonWordCharacters)
                .Then(One.WordBoundary)
                .ThenValueOfCapture(1)
                .Then(One.WordBoundary);

            var regex = expression.ToRegex();

            Console.WriteLine(expression);
            var matches = regex.Matches("This is is a text text containing some some some repeated words.");

            foreach (Match match in matches)
            {
                Console.WriteLine(match);
            }
        }
    }
}
