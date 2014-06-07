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
            string[] subdomains = { "www", "blog", "speaking" };

            var http = RegularExpression.New()
                .Then("http")
                .ThenOptionally("s")
                .Then("://");

            var domain = RegularExpression.New()
                .ThenOneOf(subdomains)
                .Then('.')
                .ThenPattern(@"[^.]+")
                .Then('.')
                .ThenOptionally(OneOrMore.NonDigits)
                .ThenOneOf("de", "com")
                .ThenOptionally('/');

            var httpUrl = RegularExpression.New()
                .After('[')
                .ThenOptionalWhitespace()
                .Then(http)
                .Then(domain)
                .ThenOptionalWhitespace()
                .Before(']');

            Console.WriteLine(httpUrl.ToString());

            var regex = httpUrl.ToRegex();
            var matches = regex.Matches("Find my blog under [http://blog.mariusschulz.com]");

            foreach (Match match in matches)
            {
                Console.WriteLine(match);
            }
        }
    }
}
