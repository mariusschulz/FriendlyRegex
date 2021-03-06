﻿using FriendlyRegularExpressions.CharacterClasses;
using FriendlyRegularExpressions.Quantifiers;

namespace FriendlyRegularExpressions
{
    public static class One
    {
        public static readonly RegularExpression ArbitraryCharacter;

        public static readonly RegularExpression Digit;
        public static readonly RegularExpression NonDigit;

        public static readonly RegularExpression WhiteSpaceCharacter;
        public static readonly RegularExpression NonWhiteSpaceCharacter;

        public static readonly RegularExpression Word;
        public static readonly RegularExpression WordCharacter;
        public static readonly RegularExpression NonWordCharacter;

        public static readonly RegularExpression WordBoundary;
        public static readonly RegularExpression NonWordBoundary;

        public static RegularExpression Tab { get; private set; }
        public static RegularExpression NewLine { get; private set; }
        public static RegularExpression CarriageReturn { get; private set; }

        static One()
        {
            ArbitraryCharacter = Dot.Instance;

            Digit = new ShorthandCharacterClass(@"\d");
            NonDigit = new ShorthandCharacterClass(@"\D");

            WhiteSpaceCharacter = new ShorthandCharacterClass(@"\s");
            NonWhiteSpaceCharacter = new ShorthandCharacterClass(@"\S");

            WordBoundary = Anchor.WordBoundary;
            NonWordBoundary = Anchor.NonWordBoundary;

            WordCharacter = new ShorthandCharacterClass(@"\w");
            NonWordCharacter = new ShorthandCharacterClass(@"\W");

            Word = Concatenation.Concatenate(WordBoundary, PlusQuantifier.GreedilyQuantify(WordCharacter), WordBoundary);

            Tab = new CharacterEscape(@"\t");
            NewLine = new CharacterEscape(@"\n");
            CarriageReturn = new CharacterEscape(@"\r");
        }
    }
}
