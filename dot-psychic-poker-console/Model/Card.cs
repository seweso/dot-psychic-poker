using System;
using System.Collections.Generic;
using System.Linq;

namespace dot_psychic_poker_console.Model
{
    /// <summary>
    ///     Immutable struct representing a Poker Playing Card
    /// </summary>
    public struct Card
    {
        public readonly Face Face;
        public readonly Suit Suit;

        /// <summary>
        ///     c'tor
        /// </summary>
        /// <param name="suit"></param>
        /// <param name="face"></param>
        private Card(Suit suit, Face face)
        {
            Suit = suit;
            Face = face;
        }

        /// <summary>
        ///     Convert card to string 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format("{0}{1}", Face.ToCharacter(), Suit.ToCharacter());
        }

        /// <summary>
        ///     Convert one card as string to Card object
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public static Card Create(string arg)
        {
            if (arg.Length != 2)
            {
                throw new ArgumentException("Card string not of length 2:" + arg);
            }

            var face = FaceUtil.GetFace(arg[0]);
            var suite = SuitUtil.GetSuit(arg[1]);

            return new Card(suite, face);
        }
    }


    public static class CardUtil
    {
        /// <summary>
        ///     Convert list of cards to string
        /// </summary>
        /// <param name="cards"></param>
        /// <returns></returns>
        public static string Join(this IEnumerable<Card> cards)
        {
            return String.Join(" ", cards.Select(c => c.ToString()));
        }

        /// <summary>
        ///     Convert string of cards to list of card objects
        /// </summary>
        /// <param name="cardString"></param>
        /// <returns></returns>
        public static List<Card> GetCards(string cardString)
        {
            return cardString.Split(' ').Select(Card.Create).ToList();
        }
    }
}