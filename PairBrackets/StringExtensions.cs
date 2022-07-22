namespace PairBrackets
{
    public static class StringExtensions
    {
        /// <summary>
        /// Returns the number of bracket pairs in the <see cref="text"/>.
        /// </summary>
        /// <param name="text">The source text.</param>
        /// <returns>The number of bracket pairs in the <see cref="text"/>.</returns>
        public static int CountBracketPairs(this string text)
        {
            // TODO #1. Analyze the method unit tests and add the method implementation.
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
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
