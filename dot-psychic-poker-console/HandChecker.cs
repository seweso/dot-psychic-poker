using System;
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
            if (hand.Count != 5)
            {
                throw new ArgumentException("Hand should contain 5 cards");
            }

            HandRank currentRank = HandRank.HighestCard;

            // 5 cards is 5 bits
            int totalNrOfOptions = (int) Math.Pow(2, 5);

            // Brute force all options by replacing cards based on bit mask // TODO Refactor into enumerator
            for (int i = 0; i < totalNrOfOptions; i++)
            {
                var handCopy = new List<Card>(hand);
                int deckPosition = 0;

                // Loop through cards 1-5
                for (int b = 0; b < 5; b++)
                {
                    // If this bit 1 then replace card
                    if (BitUtil.IsBitSet(i, b))
                    {
                        handCopy[b] = deck[deckPosition++];
                    }
                }

                // Calculate best rank for this hand
                var rankForCurrentHand = GetBestRank(handCopy);

                // No need to search further if you found a straight flush
                if (rankForCurrentHand == HandRank.StraightFlush)
                {
                    return HandRank.StraightFlush;
                }

                // Found a beter rank?
                if (rankForCurrentHand < currentRank)
                {
                    currentRank = rankForCurrentHand;
                }
            }

            return currentRank;
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

            return HandRank.HighestCard;
        }


        public static bool IsStraightFlush(List<Card> cards)
        {
            if (cards.Count != 5)
            {
                throw new ArgumentException("Hand should contain 5 cards");
            }

            // Can't be a straight flush if all aren't the same suit
            if (!IsSameSuit(cards))
            {
                return false;
            }

            return IsSequentialHighRules(cards);
        }

        private static bool IsSequentialHighRules(List<Card> cards)
        {
            // Check whether cards are sequential, or cards are sequential when Ace is regarded as 1
            return IsSequential(cards) || IsSequential(cards.Select(c => c.AceAsOne));
        }

        private static bool IsSameSuit(List<Card> cards)
        {
            return cards.All(c => c.Suit == cards[0].Suit);
        }

        private static bool IsSequential(IEnumerable<Card> cards)
        {
            var ordered = cards.OrderBy(c => c.Face).ToList();

            return ordered.Zip(ordered.Skip(1), (a, b) => (a.Face + 1) == b.Face).All(x => x);
        }

        public static bool IsFourOfAKind(List<Card> cards)
        {
            if (cards.Count != 5)
            {
                throw new ArgumentException("Hand should contain 5 cards");
            }

            var ordered = cards.OrderBy(c => c.Face).ToList();

            // If this is a four of a kind, the middle card should be the majority type
            var face = ordered[2].Face;

            // Check if there are four cards of this face
            return cards.Count(c => c.Face == face) == 4;
        }

        public static bool IsFullHouse(List<Card> cards)
        {
            if (cards.Count != 5)
            {
                throw new ArgumentException("Hand should contain 5 cards");
            }

            var ordered = cards.OrderBy(c => c.Face).ToList();

            // Count nr of cards with faces like the first and last card
            var count1 = cards.Count(c => c.Face == ordered[0].Face);
            var count2 = cards.Count(c => c.Face == ordered[4].Face);

            // 3/2 and 2/3 means this is a full house
            if (count1 == 3 && count2 == 2)
            {
                return true;
            }

            if (count1 == 2 && count2 == 3)
            {
                return true;
            }

            return false;
        }

        public static bool IsFlush(List<Card> cards)
        {
            if (cards.Count != 5)
            {
                throw new ArgumentException("Hand should contain 5 cards");
            }

            return IsSameSuit(cards);
        }

        public static bool IsStraight(List<Card> cards)
        {
            if (cards.Count != 5)
            {
                throw new ArgumentException("Hand should contain 5 cards");
            }

            return IsSequentialHighRules(cards);
        }

        public static bool IsThreeOfAKind(List<Card> cards)
        {
            if (cards.Count != 5)
            {
                throw new ArgumentException("Hand should contain 5 cards");
            }

            var ordered = cards.OrderBy(c => c.Face).ToList();

            // If this is a three of a kind, the middle card should be the majority type
            var face = ordered[2].Face;

            // Check if there are three cards of this face
            return cards.Count(c => c.Face == face) == 3;
        }

        public static bool IsTwoPair(List<Card> cards)
        {
            if (cards.Count != 5)
            {
                throw new ArgumentException("Hand should contain 5 cards");
            }

            // Group by face, and order by count descending (to get two groups of two first)
            var counts = cards.GroupBy(c => c.Face).Select(g => g.Count()).OrderByDescending(g => g).ToList();

            return counts.Count == 3 && counts[0] == 2 && counts[1] == 2;
        }

        public static bool IsOnePair(List<Card> cards)
        {
            if (cards.Count != 5)
            {
                throw new ArgumentException("Hand should contain 5 cards");
            }

            // Group by face, and order by count descending (to one group of two first)
            var counts = cards.GroupBy(c => c.Face).Select(g => g.Count()).OrderByDescending(g => g).ToList();

            return counts[0] == 2;
        }

        private static bool IsHighCard(List<Card> cards)
        {
            // If you got this far, it's a high card (aka nothing)
            return true;
        }
    }
}