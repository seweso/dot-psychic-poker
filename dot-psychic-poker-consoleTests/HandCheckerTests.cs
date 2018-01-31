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
        public void IsOnePairTest()
        {
            Assert.True(HandChecker.IsOnePair(CardUtil.GetCards("2H 2S")));
            Assert.False(HandChecker.IsOnePair(CardUtil.GetCards("3H 2S")));
        }
    }
}