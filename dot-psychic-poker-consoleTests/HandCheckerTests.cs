﻿using System.Collections.Generic;
using System.Linq;
using dot_psychic_poker_console;
using dot_psychic_poker_console.Model;
using NUnit.Framework;

namespace dot_psychic_poker_consoleTests
{
    [TestFixture]
    public class HandCheckerTests
    {
        [Test]
        public void IsStraightFlushTest()
        {
            Assert.True(HandChecker.IsStraightFlush(CardUtil.GetCards("AH KH QH JH TH")));
            Assert.True(HandChecker.IsStraightFlush(CardUtil.GetCards("KH QH JH TH 9H")));
            Assert.True(HandChecker.IsStraightFlush(CardUtil.GetCards("QH JH TH 9H 8H")));
            Assert.True(HandChecker.IsStraightFlush(CardUtil.GetCards("8H 7H 6H 5H 4H")));
            Assert.True(HandChecker.IsStraightFlush(CardUtil.GetCards("6H 5H 2H 3H 4H")));
            Assert.True(HandChecker.IsStraightFlush(CardUtil.GetCards("AH 5H 4H 3H 2H")));

            Assert.False(HandChecker.IsStraightFlush(CardUtil.GetCards("AH JH TH 9H 8H")));
            Assert.False(HandChecker.IsStraightFlush(CardUtil.GetCards("QH JH TS 9H 8H")));
        }

        [Test]
        public void IsFourOfAKindTest()
        {
            Assert.True(HandChecker.IsFourOfAKind(CardUtil.GetCards("5H 5S 5C 5D 8H")));
            Assert.True(HandChecker.IsFourOfAKind(CardUtil.GetCards("AH AS AC AD 8H")));

            Assert.False(HandChecker.IsFourOfAKind(CardUtil.GetCards("5H 5S 5C 4D 8H")));
            Assert.False(HandChecker.IsFourOfAKind(CardUtil.GetCards("3H AS AC AD 8H")));
        }


        [Test]
        public void IsFullHouseTest()
        {
            Assert.True(HandChecker.IsFullHouse(CardUtil.GetCards("5H 5S 8C 8D 8H")));
            Assert.True(HandChecker.IsFullHouse(CardUtil.GetCards("AH AS 6C 6D 6H")));

            Assert.False(HandChecker.IsFullHouse(CardUtil.GetCards("5H 5S 5C 4D 8H")));
            Assert.False(HandChecker.IsFullHouse(CardUtil.GetCards("3H AS AC AD 8H")));
        }

        [Test]
        public void IsFlushTest()
        {
            Assert.True(HandChecker.IsFlush(CardUtil.GetCards("AH JH TH 9H 8H")));

            Assert.False(HandChecker.IsFlush(CardUtil.GetCards("AH JC TH 9H 8H")));
        }

        [Test]
        public void IsStraightTest()
        {
            Assert.True(HandChecker.IsStraight(CardUtil.GetCards("AD KH QH JH TH")));
            Assert.True(HandChecker.IsStraight(CardUtil.GetCards("KH QD JH TH 9H")));
            Assert.True(HandChecker.IsStraight(CardUtil.GetCards("QH JH TD 9H 8H")));
            Assert.True(HandChecker.IsStraight(CardUtil.GetCards("8H 7H 6H 5D 4H")));
            Assert.True(HandChecker.IsStraight(CardUtil.GetCards("6H 5S 2H 3H 4D")));
            Assert.True(HandChecker.IsStraight(CardUtil.GetCards("AH 5H 4H 3D 2H")));

            Assert.False(HandChecker.IsStraight(CardUtil.GetCards("AH JH TH 9H 8H")));
            Assert.False(HandChecker.IsStraight(CardUtil.GetCards("QH JH TS 9H 7H")));
        }


        [Test]
        public void IsThreeOfAKindTest()
        {
            Assert.True(HandChecker.IsThreeOfAKind(CardUtil.GetCards("5H 5S 5C 6D 8H")));
            Assert.True(HandChecker.IsThreeOfAKind(CardUtil.GetCards("AH AS AC 4D 8H")));

            Assert.False(HandChecker.IsThreeOfAKind(CardUtil.GetCards("5H 2S 5C 4D 8H")));
            Assert.False(HandChecker.IsThreeOfAKind(CardUtil.GetCards("3H AS AC 2D 8H")));
        }

        [Test]
        public void IsTwoPairTest()
        {
            Assert.True(HandChecker.IsTwoPair(CardUtil.GetCards("5H 5S 6C 6D 8H")));
            Assert.True(HandChecker.IsTwoPair(CardUtil.GetCards("AH AS 5C 5D 8H")));

            Assert.False(HandChecker.IsTwoPair(CardUtil.GetCards("5H 5S 5C 4D 8H")));
            Assert.False(HandChecker.IsTwoPair(CardUtil.GetCards("3H 3S AC 2D 8H")));
        }


        [Test]
        public void IsOnePairTest()
        {
            Assert.True(HandChecker.IsOnePair(CardUtil.GetCards("2H 2S 1H 4H 3H")));
            Assert.False(HandChecker.IsOnePair(CardUtil.GetCards("3H 2S 1H 6H 8H")));
        }


        [Test]
        public void GetBestRankHandAndDeckTest()
        {
            IReadOnlyList<Card> hand = CardUtil.GetCards("2H 2S 3H 3S 3C");
            IReadOnlyList<Card> deck = CardUtil.GetCards("2D 3D 6C 9C TH");

            Assert.AreEqual(HandRank.FourOfAKind, HandChecker.GetBestRank(hand, deck));
        }

        [Test]
        public void GetBestRankForHandTest()
        {
            Assert.AreEqual(HandRank.StraightFlush, HandChecker.GetBestRank(CardUtil.GetCards("AH KH QH JH TH")));
            Assert.AreEqual(HandRank.FourOfAKind, HandChecker.GetBestRank(CardUtil.GetCards("5H 5S 5C 5D 8H")));
            Assert.AreEqual(HandRank.FullHouse, HandChecker.GetBestRank(CardUtil.GetCards("5H 5S 8C 8D 8H")));
            Assert.AreEqual(HandRank.Flush, HandChecker.GetBestRank(CardUtil.GetCards("AH JH TH 9H 8H")));
            Assert.AreEqual(HandRank.Straight, HandChecker.GetBestRank(CardUtil.GetCards("AD KH QH JH TH")));
            Assert.AreEqual(HandRank.ThreeOfAKind, HandChecker.GetBestRank(CardUtil.GetCards("5H 5S 5C 6D 8H")));
            Assert.AreEqual(HandRank.TwoPairs, HandChecker.GetBestRank(CardUtil.GetCards("5H 5S 6C 6D 8H")));
            Assert.AreEqual(HandRank.OnePair, HandChecker.GetBestRank(CardUtil.GetCards("2H 2S 1H 4H 3H")));
            Assert.AreEqual(HandRank.HighestCard, HandChecker.GetBestRank(CardUtil.GetCards("5H 7S 6C KD 8H")));
        }


        [Test]
        public void GetAllPossibleHandsTest()
        {
            var actual =
                HandChecker.GetAllPossibleHands(CardUtil.GetCards("1H 2H 3H"), CardUtil.GetCards("1S 2S 3S"))
                    .ToList();

            var expected = new List<IReadOnlyList<Card>>
            {
                CardUtil.GetCards("1H 2H 3H"),
                CardUtil.GetCards("1S 2H 3H"),
                CardUtil.GetCards("1H 1S 3H"),
                CardUtil.GetCards("1S 2S 3H"),
                CardUtil.GetCards("1H 2H 1S"),
                CardUtil.GetCards("1S 2H 2S"),
                CardUtil.GetCards("1H 1S 2S"),
                CardUtil.GetCards("1S 2S 3S"),
            };

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}