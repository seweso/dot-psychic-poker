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
        public void IsOnePairTest()
        {
            Assert.True(HandChecker.IsOnePair(CardUtil.GetCards("2H 2S")));
            Assert.False(HandChecker.IsOnePair(CardUtil.GetCards("3H 2S")));
        }
    }
}