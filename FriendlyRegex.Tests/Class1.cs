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
                .Then("http://")
                .Then("blog.")
                .Then("mariusschulz").Or("thomasbandt")
                .Then(".de").Or(".com");

            Console.WriteLine(expression);

            var regex = expression.ToRegex();
            var matches = regex.Matches("http://blog.mariusschulz.com");

            foreach (Match match in matches)
            {
                Console.WriteLine(match);
            }
        }
    }
}
