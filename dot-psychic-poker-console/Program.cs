﻿using System;
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
        private static void Main()
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

            if (cards.Count != (Constants.CardsInOneHand*2))
            {
                throw new ArgumentException("Card count incorrect: " + cards.Count);
            }

            var hand = cards.GetRange(0, Constants.CardsInOneHand);
            var deck = cards.GetRange(Constants.CardsInOneHand, Constants.CardsInOneHand);
            var bestHand = HandChecker.GetBestRank(hand, deck);

            return "Hand: " + hand.Join() + " Deck: " + deck.Join() + " Best hand: " + bestHand.ToRankString();
        }
    }
}