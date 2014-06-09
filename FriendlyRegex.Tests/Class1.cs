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
                .Then('[')
                .ThenOptionalWhitespace()
                .Then(http)
                .Then(domain)
                .ThenOptionalWhitespace()
                .Then(']');

            var markdownLink = httpUrl
                .Then('(')
                .ThenNamedCapture("value", OneOrMore.ArbitraryCharacters)
                .Then(')');

            Console.WriteLine(markdownLink.ToString());

            var regex = markdownLink.ToRegex();
            var matches = regex.Matches("Find my blog under [http://blog.mariusschulz.com](this page)");

            foreach (Match match in matches)
            {
                Console.WriteLine();
                Console.WriteLine(match);

                foreach (Group group in match.Groups)
                {
                    Console.WriteLine("   - {0}", group.Value);
                }
            }
        }
    }
}
