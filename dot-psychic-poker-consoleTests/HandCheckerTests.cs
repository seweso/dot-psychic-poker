using System.Collections.Generic;
using System.Linq;
using dot_psychic_poker_console;
using NUnit.Framework;

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
