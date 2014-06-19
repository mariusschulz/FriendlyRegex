using System;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace FriendlyRegularExpressions.Tests
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void RepeatedWords()
        {
            var repeatedWords = RegularExpression.New()
                .Then(" ")
                .ThenCapture(One.Word).As("word")
                .ThenWhitespace()
                .ThenValueOfCapture("word");

            OutputPatternAndMatches(repeatedWords.ToRegex(),
                "This is is a sentence with with with with repeated words.");
        }

        [Test]
        public void EndOfLineComments()
        {
            var repeatedWords = RegularExpression.New()
                .Then("//")
                .ThenAnythingBut('\n', '^');

            OutputPatternAndMatches(repeatedWords.ToRegex(), "This is some text // this is a comment ^ and this is not");
        }

        [Test]
        public static void Urls()
        {
            string[] subdomains = { "www", "blog", "speaking" };

            var http = RegularExpression.New()
                .Then("http")
                .ThenOptionally("s")
                .Then("://");

            var domain = RegularExpression.New()
                .ThenOneOf(subdomains)
                .Then('.')
                .ThenAnythingBut('.')
                .Then('.')
                .ThenFromRange('a', 'z').Exactly(3)
                .ThenOptionally('/');

            var httpUrl = RegularExpression.New()
                .Then('[')
                .ThenOptionalWhitespace()
                .Then(http)
                .Then(domain)
                .ThenOptionalWhitespace()
                .Then(']');

            OutputPatternAndMatches(httpUrl.ToRegex(),
                "Find my my blog under [http://blog.mariusschulz.com](this this page)");
        }

        private static void OutputPatternAndMatches(Regex regex, string input)
        {
            Console.WriteLine(regex);

            foreach (Match match in regex.Matches(input))
            {
                Console.WriteLine();
                Console.WriteLine(match);

                foreach (Group group in match.Groups)
                {
                    Console.WriteLine("   - {0}", @group.Value);
                }
            }
        }
    }
}
