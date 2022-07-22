using NUnit.Framework;

namespace PairBrackets.Tests
{
    [TestFixture]
    public class StringExtensionsTests
    {
        private static readonly object[][] GetBracketPairPositionsData =
        {
            new object[]
            {
                string.Empty,
                Array.Empty<(int, int)>(),
            },
            new object[]
            {
                "{{   {",
                Array.Empty<(int, int)>(),
            },
            new object[]
            {
                "[",
                Array.Empty<(int, int)>(),
            },
            new object[]
            {
                "{432   34}Test [Test][Test Test)",
                new (int, int)[] { (0, 9), (15, 20) },
            },
            new object[]
            {
                "([([   {{ }}  ])])",
                new (int, int)[] { (0, 17), (1, 16), (2, 15), (3, 14), (7, 11), (8, 10) },
            },
            new object[]
            {
                "{abc  ([b ]a)}",
                new (int, int)[] { (0, 13), (6, 12), (7, 10) },
            },
            new object[]
            {
                "Test Test Test",
                Array.Empty<(int, int)>(),
            },
            new object[]
            {
                "{abc   ([a{sas}b]a)}",
                new (int, int)[] { (0, 19), (7, 18), (8, 16), (10, 14) },
            },
            new object[]
            {
                "ab  c([b] a)}",
                new (int, int)[] { (5, 11), (6, 8) },
            },
            new object[]
            {
                "{abc(   [a{s  {as}b]a)}   }",
                new (int, int)[] { (10, 22), (14, 17) },
            },
            new object[]
            {
                "()",
                new (int, int)[] { (0, 1) },
            },
            new object[]
            {
                "(       )[  ]",
                new (int, int)[] { (0, 8), (9, 12) },
            },
            new object[]
            {
                "()[]{}",
                new (int, int)[] { (0, 1), (2, 3), (4, 5) },
            },
            new object[]
            {
                "[]  {}",
                new (int, int)[] { (0, 1), (4, 5) },
            },
            new object[]
            {
                "{}",
                new (int, int)[] { (0, 1) },
            },
            new object[]
            {
                "[]",
                new (int, int)[] { (0, 1) },
            },
            new object[]
            {
                "[{()}]",
                new (int, int)[] { (0, 5), (1, 4), (2, 3) },
            },
            new object[]
            {
                "(      {[ ]}    )",
                new (int, int)[] { (0, 16), (7, 11), (8, 10) },
            },
            new object[]
            {
                "(",
                Array.Empty<(int, int)>(),
            },
            new object[]
            {
                ")",
                Array.Empty<(int, int)>(),
            },
            new object[]
            {
                "[",
                Array.Empty<(int, int)>(),
            },
            new object[]
            {
                "]",
                Array.Empty<(int, int)>(),
            },
            new object[]
            {
                "{",
                Array.Empty<(int, int)>(),
            },
            new object[]
            {
                "}",
                Array.Empty<(int, int)>(),
            },
            new object[]
            {
                "}Test",
                Array.Empty<(int, int)>(),
            },
            new object[]
            {
                "} ( )Test {",
                new (int, int)[] { (2, 4) },
            },
        };

        [TestCase("", ExpectedResult = 0)]
        [TestCase("{{   {", ExpectedResult = 0)]
        [TestCase("[", ExpectedResult = 0)]
        [TestCase("{432   34}Test [Test][Test Test)", ExpectedResult = 1)]
        [TestCase("([([   {{ }}  ])])", ExpectedResult = 4)]
        [TestCase("{abc  ([b ]a)}", ExpectedResult = 2)]
        [TestCase("Test Test Test", ExpectedResult = 0)]
        [TestCase("{abc   ([a{sas}b]a)}", ExpectedResult = 2)]
        [TestCase("ab  c([b] a)}", ExpectedResult = 2)]
        [TestCase("{abc(   [a{s  {as}b]a)}   }", ExpectedResult = 2)]
        [TestCase("()", ExpectedResult = 1)]
        [TestCase("(       )[  ]", ExpectedResult = 2)]
        [TestCase("()[]{}", ExpectedResult = 2)]
        [TestCase("[]  {}", ExpectedResult = 1)]
        [TestCase("{}", ExpectedResult = 0)]
        [TestCase("[]", ExpectedResult = 1)]
        [TestCase("[{()}]", ExpectedResult = 2)]
        [TestCase("(      {[ ]}    )", ExpectedResult = 2)]
        [TestCase("(", ExpectedResult = 0)]
        [TestCase(")", ExpectedResult = 0)]
        [TestCase("[", ExpectedResult = 0)]
        [TestCase("]", ExpectedResult = 0)]
        [TestCase("{", ExpectedResult = 0)]
        [TestCase("}", ExpectedResult = 0)]
        [TestCase("}Test", ExpectedResult = 0)]
        [TestCase("} ( )Test {", ExpectedResult = 1)]
        public int CountBracketPairs_TextIsNotNull_ReturnsBracketPairsNumber(string text)
        {
            return text.CountBracketPairs();
        }

        [Test]
        public void GetBracketPairPositions_TextIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => (null as string).GetBracketPairPositions(), "text argument should be checked for null.");
        }

        [TestCaseSource(nameof(GetBracketPairPositionsData))]
        public void GetBracketPairPositions_TextIsNotNull_ReturnsBracketPairsPositions(string text, IList<(int, int)> expectedResult)
        {
            IList<(int, int)> actualResult = text.GetBracketPairPositions();

            Assert.AreEqual(expectedResult.Count, actualResult.Count);
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [TestCase("", BracketTypes.All, ExpectedResult = true)]
        [TestCase("{{   {", BracketTypes.All, ExpectedResult = false)]
        [TestCase("[", BracketTypes.All, ExpectedResult = false)]
        [TestCase("{432   34}Test [Test][Test Test)", BracketTypes.All, ExpectedResult = false)]
        [TestCase("{432   34}Test [Test][Test Test)", BracketTypes.SquareBrackets, ExpectedResult = false)]
        [TestCase("{432   34}Test [Test][Test Test)", BracketTypes.RoundBrackets, ExpectedResult = false)]
        [TestCase("{432   34}Test [Test][Test Test)", BracketTypes.CurlyBrackets, ExpectedResult = true)]
        [TestCase("([([   {{ }}  ])])", BracketTypes.All, ExpectedResult = true)]
        [TestCase("{abc  ([b ]a)}", BracketTypes.All, ExpectedResult = true)]
        [TestCase("Test Test Test", BracketTypes.All, ExpectedResult = true)]
        [TestCase("{abc   ([a{sas}b]a)}", BracketTypes.All, ExpectedResult = true)]
        [TestCase("ab  c([b] a)}", BracketTypes.All, ExpectedResult = false)]
        [TestCase("ab  c([b] a)}", BracketTypes.SquareBrackets, ExpectedResult = true)]
        [TestCase("ab  c([b] a)}", BracketTypes.RoundBrackets, ExpectedResult = true)]
        [TestCase("ab  c([b] a)}", BracketTypes.CurlyBrackets, ExpectedResult = false)]
        [TestCase("{abc(   [a{s  {as}b]a)}   }", BracketTypes.All, ExpectedResult = false)]
        [TestCase("{abc(   [a{s  {as}b]a)}   }", BracketTypes.SquareBrackets, ExpectedResult = true)]
        [TestCase("{abc(   [a{s  {as}b]a)}   }", BracketTypes.RoundBrackets, ExpectedResult = true)]
        [TestCase("{abc(   [a{s  {as}b]a)}   }", BracketTypes.CurlyBrackets, ExpectedResult = true)]
        [TestCase("()", BracketTypes.All, ExpectedResult = true)]
        [TestCase("(       )[  ]", BracketTypes.All, ExpectedResult = true)]
        [TestCase("()[]{}", BracketTypes.All, ExpectedResult = true)]
        [TestCase("()[]{}", BracketTypes.RoundBrackets, ExpectedResult = true)]
        [TestCase("()[]{}", BracketTypes.CurlyBrackets, ExpectedResult = true)]
        [TestCase("()[]{}", BracketTypes.SquareBrackets, ExpectedResult = true)]
        [TestCase("[]  {}", BracketTypes.All, ExpectedResult = true)]
        [TestCase("{}", BracketTypes.All, ExpectedResult = true)]
        [TestCase("[]", BracketTypes.All, ExpectedResult = true)]
        [TestCase("[{()}]", BracketTypes.All, ExpectedResult = true)]
        [TestCase("[{()}]", BracketTypes.SquareBrackets, ExpectedResult = true)]
        [TestCase("[{()}]", BracketTypes.CurlyBrackets, ExpectedResult = true)]
        [TestCase("[{()}]", BracketTypes.RoundBrackets, ExpectedResult = true)]
        [TestCase("(      {[ ]}    )", BracketTypes.All, ExpectedResult = true)]
        [TestCase("(", BracketTypes.All, ExpectedResult = false)]
        [TestCase(")", BracketTypes.All, ExpectedResult = false)]
        [TestCase("[", BracketTypes.All, ExpectedResult = false)]
        [TestCase("]", BracketTypes.All, ExpectedResult = false)]
        [TestCase("{", BracketTypes.All, ExpectedResult = false)]
        [TestCase("}", BracketTypes.All, ExpectedResult = false)]
        [TestCase("}Test", BracketTypes.All, ExpectedResult = false)]
        [TestCase("} ( )Test {", BracketTypes.All, ExpectedResult = false)]
        public bool ValidateBrackets_TextIsNotNull_ReturnsValidationResult(string text, BracketTypes bracketTypes)
        {
            return text.ValidateBrackets(bracketTypes);
        }

        [Test]
        public void ValidateBrackets_TextIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => (null as string).ValidateBrackets(BracketTypes.RoundBrackets), "text argument should be checked for null.");
        }
    }
}
