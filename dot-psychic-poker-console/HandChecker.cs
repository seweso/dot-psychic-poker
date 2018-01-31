﻿using System;
using System.Collections.Generic;
using System.Linq;
using dot_psychic_poker_console.Model;

namespace dot_psychic_poker_console
{
    // TODO: Think of a better name for this class
    public static class HandChecker
    {
        private static readonly IReadOnlyDictionary<HandRank, Func<List<Card>, bool>> CheckFunctions = new Dictionary
            <HandRank, Func<List<Card>, bool>>
        {
            {HandRank.StraightFlush, IsStraightFlush},
            {HandRank.FourOfAKind, IsFourOfAKind},
            {HandRank.FullHouse, IsFullHouse},
            {HandRank.Flush, IsFlush},
            {HandRank.Straight, IsStraight},
            {HandRank.ThreeOfAKind, IsThreeOfAKind},
            {HandRank.TwoPairs, IsTwoPair},
            {HandRank.OnePair, IsOnePair},
            {HandRank.HighestCard, IsHighCard},
        };


        /// <summary>
        ///     Calculate the best possible rank for a hand and a deck
        /// </summary>
        /// <param name="hand"></param>
        /// <param name="deck"></param>
        /// <returns></returns>
        public static HandRank GetBestRank(List<Card> hand, List<Card> deck)
        {
            // TODO: Try multiple hands by grabbing from deck
            return GetBestRank(hand);
        }

        /// <summary>
        ///     Calculate best rank for a given hand
        /// </summary>
        /// <param name="hand"></param>
        /// <returns></returns>
        public static HandRank GetBestRank(List<Card> hand)
        {
            if (hand.Count != 5)
            {
                throw new ArgumentException("Hand should contain 5 cards");
            }

            // Go through all ranks
            foreach (var rank in EnumUtil.GetValues<HandRank>())
            {
                if (CheckFunctions[rank](hand))
                {
                    return rank;
                }
            }
            return HandRank.Nothing;
        }


        public static bool IsStraightFlush(List<Card> cards)
        {
            // Can't be a straight flush if all aren't the same suit
            if (!SameSuit(cards))
            {
                return false;
            }

            // Check whether cards are sequential, or cards are sequential when Ace is regarded as 1
            return Sequential(cards) || Sequential(cards.Select(c => c.AceAsOne));
        }

        private static bool SameSuit(List<Card> cards)
        {
            return cards.All(c => c.Suit == cards[0].Suit);
        }

        private static bool Sequential(IEnumerable<Card> cards)
        {
            var ordered = cards.OrderBy(c => c.Face).ToList();

            return ordered.Zip(ordered.Skip(1), (a, b) => (a.Face + 1) == b.Face).All(x => x);
        }


        private static bool IsFourOfAKind(List<Card> cards)
        {
            throw new NotImplementedException();
        }

        private static bool IsFullHouse(List<Card> cards)
        {
            throw new NotImplementedException();
        }

        private static bool IsFlush(List<Card> cards)
        {
            throw new NotImplementedException();
        }

        private static bool IsStraight(List<Card> cards)
        {
            throw new NotImplementedException();
        }

        private static bool IsThreeOfAKind(List<Card> cards)
        {
            throw new NotImplementedException();
        }

        private static bool IsTwoPair(List<Card> cards)
        {
            throw new NotImplementedException();
        }

        public static bool IsOnePair(List<Card> cards)
        {
            for (int i = 0; i < cards.Count - 1; i++)
            {
                for (int j = i + 1; j < cards.Count; j++)
                {
                    if (cards[i].Face == cards[j].Face)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static bool IsHighCard(List<Card> cards)
        {
            throw new NotImplementedException();
        }
    }
}