using System.Text.RegularExpressions;

namespace dot_psychic_poker_console.Model
{
    /// <summary>
    ///     Rank of a hand of Poker Cards
    /// </summary>
    public enum HandRank
    {
        StraightFlush,
        FourOfAKind,
        FullHouse,
        Flush,
        Straight,
        ThreeOfAKind,
        TwoPairs,
        OnePair,
        HighestCard,
    }

    public static class HandRankUtil
    {
        private static readonly Regex RegEx = new Regex("([A-Z])");

        /// <summary>
        ///     Convert notation as used in C# to what needs to be written to string (convert CamelCasing to something-with-dashes-and-lower-case-only)
        /// </summary>
        /// <param name="rank"></param>
        /// <returns></returns>
        public static string ToRankString(this HandRank rank)
        {
            return RegEx.Replace(rank.ToString(), "-$1").ToLower().Substring(1);
        }
    }
}