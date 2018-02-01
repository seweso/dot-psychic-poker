using dot_psychic_poker_console;
using NUnit.Framework;

namespace dot_psychic_poker_consoleTests
{
    [TestFixture]
    public class BitUtilTests
    {
        [Test]
        public void IsBitSetTest()
        {
            Assert.IsFalse(BitUtil.IsBitSet(0, 0));
            Assert.IsFalse(BitUtil.IsBitSet(0, 1));
            Assert.IsFalse(BitUtil.IsBitSet(0, 2));
            Assert.IsFalse(BitUtil.IsBitSet(0, 3));
            Assert.IsFalse(BitUtil.IsBitSet(0, 4));

            Assert.IsTrue(BitUtil.IsBitSet(1, 0));
            Assert.IsFalse(BitUtil.IsBitSet(1, 1));
            Assert.IsFalse(BitUtil.IsBitSet(1, 2));
            Assert.IsFalse(BitUtil.IsBitSet(1, 3));
            Assert.IsFalse(BitUtil.IsBitSet(1, 4));

            Assert.IsFalse(BitUtil.IsBitSet(2, 0));
            Assert.IsTrue(BitUtil.IsBitSet(2, 1));
            Assert.IsFalse(BitUtil.IsBitSet(2, 2));
            Assert.IsFalse(BitUtil.IsBitSet(2, 3));
            Assert.IsFalse(BitUtil.IsBitSet(2, 4));

            Assert.IsTrue(BitUtil.IsBitSet(3, 0));
            Assert.IsTrue(BitUtil.IsBitSet(3, 1));
            Assert.IsFalse(BitUtil.IsBitSet(3, 2));
            Assert.IsFalse(BitUtil.IsBitSet(3, 3));
            Assert.IsFalse(BitUtil.IsBitSet(3, 4));
        }
    }
}