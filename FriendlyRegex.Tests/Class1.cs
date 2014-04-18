﻿using System;
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
                .Then(Multiple.NonWhiteSpaceCharacters)
                .Then(Multiple.NonDigits)
                .EndOfLine();

            var regex = expression.ToRegex();

            Console.WriteLine(expression);
            Console.WriteLine(regex.IsMatch("1...Test"));
        }
    }
}
