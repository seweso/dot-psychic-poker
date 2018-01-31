using System;
using dot_psychic_poker_console;
using NUnit.Framework;

namespace dot_psychic_poker_consoleTests
{
    [TestFixture]
    public class CardTests
    {
        /// <summary>
        ///     Test creating card structs
        /// </summary>
        [Test]
        public void CreateTest()
        {
            Assert.AreEqual(Face.FaceTen, Card.Create("TH").Face);
            Assert.AreEqual(Suit.Hearts, Card.Create("TH").Suit);

            Assert.AreEqual(Face.Face2, Card.Create("2C").Face);
            Assert.AreEqual(Suit.Clubs, Card.Create("2C").Suit);

            Assert.AreEqual(Face.FaceAce, Card.Create("AD").Face);
            Assert.AreEqual(Suit.Diamonds, Card.Create("AD").Suit);

            Assert.AreEqual(Face.Face6, Card.Create("6S").Face);
            Assert.AreEqual(Suit.Spades, Card.Create("6S").Suit);

            Assert.Throws<ArgumentException>(() => Card.Create(""));
            Assert.Throws<ArgumentException>(() => Card.Create("A"));
            Assert.Throws<ArgumentException>(() => Card.Create("ACC"));
            Assert.Throws<ArgumentException>(() => Card.Create("Q♥"));
            Assert.Throws<ArgumentException>(() => Card.Create("0C"));
        }


        /// <summary>
        ///     Check rountrip parsing of string of cards to list of Card and back to string 
        /// </summary>
        [Test]
        public void GetCardsTest()
        {
            const string expected = "TH JH QC QD QS QH KH AH 2S 6S";
            var cards = Card.GetCards(expected);
            var actual = cards.Join();

            CollectionAssert.AreEqual(expected, actual);
        }
    }
}