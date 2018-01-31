using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace dot_psychic_poker_console
{
    /// <summary>
    ///     Immutable struct representing a Poker Playing Card
    /// </summary>
    public struct Card
    {
        public readonly Suit Suit;
        public readonly Face Face;

        public static List<Card> GetCards(string cardString)
        {
            return cardString.Split(' ').Select(Create).ToList();
        }

        private Card(Suit suit, Face face)
        {
            Suit = suit;
            Face = face;
        }

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
}