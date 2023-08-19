namespace PairBrackets
{
    public static class StringExtensions
    {
        public static bool IsMatchingBracket(char openingBracket, char closingBracket)
        {
            return (openingBracket == '(' && closingBracket == ')') ||
                   (openingBracket == '[' && closingBracket == ']');
        }

        public static bool IsOpeningBracket(char c, BracketTypes bracketTypes)
        {
            return (bracketTypes.HasFlag(BracketTypes.RoundBrackets) && c == '(') ||
                   (bracketTypes.HasFlag(BracketTypes.SquareBrackets) && c == '[') ||
                   (bracketTypes.HasFlag(BracketTypes.CurlyBrackets) && c == '{') ||
                   (bracketTypes.HasFlag(BracketTypes.AngleBrackets) && c == '<');
        }

        public static bool IsClosingBracket(char c, BracketTypes bracketTypes)
        {
            return (bracketTypes.HasFlag(BracketTypes.RoundBrackets) && c == ')') ||
                   (bracketTypes.HasFlag(BracketTypes.SquareBrackets) && c == ']') ||
                   (bracketTypes.HasFlag(BracketTypes.CurlyBrackets) && c == '}') ||
                   (bracketTypes.HasFlag(BracketTypes.AngleBrackets) && c == '>');
        }

        public static bool AreMatchingBrackets(char openingBracket, char closingBracket)
        {
            return (openingBracket == '(' && closingBracket == ')') ||
                   (openingBracket == '[' && closingBracket == ']') ||
                   (openingBracket == '{' && closingBracket == '}') ||
                   (openingBracket == '<' && closingBracket == '>');
        }

        /// <summary>
        /// Returns the number of bracket pairs in the <see cref="text"/>.
        /// </summary>
        /// <param name="text">The source text.</param>
        /// <returns>The number of bracket pairs in the <see cref="text"/>.</returns>
        public static int CountBracketPairs(this string text)
        {
            // TODO #1. Analyze the method unit tests and add the method implementation.
            if (text is null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            Stack<char> stack = new Stack<char>();
            int count = 0;

            foreach (char c in text)
            {
                if (c == '(' || c == '[')
                {
                    stack.Push(c);
                }
                else if ((c == ')' || c == ']') && (stack.Count > 0 && IsMatchingBracket(stack.Peek(), c)))
                {
                    stack.Pop();
                    count++;
                }
            }

            return count;
        }

        /// <summary>
        /// Searches the <see cref="text"/> and returns the list of start and end positions of bracket pairs.
        /// </summary>
        /// <param name="text">The source text.</param>
        /// <returns>The list of start and end positions of bracket pairs.</returns>
        /// <exception cref="ArgumentNullException"><see cref="text"/> is null.</exception>
        public static IList<(int, int)> GetBracketPairPositions(this string? text)
        {
            // TODO #2. Analyze the method unit tests and add the method implementation.
            if (text is null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            var positions = new List<(int, int)>();
            var stack = new Stack<(char, int)>();

            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];

                if (c == '(' || c == '[' || c == '{')
                {
                    stack.Push((c, i));
                }
                else if ((c == ')' || c == ']' || c == '}') && stack.Count > 0)
                {
                    var top = stack.Pop();
                    char openingBracket = top.Item1;
                    int start = top.Item2;
                    if ((openingBracket == '(' && c == ')') || (openingBracket == '[' && c == ']') ||
                        (openingBracket == '{' && c == '}'))
                    {
                        positions.Add((start, i));
                    }
                }
            }

            return positions;
        }

        /// <summary>
        /// Examines the <see cref="text"/> and returns true if the pairs and the orders of brackets are balanced; otherwise returns false.
        /// </summary>
        /// <param name="text">The source text.</param>
        /// <param name="bracketTypes">The bracket type option.</param>
        /// <returns>True if the pairs and the orders of brackets are balanced; otherwise returns false.</returns>
        /// <exception cref="ArgumentNullException"><see cref="text"/> is null.</exception>
        public static bool ValidateBrackets(this string? text, BracketTypes bracketTypes)
        {
            // TODO #3. Analyze the method unit tests and add the method implementation.
            if (text is null)
            {
                throw new ArgumentNullException(nameof(text));
            }

            var stack = new Stack<char>();

            foreach (char c in text)
            {
                if (IsOpeningBracket(c, bracketTypes))
                {
                    stack.Push(c);
                }
                else if (IsClosingBracket(c, bracketTypes) && (stack.Count == 0 || !AreMatchingBrackets(stack.Pop(), c)))
                {
                    return false;
                }
            }

            return stack.Count == 0;
        }
    }

    [Flags]
    public enum BracketTypes
    {
        All = 0,
        RoundBrackets = 1,
        SquareBrackets = 2,
        CurlyBrackets = 3,
        AngleBrackets = 4,
    }
}
