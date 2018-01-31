using System.Collections.Generic;
using System.Linq;
using dot_psychic_poker_console;
using NUnit.Framework;

namespace dot_psychic_poker_console.Tests
{
    [TestFixture()]
    public class HandCheckerTests
    {
        [Test()]
        public void IsStraightFlushTest()
        {
            Assert.True(HandChecker.IsStraightFlush(Card.GetCards("Q♥ J♥ 10♥ 9♥ 8♥")));


            Assert.False(HandChecker.IsStraightFlush(Card.GetCards("Q♥ J♥ 10♣ 9♥ 8♥")));
            
        }
    }
}

namespace dot_psychic_poker_consoleTests
{
    [TestFixture]
    public class HandCheckerTests
    {
        [Test]
        public void IsOnePairTest()
        {
            Assert.True(HandChecker.IsOnePair(Card.GetCards("2H 2S")));
            Assert.False(HandChecker.IsOnePair(Card.GetCards("3H 2S")));
        }
    }
}