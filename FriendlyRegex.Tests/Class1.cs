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
                .Capture(One.Word).As("word")
                .Whitespace()
                .ValueOfCapture("word");

            OutputPatternAndMatches(repeatedWords.ToRegex(),
                "This is is a sentence with with with with repeated words.");
        }

        [Test]
        public void EndOfLineComments()
        {
            var repeatedWords = RegularExpression.New()
                .Then("//")
                .AnythingBut('\n', '^');

            OutputPatternAndMatches(repeatedWords.ToRegex(), "This is some text // this is a comment ^ and this is not");
        }

        [Test]
        public static void Urls()
        {
            string[] subdomains = { "www", "blog", "speaking" };

            var http = RegularExpression.New()
                .Then("http")
                .Maybe("s")
                .Then("://");

            var domain = RegularExpression.New()
                .OneOf(subdomains)
                .Then('.')
                .AnythingBut('.')
                .Then('.')
                .FromRange('a', 'z').Exactly(3)
                .Maybe('/');

            var httpUrl = RegularExpression.New()
                .Then('[')
                .MaybeWhitespace()
                .Then(http)
                .Then(domain)
                .MaybeWhitespace()
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
