using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using dot_psychic_poker_console.Model;

namespace dot_psychic_poker_console
{
    // TODO: Think of a better name for this class
    public class HandChecker
    {
        public IDictionary<HandRank, Func<List<Card>, bool>> CheckFunctions = new Dictionary
            <HandRank, Func<List<Card>, bool>>
        {
            {HandRank.StraightFlush, IsStraightFlush},
            {HandRank.FourOfAKind, IsFourOfAKind},
            {HandRank.FullHouse, IsFullHouse},
            {HandRank.Flush, IsFlush},
            {HandRank.Straight, IsStraight},
            {HandRank.ThreeOfAKind, IsThreeOfAKind},
            {HandRank.TwoPair, IsTwoPair},
            {HandRank.OnePair, IsOnePair},
            {HandRank.HighCard, IsHighCard},
        };

        public static bool IsStraightFlush(List<Card> cards)
        {
            throw new NotImplementedException();
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