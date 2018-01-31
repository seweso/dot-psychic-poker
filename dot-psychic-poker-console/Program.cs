using System;
using dot_psychic_poker_console.Model;

namespace dot_psychic_poker_console
{
    public static class Program
    {
        /// <summary>
        ///     Reads from stdin and writes output of The Psychic Poker player to stdout.
        /// 
        ///     Example: type input.txt | dot-psychic-poker-console.exe
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            string line;
            while ((line = Console.ReadLine()) != null && line != "")
            {
                Console.WriteLine(Process(line));
            }
        }

        /// <summary>
        ///     Process one line
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public static string Process(string line)
        {
            var cards = CardUtil.GetCards(line);

            if (cards.Count != 10)
            {
                throw new ArgumentException("Card count incorrect: " + cards.Count);
            }

            var hand = cards.GetRange(0, 5);
            var deck = cards.GetRange(5, 5);
            var bestHand = HandChecker.GetBestRank(hand, deck);

            return "Hand: " + hand.Join() + " Deck: " + deck.Join() + " Best hand: " + bestHand.ToRankString();
        }
    }
}